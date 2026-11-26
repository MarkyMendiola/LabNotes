using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace LabPCTracker.Backend
{
    public class Teacher
    {
        public int id;
        public string name;

        // When this object is called, it will return the name of the teacher
        public override string ToString()
        {
            return name;
        }
    }

    // One booking: which lab, and when
    public class ScheduleItem
    {
        public int id;
        public string labName;
        public DateTime start;
        public DateTime end;
    }

    public static class Schedules
    {
        // Creates a list of teachers from the database and returns it
        public static List<Teacher> GetTeachers()
        {
            var teachers = new List<Teacher>();

            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT user_id, full_name
                FROM users
                WHERE role = 'Teacher'
                ORDER BY full_name;";
                
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var teacher = new Teacher
                {
                    id = reader.GetInt32(0),
                    name = reader.GetString(1)
                };
                teachers.Add(teacher);
            }

            return teachers;
        }
    
        // Creates a list of the labs that are booked at any moment between start and end
        // P.S class Lab is defined in computers.cs, but it shares namespace so it can be used here as well
        public static List<Lab> GetBookedLabs(DateTime start, DateTime end)
        {
            var labs = new List<Lab>();

            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT l.lab_id, l.lab_name
                FROM labs l
                JOIN schedules s ON s.lab_id = l.lab_id
                WHERE s.start_time < @end AND s.end_time > @start
                ORDER BY l.lab_name;";
            cmd.Parameters.AddWithValue("@start", start);  
            cmd.Parameters.AddWithValue("@end", end);    
            using var reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                var lab = new Lab
                {
                    id = reader.GetInt32(0),
                    name = reader.GetString(1)
                };
                labs.Add(lab);
            }

            return labs;
        }

        // Lists every booking of one user (teacher), earliest first
        public static List<ScheduleItem> GetSchedulesForUser(int userId)
        {
            var items = new List<ScheduleItem>();

            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT s.schedule_id, l.lab_name, s.start_time, s.end_time
                FROM schedules s
                JOIN labs l ON l.lab_id = s.lab_id
                WHERE s.user_id = @userId
                ORDER BY s.start_time;";
            cmd.Parameters.AddWithValue("@userId", userId);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var item = new ScheduleItem
                {
                    id = reader.GetInt32(0),
                    labName = reader.GetString(1),
                    start = reader.GetDateTime(2),
                    end = reader.GetDateTime(3)
                };
                items.Add(item);
            }

            return items;
        }

        // Returns the first booking that has not started yet, or null if there is none
        public static ScheduleItem GetNextSchedule(int userId)
        {
            // The list is already sorted by start time, so the first future one is the next one
            foreach (var item in GetSchedulesForUser(userId))
            {
                if (item.start >= DateTime.Now)
                {
                    return item;
                }
            }

            return null;
        }

        // Books a lab for a teacher. Throws an error if the times are wrong or the lab is already taken.
        public static void AddSchedule (DateTime start, DateTime end, int teacherId, int labId)
        {
            if (end <= start)
            {
                throw new InvalidOperationException("The end time must be after the start time.");
            }

            // Conflict check: is this lab already booked at some point between start and end?
            foreach (var lab in GetBookedLabs(start, end))
            {
                if (lab.id == labId)
                {
                    throw new InvalidOperationException("That lab is already booked at this time.");
                }
            }

            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO schedules (start_time, end_time, user_id, lab_id)
                VALUES (@start, @end, @teacherId, @labId);";

            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            cmd.Parameters.AddWithValue("@teacherId", teacherId);
            cmd.Parameters.AddWithValue("@labId", labId);
            cmd.ExecuteNonQuery();
        }
    }
}
