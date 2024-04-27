namespace Maui.LMS.Pages;

public partial class InstructorPage : ContentPage
{
	public InstructorPage()
	{
		InitializeComponent();
	}    
    private async void OnGoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
	private async void AccessStudents(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("/StudentDetail");
    }
    private async void AccessCourses(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("/ICourses");
    }
}