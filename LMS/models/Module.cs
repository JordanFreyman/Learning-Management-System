namespace Library.LMS.Models{
    public class Module{
        public string Name{get; set;}
        public string Description{get; set;}
        public List<ContentItem> Content{get; set;}
        
        public Module(){
            Name = string.Empty;
            Description = string.Empty;
            Content = new List<ContentItem>();
        }
    }
}