using FinalProject.Models;

namespace FinalProject.Pages;

public partial class StudentPage : ContentPage
{
    public StudentPage()
    {
        InitializeComponent();
        StudentListView.ItemsSource = App.DBTrans.GetAllStudents();
    }

    private void AddButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(NameEntry.Text) || string.IsNullOrEmpty(DPEntry.Text))
        {
            DisplayAlert("Error", "Please fill in the requested information.", "OK");
            return;
        } 
        else if (string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(DPEntry.Text))
        {
            DisplayAlert("Error", "Please fill in the requested information.", "OK");
            return;
        }
        App.DBTrans.AddStudent(new Models.Student
        {
            StudentName = NameEntry.Text,
            Department = DPEntry.Text
        });
        NameEntry.Text = string.Empty;
        DPEntry.Text = string.Empty;
    }

    private void ShowButton_Clicked(object sender, EventArgs e)
    {
        StudentListView.ItemsSource = App.DBTrans.GetAllStudents();
    }

    private void DelButton_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        App.DBTrans.DeleteStudent((int)button.BindingContext);
        StudentListView.ItemsSource = App.DBTrans.GetAllStudents();
    }
}