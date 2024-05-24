using FinalProject.Models;
using SQLite;

namespace FinalProject.DataTransactions;

public class DBTrans
{
    public string DatabasePath;
    private SQLiteConnection connection;

    public DBTrans(string databasePath)
    {
        DatabasePath = databasePath;
    }

    public void InitializeDB()
    {
        connection = new SQLiteConnection(DatabasePath);
        connection.CreateTable<Student>();
        connection.CreateTable<Course>();
        connection.CreateTable<Enrollment>();
    }

    public List<Student> GetAllStudents()
    {
        InitializeDB();
        return connection.Table<Student>().ToList();
    }

    public List<Course> GetAllCourses()
    {
        InitializeDB();
        return connection.Table<Course>().ToList();
    }

    public List<Enrollment> GetAllEnrollments()
    {
        InitializeDB();
        return connection.Table<Enrollment>().ToList();
    }

    public void AddStudent(Student student)
    {
        connection = new SQLiteConnection(DatabasePath);
        connection.Insert(student);
    }

    public void AddCourse(Course course)
    {
        connection = new SQLiteConnection(DatabasePath);
        connection.Insert(course);
    }

    public void AddEnrollment(Enrollment enrollment)
    {
        connection = new SQLiteConnection(DatabasePath);
        connection.Insert(enrollment);
    }

    public void DeleteStudent(int id)
    {
        connection = new SQLiteConnection(DatabasePath);
        connection.Delete(new Student { StudentID = id });
    }

    public void DeleteCourse(int id)
    {
        connection = new SQLiteConnection(DatabasePath);
        connection.Delete(new Course { CourseID = id });
    }

    public void DeleteEnrollment(int id)
    {
        connection = new SQLiteConnection(DatabasePath);
        connection.Delete(new Enrollment { EnrollmentID = id});
    }
}
