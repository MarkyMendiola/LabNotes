using System;
using Microsoft.Data.SqlClient;

namespace LabPCTracker.Backend
{
    public class User
    {
        public int id;
        public string name;
        public string role;
    }

    public static class Auth
    {
        // The user who is logged in right now (null when nobody is logged in)
        public static User CurrentUser;

        // Returns true if a user with this full name exists and the password matches.
        // When it matches, CurrentUser is filled in so every screen can use it.
        public static bool Login(string fullName, string password)
        {
            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT user_id, full_name, role, password
                FROM users
                WHERE full_name = @fullName;";
            cmd.Parameters.AddWithValue("@fullName", fullName);
            using var reader = cmd.ExecuteReader();

            // No row means there is no user with that name
            if (!reader.Read())
            {
                return false;
            }

            // Compare the saved password with the typed one
            string savedPassword = reader.GetString(3);
            if (savedPassword != password)
            {
                return false;
            }

            CurrentUser = new User
            {
                id = reader.GetInt32(0),
                name = reader.GetString(1),
                role = reader.IsDBNull(2) ? "" : reader.GetString(2)
            };
            return true;
        }

        // Returns the gender of the user with this full name, or "" if there is none
        public static string GetGender(string fullName)
        {
            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT gender
                FROM users
                WHERE full_name = @fullName;";
            cmd.Parameters.AddWithValue("@fullName", fullName);
            using var reader = cmd.ExecuteReader();

            // No row means there is no user with that name
            if (!reader.Read())
            {
                return "";
            }

            // The gender column can be empty in the database
            return reader.IsDBNull(0) ? "" : reader.GetString(0);
        }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
