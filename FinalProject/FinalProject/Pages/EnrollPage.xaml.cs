using FinalProject.Models;

namespace FinalProject.Pages;

public partial class EnrollPage : ContentPage
{
    private Enrollment? existingEnrollment = null;
    public EnrollPage()
    {
        InitializeComponent();
        StudentsList.ItemsSource = App.DBTrans.GetAllStudents();
        CourseList.ItemsSource = App.DBTrans.GetAllCourses();
        EnrollmentList.ItemsSource = App.DBTrans.GetAllEnrollments();
    }
    private void ShowButton_Clicked(object sender, EventArgs e)
    {
        StudentsList.ItemsSource = App.DBTrans.GetAllStudents();
        CourseList.ItemsSource = App.DBTrans.GetAllCourses();
        EnrollmentList.ItemsSource = App.DBTrans.GetAllEnrollments();
    }

    private void AddButton_Clicked(object sender, EventArgs e)
    {
        var student = StudentsList.SelectedItem as Student;
        var course = CourseList.SelectedItem as Course;

        if (student != null && course != null)
        {
            var enroll = new Enrollment
            {
                StudentID = student.StudentID,
                CourseID = course.CourseID
            };

            App.DBTrans.GetAllEnrollments().ForEach(enrollment =>
            {
                if(enrollment.StudentID == enroll.StudentID && enrollment.CourseID == enroll.CourseID)
                {
                    existingEnrollment = enrollment;
                    DisplayAlert("Error", "This enrollment already exists.", "OK");
                }
            });
            if(existingEnrollment != null)
            {
                existingEnrollment = null;
                return;
            }
            App.DBTrans.AddEnrollment(enroll);
            ShowButton_Clicked(sender, e);
        }
        else
        {
            DisplayAlert("Error", "Please select both a student and a course.", "OK");
        }
        StudentsList.SelectedItem = null;
        CourseList.SelectedItem = null;
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        var selectedEnrollment = EnrollmentList.SelectedItem as Enrollment;
        if (selectedEnrollment != null)
        {
            App.DBTrans.DeleteEnrollment(selectedEnrollment.EnrollmentID);
            ShowButton_Clicked(sender, e);
        }
        else
        {
            DisplayAlert("Error", "Please select an enrollment to delete.", "OK");
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        EnrollmentList.ItemsSource = App.DBTrans.GetAllEnrollments();
    }
}