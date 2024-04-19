namespace Library.LMS.Models{
    public class Course{
        public string Code{get; set;}
        public string Name{get; set;}
        public string Description{get; set;}
        public List<Person> Roster{get; set;}
        public List<Assignment> Assignments{get; set;}
        public List<Module> Modules{get; set;}
        public int courseNum{get; set;}

        public Course(){
            Roster = new List<Person>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
            Code = string.Empty;
            Name = string.Empty;
            Description = string.Empty;

        }
        public override string ToString()
        {
            return $"({courseNum}) ({Code}) - {Name}";
        }
    }
}