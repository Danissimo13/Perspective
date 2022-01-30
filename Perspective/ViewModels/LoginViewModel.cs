using System.ComponentModel.DataAnnotations;

namespace Perspective.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
