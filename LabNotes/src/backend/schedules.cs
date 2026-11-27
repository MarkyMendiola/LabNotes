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
        public string subject;
        public string section;
        public string dayOfWeek;
        public DateTime start;
        public DateTime end;
        public bool isRecurring;
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
    
        // Creates a list of the labs that are booked at any moment between start and end.
        // A one-time booking is in the way only on the same date.
        // A weekly (recurring) booking is in the way on the same weekday, whatever the date is.
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
                WHERE
                    -- one-time booking: same date and the times overlap
                    (s.is_recurring = 0 AND s.start_time < @end AND s.end_time > @start)
                    OR
                    -- weekly booking: same weekday and the times of day overlap
                    (s.is_recurring = 1 AND s.day_of_week = @dayOfWeek
                     AND CAST(s.start_time AS TIME) < CAST(@end AS TIME)
                     AND CAST(s.end_time AS TIME) > CAST(@start AS TIME))
                ORDER BY l.lab_name;";
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            cmd.Parameters.AddWithValue("@dayOfWeek", start.DayOfWeek.ToString());
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
                SELECT s.schedule_id, l.lab_name, s.subject, s.section,
                       s.day_of_week, s.start_time, s.end_time, s.is_recurring
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
                    subject = reader.GetString(2),
                    section = reader.GetString(3),
                    dayOfWeek = reader.GetString(4),
                    start = reader.GetDateTime(5),
                    end = reader.GetDateTime(6),
                    isRecurring = reader.GetBoolean(7)
                };
                items.Add(item);
            }

            return items;
        }

        // Returns the booking that starts soonest from now, or null if there is none
        public static ScheduleItem GetNextSchedule(int userId)
        {
            ScheduleItem next = null;

            foreach (var item in GetSchedulesForUser(userId))
            {
                // A weekly booking is saved with only a weekday and a time of day (its date is 1900),
                // so first work out the next real date it happens on
                if (item.isRecurring)
                {
                    MoveToNextWeekday(item);
                }

                // A one-time booking that already started is skipped
                if (item.start < DateTime.Now)
                {
                    continue;
                }

                // Keep the one that starts the earliest
                if (next == null || item.start < next.start)
                {
                    next = item;
                }
            }

            return next;
        }

        // Changes a weekly booking's start and end to its next real date (today counts if it has not started yet)
        private static void MoveToNextWeekday(ScheduleItem item)
        {
            TimeSpan length = item.end - item.start;
            DateTime date = DateTime.Today + item.start.TimeOfDay;

            // Go forward one day at a time until it is the right weekday and still in the future (at most 8 days)
            for (int i = 0; i < 8; i++)
            {
                if (date.DayOfWeek.ToString() == item.dayOfWeek && date >= DateTime.Now)
                {
                    break;
                }
                date = date.AddDays(1);
            }

            item.start = date;
            item.end = date + length;
        }

        // Books a lab for a teacher on one date. Throws an error if the times are wrong,
        // the class name or section is empty, or the lab is already taken.
        public static void AddSchedule (DateTime start, DateTime end, int teacherId, int labId, string subject, string section, string dayOfWeek)
        {
            if (end <= start)
            {
                throw new InvalidOperationException("The end time must be after the start time.");
            }

            if (string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(section))
            {
                throw new InvalidOperationException("Please type the class name and the section.");
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
                INSERT INTO schedules (start_time, end_time, user_id, lab_id, subject, section, day_of_week, is_recurring)
                VALUES (@start, @end, @teacherId, @labId, @subject, @section, @dayOfWeek, 0);";   // 0 = one-time booking

            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            cmd.Parameters.AddWithValue("@teacherId", teacherId);
            cmd.Parameters.AddWithValue("@labId", labId);
            cmd.Parameters.AddWithValue("@subject", subject);
            cmd.Parameters.AddWithValue("@section", section);
            cmd.Parameters.AddWithValue("@dayOfWeek", dayOfWeek);
            cmd.ExecuteNonQuery();
        }
    }
}
