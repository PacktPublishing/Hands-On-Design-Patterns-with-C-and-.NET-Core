using System.ComponentModel.DataAnnotations;

namespace SimpleLogin.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me on current System")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }

    }

    public class RegisterViewModel
    {
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailId { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Mobile { get; set; }
    }
}
