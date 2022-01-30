using System.ComponentModel.DataAnnotations;

namespace Perspective.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid format Email address.")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Minimal length of Password is 8.")]
        public string Password { get; set; }
    }
}
