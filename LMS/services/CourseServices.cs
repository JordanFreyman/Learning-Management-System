using Library.LMS.Models;
using Library.LMS.Helper;

namespace Library.LMS.Services{
    public class CourseService{
        public List<Course> CourseList;
        private static CourseService? _instance;

        public static CourseService Current{
            get{
                if(_instance == null){
                    _instance = new CourseService();
                }
                return _instance;
            }
        }
        
        private CourseService(){
            CourseList = new List<Course>();
        }
        public void Add(Course course){
            CourseList.Add(course);
            course.courseNum = CourseList.Count;
        }
        public IEnumerable<Course> Search(string query, int choice){
            if(choice == 1){
                return CourseList.Where(c => c.Code.ToUpper().Contains(query.ToUpper()));
            }
            else if(choice == 2){
                return CourseList.Where(c => c.Name.ToUpper().Contains(query.ToUpper()));
            }
            else{
                return CourseList.Where(c => c.Description.ToUpper().Contains(query.ToUpper()));
            }
        }
    }
}