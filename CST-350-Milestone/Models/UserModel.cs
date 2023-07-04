using System.ComponentModel.DataAnnotations;

namespace CST_350_Milestone.Models
{
    public class UserModel
    {
        // Takes First Name, Last Name, Sex, Age, State, Email Address, Username, and Password as form fields.

        public int Id { get; set; }

        [Required]
        public string firstName { get; set; }
        
        [Required]
        public string lastName { get; set; }
        
        [Required]
        public string sex { get; set; }
        
        [Required]
        public int age { get; set; }
        
        [Required]
        public string state { get; set; }
        
        [Required]
        public string email { get; set; }
        
        [Required]
        public string username { get; set; }
        
        [Required]
        public string password { get; set; }
    }
}
