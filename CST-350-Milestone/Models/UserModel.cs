using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CST_350_Milestone.Models
{
    public class UserModel
    {

        // Takes First Name, Last Name, Sex, Age, State, Email Address, Username, and Password as form fields.

        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        [MaxLength(50,ErrorMessage = "Please reduce first name to below 50 characters")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [MaxLength(50, ErrorMessage = "Please reduce last name to below 50 characters")]
        public string LastName { get; set; }

        [Required]
        public SexEnum? Sex { get; set; }

        [Required]
        [Range(13, 120, ErrorMessage = "Please input an age range of 13-120")]
        public int Age { get; set; }

        [Required]
        public StateEnum? State { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters")]
        public string Username { get; set; }
        
        [Required]
		[MaxLength(50, ErrorMessage = "Password cannot exceed 50 characters")]
		public string Password { get; set; }

        public override string ToString()
        {
            return String.Format("Username: {0}, Email: {1}", Username, Email);
        }
    }
}
