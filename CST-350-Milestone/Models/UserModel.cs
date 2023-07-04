using System.ComponentModel.DataAnnotations;

namespace CST_350_Milestone.Models
{
    public class UserModel
    {
        // Takes First Name, Last Name, Sex, Age, State, Email Address, Username, and Password as form fields.

        public int Id { get; set; }

        public string firstName { get; set; }
        
        public string lastName { get; set; }
        
        public string sex { get; set; }
        
        public int age { get; set; }
        
        public string state { get; set; }
        
        public string email { get; set; }
        
        [Required]
        public string username { get; set; }
        
        [Required]
        public string password { get; set; }
    }
}
