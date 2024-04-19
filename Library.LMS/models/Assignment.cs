namespace Library.LMS.Models{
    public class Assignment{
        public string Name{get; set;}
        public string Description{get; set;}
        public int TotalAvailablePoints{get; set;}
        public DateTime DueDate{get; set;}

        public Assignment(){
            Name = string.Empty;
            Description = string.Empty;
            TotalAvailablePoints = 100;
            DueDate = DateTime.Parse("01/01/1900");
        }
        public override string ToString()
        {
            return $"{Name} - {Description}\n{TotalAvailablePoints} pts\t{DueDate}";
        }
    }
}