using Library.LMS.Models;
using Library.LMS.Services;

namespace Library.LMS.Helper{
    internal class StudentHelper{
        private StudentService studentService;
        private CourseService courseService;
        public StudentHelper(StudentService studentService2){
            studentService = studentService2;
            courseService = CourseService.Current;
        }
        public void NewStudent(Person? selectedStudent = null){//Create new student
            
            Console.WriteLine("Enter name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Enter year (number): ");
            var classification = Console.ReadLine();
            
            bool isNewStudent = false;
            if(selectedStudent == null){
                isNewStudent = true;
                selectedStudent = new Person();
            }

            selectedStudent.Name = name ?? string.Empty;
            selectedStudent.Classification = int.Parse(classification ?? "0");

            if(isNewStudent)
                studentService.Add(selectedStudent);
            
            Console.WriteLine("Student created!");
            
        }
        public void ListAllStudents(){
            //studentService.AllStudents.ForEach(Console.WriteLine);
            foreach(Person s in studentService.AllStudents){
                Console.WriteLine($"({s.studentNumber}) {s}");
            }
        }

        public void SearchStudents(){
            Console.WriteLine("Search for student by name");
            string? searchfor = Console.ReadLine();
            studentService.Search(searchfor).ToList().ForEach (Console.WriteLine);
        }
        public void UpdateStudent(){
            Console.WriteLine("Which student would you like to update?");
            ListAllStudents();
            Console.WriteLine("Enter number:");
            var studentchoice = Console.ReadLine();

            if(int.TryParse(studentchoice, out int studentChoice)){
                var selectedStudent = studentService.AllStudents.FirstOrDefault(s => s.studentNumber == studentChoice);
                if(selectedStudent != null){
                    NewStudent(selectedStudent);
                }
            }
        }

        public void ListEnrolledCourses(){
            Console.WriteLine("Select a student:");
            ListAllStudents();
            var studentSelection = Console.ReadLine();
            if(int.TryParse(studentSelection, out int result)){
                string name = studentService.AllStudents[result-1].Name;
                Console.WriteLine($"{name}'s Courses:");
                courseService.CourseList.Where(c => c.Roster.Any(s => s.studentNumber == result)).ToList().ForEach(Console.WriteLine);
            }
        }
    }
}