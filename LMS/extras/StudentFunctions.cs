namespace LMS.Services{
    public class StudentFunctions{
        /*private IList<Person> AllStudents;
        private object lock;
        private string query;
        private static StudentFunctions instance;
        public static StudentFunctions Current{
            get{
                lock(lock){
                    if(instance == null){
                        instance = new StudentFunctions();
                    }    
                }
                
                return instance;
            }
        }
        //IList is a generic type of list, which stands for "Interface List".
        //.where function ?? <- use for search function
        public IList<Person> Students{
            get{
                return AllStudents.ToList().Where{
                    c =>
                        c.Name.ToUpper().Contains(query)
                        || c.Code.ToUpper().Contains(query)};
                }
            }
        }

        public IList<Person> SearchStudents(string query){
            this.query = query;
            return Students;
        }

        private StudentFunctions{
            AllStudents = new List<Person>();
        }
        public Person createNewStudent(){
            Console.WriteLine("Enter name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Enter year (number): ");
            var classification = Console.ReadLine();

            var newStudent = new Person{Name = name ?? string.Empty, Classification = int.Parse(classification ?? "0")};
            
            return newStudent;
        }*/
    }
}