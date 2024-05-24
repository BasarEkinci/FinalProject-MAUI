using FinalProject.Models;

namespace FinalProject.Pages;

public partial class CoursePage : ContentPage
{
    public CoursePage()
    {
        InitializeComponent();
        CourseListView.ItemsSource = App.DBTrans.GetAllCourses();
    }

    private void AddButton_Clicked(object sender, EventArgs e)
    {
        if(string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            DisplayAlert("Error", "Please fill in the requested information.", "OK");
            return;
        }
        else if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            DisplayAlert("Error", "Please fill in the requested information.", "OK");
            return;
        }
        App.DBTrans.AddCourse(new Models.Course
        {
            CourseName = NameEntry.Text,
            CourseCode = CodeEntry.Text
        });
        NameEntry.Text = string.Empty;
        CodeEntry.Text = string.Empty;
    }

    private void ShowButton_Clicked(object sender, EventArgs e)
    {
        CourseListView.ItemsSource = App.DBTrans.GetAllCourses();
    }

    private void DelButton_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        App.DBTrans.DeleteCourse((int)button.BindingContext);
        CourseListView.ItemsSource = App.DBTrans.GetAllCourses();
    }
}