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
        public string status;   // "working" or "broken"

        // When this object is called, it will return something like "LAB1-PC07 - broken"
        public override string ToString()
        {
            return name + " - " + status;
        }
    }

    public static class Computers
    {
        public static List<Lab> GetBookedLabs()
        {
            var labs = new List<Lab>();

            using var conn = Db.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT lab_id, lab_name
                FROM Labs
                ORDER BY name;";
            var reader = cmd.ExecuteReader();

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
    
        // Lists every computer with its lab and whether it is working or broken
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
    }


}