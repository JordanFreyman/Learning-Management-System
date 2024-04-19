using System;
using System.Xml.XPath;
using Library.LMS.Models;
using Library.LMS.Services;
using Library.LMS.Helper;
using Microsoft.VisualBasic;

namespace LMS{
    internal class Program{

        static void Main(string[] args){
            var studentService = new StudentService();
            var studentHelper = new StudentHelper(studentService);
            var courseHelper = new CourseHelper(studentService);
            string? menuchoice1;
            
            //Main Menu
            

                do{
                    Console.WriteLine("\nWhat would you like to do?\n");
                    Console.WriteLine("1) Students...");
                    Console.WriteLine("2) Courses...");
                    Console.WriteLine("3) Quit");
                    menuchoice1 = Console.ReadLine();

                    if(int.TryParse(menuchoice1, out int resultMenu)){//Menu options start

                        if(resultMenu==1){//Student Menu Options
                            Console.WriteLine("Select an option:\n\n1) Create a new student\n2) Add an existing student to a course");
                            Console.WriteLine("3) Remove student from a course\n4) Search for a student by name\n5) Update a student's information");
                            Console.WriteLine("6) List all students\n7) List all courses a student is taking");
                            var menuchoice2 = Console.ReadLine();
                            if(int.TryParse(menuchoice2, out int resultStudent)){
                                if(resultStudent==1){
                                    studentHelper.NewStudent();
                                }
                                else if(resultStudent==2){
                                    courseHelper.AddStudent();
                                }
                                else if(resultStudent==3){
                                    courseHelper.RemoveStudent();
                                }
                                else if(resultStudent==4){
                                    studentHelper.SearchStudents();
                                }
                                else if(resultStudent==5){
                                    studentHelper.UpdateStudent();
                                }
                                else if(resultStudent==6){
                                    studentHelper.ListAllStudents();
                                }
                                else if(resultStudent==7){
                                    studentHelper.ListEnrolledCourses();
                                }
                            }
                        }
                        else if(resultMenu==2){//Course Menu Options
                            Console.WriteLine("Select an option:\n\n1) Create a new course\n2) Search for a course");
                            Console.WriteLine("3) Update a course's information\n4) List all courses\n5) Create an assignment for a course");
                            Console.WriteLine("6) Add student to a course\n7) Remove student from a course\n8) List students enrolled in a course");
                            var menuchoice3 = Console.ReadLine();

                            if(int.TryParse(menuchoice3, out int result)){
                                if(result==1){
                                courseHelper.NewCourse();
                                Console.WriteLine("Course created!");
                                }
                                else if(result==2){
                                    courseHelper.SearchCourses();
                                }
                                else if(result==3){
                                    courseHelper.UpdateCourse();
                                }
                                else if(result==4){
                                    courseHelper.ListAllCourses();
                                }
                                else if(result==5){
                                    Console.WriteLine("Select a course to add an assignment to:");
                                    courseHelper.ListAllCourses();
                                    var selectcourse = Console.ReadLine();

                                    if(int.TryParse(selectcourse, out int result2))
                                        courseHelper.AddAssignment(false, result2);
                                }
                                else if(result == 6){
                                    courseHelper.AddStudent();
                                }
                                else if(result == 7){
                                    courseHelper.RemoveStudent();
                                }
                                else if(result == 8){
                                    courseHelper.ListEnrolledStudents();
                                }
                            }

                        }
                        
                    }
                    
                }while(int.TryParse(menuchoice1, out int menuloop) && menuloop != 3);//Terminate program
        }
    }
}

       /*
    Functional requirements:

    - Create a course and add it to a list of courses ✓
    - Create a student and add it to a list of students ✓
    - Add a student from the list of students to a specific course ✓
    - Remove a student from a course’s roster ✓
    - List all courses ✓
    - Search for courses by name or description ✓
    - List all students ✓
    - Search for a student by name ✓
    - List all courses a student is taking ✓
    - Update a course’s information ✓
    - Update a student’s information ✓
    - Create an assignment and add it to the list of assignments for a course ✓
    - When selected from a list or search results, a course should show all its information. Only the course code and name should show in the lists. ✓
*/