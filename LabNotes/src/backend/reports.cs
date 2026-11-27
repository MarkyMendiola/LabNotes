using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace LabPCTracker.Backend
{
    public class IssueLog
    {
        public int id;
        public int computerId;
        public string pcName;
        public int labId;
        public string labName;
        public int reportedBy;
        public string reporterName;
        public string description;
        public DateTime reportedAt;
        public DateTime? resolvedAt;   // null = not fixed yet

        // When this object is called, it will return something like "LAB1-PC01: Monitor flickers (open)"
        public override string ToString()
        {
            string state = resolvedAt == null ? "open" : "resolved";
            return pcName + ": " + description + " (" + state + ")";
        }
    }

    public static class IssueLogs
    {
        // Lists every issue log, newest first
        public static List<IssueLog> GetIssueLogs()
        {
            return ReadLogs("");
        }

        // Lists only the issues that are not fixed yet (resolved_at is empty)
        public static List<IssueLog> GetOpenIssues()
        {
            return ReadLogs("WHERE il.resolved_at IS NULL");
        }

        // Reports a problem on a computer.
        // Adds the log AND sets the computer's status to the chosen one ("Faulty" or "Broken"). Returns the new log_id.
        public static int ReportIssue(int computerId, int reportedBy, string description, string status)
        {
            if (status != Constants.StatusFaulty && status != Constants.StatusBroken)
            {
                throw new InvalidOperationException("The status must be Faulty or Broken.");
            }

            using var conn = Db.Open();
            using var tx = conn.BeginTransaction();

            // lab_id is copied from the computer, so the caller does not have to pass it
            using var insert = conn.CreateCommand();
            insert.Transaction = tx;
            insert.CommandText = @"
                INSERT INTO issue_logs (computer_id, lab_id, reported_by, description)
                OUTPUT INSERTED.log_id
                SELECT computer_id, lab_id, @reportedBy, @description
                FROM computers
                WHERE computer_id = @computerId;";
            insert.Parameters.AddWithValue("@computerId", computerId);
            insert.Parameters.AddWithValue("@reportedBy", reportedBy);
            insert.Parameters.AddWithValue("@description", description);

            var result = insert.ExecuteScalar();
            if (result == null)
            {
                throw new InvalidOperationException("Computer not found.");
            }

            using var update = conn.CreateCommand();
            update.Transaction = tx;
            update.CommandText = "UPDATE computers SET status = @status WHERE computer_id = @computerId;";
            update.Parameters.AddWithValue("@status", status);
            update.Parameters.AddWithValue("@computerId", computerId);
            update.ExecuteNonQuery();

            tx.Commit();
            return (int)result;
        }

        // Gives a log to every computer that is Faulty or Broken but has no open log yet,
        // for example a computer that was already marked Faulty when the app first started.
        // Safe to call many times: computers that already have an open log are skipped.
        public static void AddMissingLogs(int reportedBy)
        {
            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO issue_logs (computer_id, lab_id, reported_by, description)
                SELECT c.computer_id, c.lab_id, @reportedBy, 'Already ' + c.status + ' at start-up'
                FROM computers c
                WHERE c.status IN ('Faulty', 'Broken')
                  AND c.lab_id IS NOT NULL
                  AND NOT EXISTS (SELECT 1 FROM issue_logs il
                                  WHERE il.computer_id = c.computer_id AND il.resolved_at IS NULL);";
            cmd.Parameters.AddWithValue("@reportedBy", reportedBy);
            cmd.ExecuteNonQuery();
        }

        // Marks an issue as fixed (sets resolved_at to now).
        // The computer goes back to "Available" only if it has no other open issue.
        public static void ResolveIssue(int logId)
        {
            using var conn = Db.Open();
            using var tx = conn.BeginTransaction();

            using var resolve = conn.CreateCommand();
            resolve.Transaction = tx;
            resolve.CommandText = @"
                UPDATE issue_logs
                SET resolved_at = SYSDATETIME()
                OUTPUT INSERTED.computer_id
                WHERE log_id = @logId AND resolved_at IS NULL;";
            resolve.Parameters.AddWithValue("@logId", logId);

            var result = resolve.ExecuteScalar();
            if (result == null)
            {
                throw new InvalidOperationException("Issue not found or already resolved.");
            }
            int computerId = (int)result;

            using var status = conn.CreateCommand();
            status.Transaction = tx;
            status.CommandText = @"
                UPDATE computers
                SET status = 'Available'
                WHERE computer_id = @computerId
                  AND NOT EXISTS (SELECT 1 FROM issue_logs
                                  WHERE computer_id = @computerId AND resolved_at IS NULL);";
            status.Parameters.AddWithValue("@computerId", computerId);
            status.ExecuteNonQuery();

            tx.Commit();
        }

        // Shared by GetIssueLogs and GetOpenIssues (only ever receives fixed text, never user input)
        private static List<IssueLog> ReadLogs(string whereClause)
        {
            var logs = new List<IssueLog>();

            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT il.log_id, il.computer_id, c.pc_name, il.lab_id, l.lab_name,
                       il.reported_by, u.full_name, il.description, il.reported_at, il.resolved_at
                FROM issue_logs il
                JOIN computers c ON c.computer_id = il.computer_id
                JOIN labs l ON l.lab_id = il.lab_id
                JOIN users u ON u.user_id = il.reported_by " + whereClause + @"
                ORDER BY il.reported_at DESC;";
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var log = new IssueLog
                {
                    id = reader.GetInt32(0),
                    computerId = reader.GetInt32(1),
                    pcName = reader.GetString(2),
                    labId = reader.GetInt32(3),
                    labName = reader.GetString(4),
                    reportedBy = reader.GetInt32(5),
                    reporterName = reader.GetString(6),
                    description = reader.GetString(7),
                    reportedAt = reader.GetDateTime(8),
                    resolvedAt = reader.IsDBNull(9) ? (DateTime?)null : reader.GetDateTime(9)
                };
                logs.Add(log);
            }

            return logs;
        }
    }
}
