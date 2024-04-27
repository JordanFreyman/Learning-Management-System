using Maui.LMS.Pages;

namespace Maui.LMS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Routing.RegisterRoute("Instructor", typeof(InstructorPage));

            Routing.RegisterRoute("Student", typeof(StudentPage));

            Routing.RegisterRoute("IStudents", typeof(IStudentPage));

            Routing.RegisterRoute("ICourses", typeof(ICoursePage));

            Routing.RegisterRoute("StudentDetail", typeof(StudentDetail));
        }
    }
}
