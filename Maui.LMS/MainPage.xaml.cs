using Maui.LMS.ViewModels;
namespace Maui.LMS
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void OnInstructorClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("/Instructor");
        }

        private void OnStudentClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("/Student");
        }
    }

}
