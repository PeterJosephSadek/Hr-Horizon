using System.ComponentModel.DataAnnotations;

namespace HR_Horizon_Dashboard.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Username Required")]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage ="Enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Doesn't Match")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        public string Role { get; set; } = null!;
    }
}
