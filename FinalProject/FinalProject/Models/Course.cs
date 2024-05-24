using SQLite;

namespace FinalProject.Models;

public class Course
{
    [AutoIncrement, PrimaryKey]
    public int CourseID { get; set; }
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
}
