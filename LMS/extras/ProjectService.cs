/*using LMS.Models;

namespace LMS.Services{
    public class ProjectService{
        private static ProjectService instance;
        public static ProjectService Current{
            get {
                if(instance != null){
                    instance = new ProjectService();
                }
                else{
                    return instance;
                }
            }
        }
        private IList<Project> projects;
        private ProjectService(){
            projects = new List<Project>();
        }
        public IQueryable<Project> GetByStudent(Guid studentID){
            return projects.Where(p => p.StudentID == studentID);
        }
    }
}*/