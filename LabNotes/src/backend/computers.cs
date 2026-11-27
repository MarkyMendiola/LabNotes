using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient; 

namespace LabPCTracker.Backend
{
    public class Lab
    {
        public int id;
        public string name;

        // When this object is called , it will return the name of the lab
        public override string ToString()
        {
            return name;
        }
    }

    public class Computer
    {
        public int id;
        public string name;
        public int? labId;
        public string labName;
        public string status;   // "Available", "Faulty" or "Broken"

        // When this object is called, it will return something like "LAB1-PC07 - Broken"
        public override string ToString()
        {
            return name + " - " + status;
        }
    }

    public static class Computers
    {
        // Lists every lab (used for the lab dropdown and as the "all labs" set in Logic.Difference)
        public static List<Lab> GetLabs()
        {
            var labs = new List<Lab>();

            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT lab_id, lab_name
                FROM labs
                ORDER BY lab_name;";
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

        //To create GetStatus. A method that lists the status of every computer whether working faulty or broken         
    
        // Lists every computer with its lab and its status (Available, Faulty or Broken)
        public static List<Computer> GetStatus()
        {
            var computers = new List<Computer>();

            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT c.computer_id, c.pc_name, c.lab_id, l.lab_name, c.status
                FROM computers c
                LEFT JOIN labs l ON l.lab_id = c.lab_id
                ORDER BY c.lab_id, c.pc_name;";
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var pc = new Computer
                {
                    id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    labId = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                    labName = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    status = reader.GetString(4)
                };
                computers.Add(pc);
            }

            return computers;
        }

        // Lists the names of the software installed on one computer
        public static List<string> GetSoftware(int computerId)
        {
            var software = new List<string>();

            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT s.software_name
                FROM pc_software ps
                JOIN software s ON s.software_id = ps.software_id
                WHERE ps.computer_id = @computerId
                ORDER BY s.software_name;";
            cmd.Parameters.AddWithValue("@computerId", computerId);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                software.Add(reader.GetString(0));
            }

            return software;
        }

        // Returns the name of the lab with the most Faulty or Broken PCs and sets brokenCount to that number.
        // Returns "" (and 0) when no PC is faulty or broken.
        public static string GetMostBrokenLab(out int brokenCount)
        {
            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT TOP 1 l.lab_name, COUNT(*) AS total
                FROM computers c
                JOIN labs l ON l.lab_id = c.lab_id
                WHERE c.status IN ('Faulty', 'Broken')
                GROUP BY l.lab_name
                ORDER BY COUNT(*) DESC, l.lab_name;";
            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                brokenCount = 0;
                return "";
            }

            brokenCount = reader.GetInt32(1);
            return reader.GetString(0);
        }

        // Lists the labs that have the software installed (on at least one PC)
        public static List<Lab> GetLabsWithSoftware(string softwareName)
        {
            var labs = new List<Lab>();

            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT DISTINCT l.lab_id, l.lab_name
                FROM labs l
                JOIN computers c ON c.lab_id = l.lab_id
                JOIN pc_software ps ON ps.computer_id = c.computer_id
                JOIN software s ON s.software_id = ps.software_id
                WHERE s.software_name LIKE @name
                ORDER BY l.lab_name;";
            cmd.Parameters.AddWithValue("@name", "%" + softwareName + "%");
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
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
    }
}
