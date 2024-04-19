using Maui.LMS.ViewModels;
namespace Maui.LMS.Views;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
		InitializeComponent();
        BindingContext = new InstructorViewViewModel();
	}    
    private async void OnGoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
	private async void AccessStudents(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("//StudentDetail");
    }
    private async void AccessCourses(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("/ICourses");
    }
}