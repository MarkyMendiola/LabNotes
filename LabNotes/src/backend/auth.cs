using System;
using Microsoft.Data.SqlClient;

namespace LabPCTracker.Backend
{
    public static class Auth
    {
        // Returns true if the username exists and the password matches
        public static bool Login(string username, string password)
        {
            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT password
                FROM users
                WHERE username = @username;";
            cmd.Parameters.AddWithValue("@username", username);
            using var reader = cmd.ExecuteReader();

            // No row means there is no user with that username
            if (!reader.Read())
            {
                return false;
            }

            // Compare the saved password with the typed one
            string savedPassword = reader.GetString(0);
            return savedPassword == password;
        }

        // Returns the gender of the user with this username, or "" if there is none
        public static string GetGender(string username)
        {
            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT gender
                FROM users
                WHERE username = @username;";
            cmd.Parameters.AddWithValue("@username", username);
            using var reader = cmd.ExecuteReader();

            // No row means there is no user with that username
            if (!reader.Read())
            {
                return "";
            }

            // The gender column can be empty in the database
            return reader.IsDBNull(0) ? "" : reader.GetString(0);
        }
    }
}
