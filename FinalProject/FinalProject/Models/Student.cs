using SQLite;

namespace FinalProject.Models;

public class Student
{
    [AutoIncrement, PrimaryKey]
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public string Department { get; set; }
}
