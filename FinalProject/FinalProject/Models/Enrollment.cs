using SQLite;

namespace FinalProject.Models;

public class Enrollment
{
    [AutoIncrement, PrimaryKey]
    public int EnrollmentID { get; set; }
    public int StudentID { get; set; }
    public int CourseID { get; set; }
}
