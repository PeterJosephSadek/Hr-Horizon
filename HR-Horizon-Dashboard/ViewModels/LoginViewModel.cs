using System.ComponentModel.DataAnnotations;

namespace HR_Horizon_Dashboard.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Enter your username")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; } = string.Empty;
    }
}
