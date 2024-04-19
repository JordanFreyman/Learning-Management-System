namespace Maui.LMS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Routing.RegisterRoute("Instructor", typeof(Instructor.InstructorPage));

            Routing.RegisterRoute("Student", typeof(StudentPage));

            Routing.RegisterRoute("IStudents", typeof(Instructor.IStudentPage));

            Routing.RegisterRoute("ICourses", typeof(Instructor.ICoursePage));
        }
    }
}
