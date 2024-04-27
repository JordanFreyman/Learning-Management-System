namespace Maui.LMS.Pages;

public partial class StudentPage : ContentPage
{
	public StudentPage()
	{
		InitializeComponent();
	}    
	private async void OnGoBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}