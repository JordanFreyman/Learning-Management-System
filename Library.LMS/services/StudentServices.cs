using Library.LMS.Models;


namespace Library.LMS.Services{
    public class StudentService{
        public List<Person> AllStudents = new List<Person>();
        public void Add(Person person){
            AllStudents.Add(person);
            person.studentNumber = AllStudents.Count;
        }
        public IEnumerable<Person> Search(string query){
            return AllStudents.Where(s => s.Name.ToUpper().Contains(query.ToUpper()));
        }
    }
}