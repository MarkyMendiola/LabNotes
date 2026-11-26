using System;

public static class Constants
{
    public const string Database = "MyDb";
    public const string RoleAdmin = "admin";
    public const string RoleTeacher = "teacher";

    // These must match the words saved in the computers.status column
    public const string StatusAvailable = "Available";
    public const string StatusFaulty = "Faulty";
    public const string StatusBroken = "Broken";

    public const string AppTitle = "Lab PC Tracker";
}
