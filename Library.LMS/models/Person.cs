namespace Library.LMS.Models{
    public class Person{
        public string Name{get; set;}
        public int Classification{get; set;}
        public Dictionary<int, double> Grades{get; set;}
        public int studentNumber{get; set;}
        
        public Person(){
            Name = string.Empty;
            Grades = new Dictionary<int, double>();
        }

        public override string ToString()
        {
            string c;
            if(Classification == 1)
                c = "Freshman";
            else if(Classification == 2)
                c = "Sophomore";
            else if(Classification == 3)
                c = "Junior";
            else if(Classification == 4)
                c = "Senior";
            else
                c = "Other";
            
            return $"{Name} - {c}";
        }

    }
}