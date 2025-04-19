using System.Collections.Generic;

namespace GymWebsite.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }  
        public string Title { get; set; }     
        public string ShortDescription { get; set; }  
        public string FullDescription { get; set; }   
        public List<string> Certifications { get; set; }  
        public string Contact { get; set; }  
    }
}
