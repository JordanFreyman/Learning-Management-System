using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using Library.LMS.Models;
using Library.LMS.Services;

namespace Library.LMS.Helper{
    internal class CourseHelper{
        private CourseService courseService;
        private StudentService studentService;
        public CourseHelper(StudentService studentService2){
            studentService = studentService2;
            courseService = CourseService.Current;
        }
        public void NewCourse(Course? selectedCourse = null){
            Console.WriteLine("Enter course code: ");
            var courseCode = Console.ReadLine();
            
            Console.WriteLine("Enter course name: ");
            var courseName = Console.ReadLine();
            
            
            Console.WriteLine("Enter course description: ");
            var courseDesc = Console.ReadLine() ?? string.Empty;

            var roster = new List<Person>();
            bool done = false;
            while(!done){
                //studentService.AllStudents.Where(s => !roster.Any(s2 => s2.studentNumber == s.studentNumber)).ToList().ForEach(Console.WriteLine);//print student nums

                var choice = "0";
                if(studentService.AllStudents.Any(s => !roster.Any(s2 => s2.studentNumber == s.studentNumber))){
                    Console.WriteLine("Which students to add to course?");
                    foreach(Person s in studentService.AllStudents.Where(s => !roster.Any(s2 => s2.studentNumber == s.studentNumber)).ToList()){
                        Console.WriteLine($"({s.studentNumber}) {s}");
                    }
                    Console.WriteLine("\nPress '0' when done");
                    choice = Console.ReadLine() ?? string.Empty;
                }

                if(int.TryParse(choice, out int result)){    
                    if(result == 0){
                        done = true;
                    }
                    else{
                        var selectedStudent = studentService.AllStudents.FirstOrDefault(s => s.studentNumber == result);

                        if(selectedStudent != null && !roster.Contains(selectedStudent)){
                            roster.Add(selectedStudent);
                        }
                    }
                }
            }

            Console.WriteLine("Add assignments? (y/n)");
            var ans = Console.ReadLine() ?? "N";
            var assignments = new List<Assignment>();
            if(ans.Equals("Y") || ans.Equals("y")){
                
                done = false;
                while(!done){

                    AddAssignment(true, null, assignments);

                    Console.WriteLine("Add more? (y/n)");
                    var ans2 = Console.ReadLine() ?? "N";
                    if(ans2.Equals("N") || ans2.Equals("n"))
                        done = true;
                }
            }

            bool isNewCourse = false;
            if(selectedCourse == null){
                isNewCourse = true;
                selectedCourse = new Course();
            }

            selectedCourse.Name = courseName ?? string.Empty;
            selectedCourse.Code = courseCode ?? string.Empty;
            selectedCourse.Description = courseDesc ?? string.Empty;
            selectedCourse.Roster = new List<Person>();
            selectedCourse.Roster = roster;
            selectedCourse.Assignments = new List<Assignment>();
            selectedCourse.Assignments.AddRange(assignments);

            if(isNewCourse){
                courseService.Add(selectedCourse);
            }
        }
        public void ListAllCourses(){
            foreach(Course c in courseService.CourseList){
                Console.WriteLine(c);
            }
        }

        public void SearchCourses(){
            Console.WriteLine("Search for a course by (1) Code, (2) Name, or (3) Description?");
            var cnd = Console.ReadLine();
            Console.WriteLine("Enter query");
            string? searchfor = Console.ReadLine();
            if(searchfor!=null){
                if(int.TryParse(cnd, out int choice)){
                    foreach(Course c in courseService.Search(searchfor, choice).ToList()){
                        Console.WriteLine(c);
                        Console.WriteLine(c.Description);
                    }
                }
            }
        }

        public void UpdateCourse(){
            Console.WriteLine("Which course would you like to update?");
            ListAllCourses();
            Console.WriteLine("Enter number");
            var courseChoice = Console.ReadLine();

            if(int.TryParse(courseChoice, out int course)){
                var selectedCourse = courseService.CourseList.FirstOrDefault(c => c.courseNum == course);
                if(selectedCourse!=null){
                    NewCourse(selectedCourse);
                }
            }

        }

        public void AddStudent(){
            StudentHelper s = new StudentHelper(studentService);
            Course course;
            Person student;

            Console.WriteLine("Select a course");
            ListAllCourses();
            var selectcourse = Console.ReadLine();

            if(int.TryParse(selectcourse, out int result)){
                int temp = courseService.CourseList.FindIndex(c => c.courseNum == result);
                course = courseService.CourseList[temp];

                Console.WriteLine("Select a student to add");
                var NotList = studentService.AllStudents.Where(s => !course.Roster.Any(s2 => s2.studentNumber == s.studentNumber));
                foreach(Person p in NotList){
                    Console.WriteLine($"({p.studentNumber}) {p}");
                }

                var selectstudent = Console.ReadLine();
                if(int.TryParse(selectstudent, out int result2)){
                    int temp2 = studentService.AllStudents.FindIndex(s => s.studentNumber == result2);
                    student = studentService.AllStudents[temp2];

                    course.Roster.Add(student);
                    Console.WriteLine($"{student.Name} successfully added to {course.Code}!\n");
                    Console.WriteLine("Printing course roster:");
                    ListAllStudentsInCourse(course);
                }

            }
        }

        public void RemoveStudent(){
            Course course;
            Person student;

            Console.WriteLine("Select a course");
            ListAllCourses();
            var selectcourse = Console.ReadLine();

            if(int.TryParse(selectcourse, out int result)){
                int temp = courseService.CourseList.FindIndex(c => c.courseNum == result);
                course = courseService.CourseList[temp];

                Console.WriteLine("Select a student to remove");
                ListAllStudentsInCourse(course);

                var selectstudent = Console.ReadLine();
                if(int.TryParse(selectstudent, out int result2)){
                    int temp2 = studentService.AllStudents.FindIndex(s => s.studentNumber == result2);
                    student = studentService.AllStudents[temp2];

                    course.Roster.Remove(student);
                    Console.WriteLine($"{student.Name} successfully removed from {course.Code}!");
                    Console.WriteLine("Printing course roster:");
                    ListAllStudentsInCourse(course);
                }

            }
                              
        }

        public void ListEnrolledStudents(){
            Course c;
            Console.WriteLine("Select a course:");
            ListAllCourses();
            var selectcourse = Console.ReadLine();

            if(int.TryParse(selectcourse, out int result)){
                int temp = courseService.CourseList.FindIndex(c => c.courseNum == result);
                c = courseService.CourseList[temp];

                Console.WriteLine($"{c.Code} Roster\n");
                foreach(Person p in c.Roster){
                    Console.WriteLine($"({p.studentNumber}) {p}");
                }
            }
        }

        public void ListAllStudentsInCourse(Course c){
            foreach(Person p in c.Roster){
                Console.WriteLine($"({p.studentNumber}) {p}");
            }
        }
    
        public void AddAssignment(bool newCourse, int? courseName = null, List<Assignment>? assignmentList = null){
            Console.WriteLine("Assignment name:");
            var assignmentName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Description:");
            var description = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Total points:");
            var totalPoints = int.Parse(Console.ReadLine() ?? "100");

            Console.WriteLine("Due date:");
            var dueDate = DateTime.Parse(Console.ReadLine() ?? "12/31/1999");

            var newAssignment = new Assignment{Name = assignmentName, Description = description, TotalAvailablePoints = totalPoints, DueDate = dueDate};

            if(newCourse){
                assignmentList.Add(newAssignment);
            }
            else if(!newCourse && courseName != null){
                var selectedCourse = courseService.CourseList.FirstOrDefault(c => c.courseNum == courseName);
                selectedCourse.Assignments.Add(newAssignment);
            }
        }
    }
}