using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class UserModel
    {
        [DisplayName("User Id")]
        public int Id { get; set; }

        [DisplayName("User login")]
        [Required(ErrorMessage = "Please enter username")]
        [StringLength(25, MinimumLength = 5, 
            ErrorMessage = "Usernames's length must be between 5 and 25 characters")]
        public string UserName { get; set; }

        [DisplayName("User email")]
        [Required(ErrorMessage = "Please enter email")]
        [StringLength(25, MinimumLength = 5,
            ErrorMessage = "Email's length must be between 5 and 25 characters")]
        public string Email { get; set; }

        [DisplayName("User password")]
        [Required(ErrorMessage = "Please enter password")]
        [MinLength(8, ErrorMessage = "Password's length must be longer than 8 characters")]
        [MaxLength(50, ErrorMessage = "Password's length must be shorter than 8 characters")]
        public string Password { get; set; }

        [DisplayName("User first name")]
        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(25, MinimumLength = 2,
            ErrorMessage = "First name length must be between 2 and 25 characters")]
        public string FirstName { get; set; }

        [DisplayName("User last name")]
        [Required(ErrorMessage = "Please enter last name")]
        [StringLength(25, MinimumLength = 2,
            ErrorMessage = "Last name length must be between 2 and 25 characters")]
        public string LastName { get; set; }

    }
}
