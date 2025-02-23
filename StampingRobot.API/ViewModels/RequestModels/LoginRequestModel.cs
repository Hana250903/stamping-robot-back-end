using System.ComponentModel.DataAnnotations;

namespace StampingRobot.API.ViewModels.RequestModels
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;
    }

    public class LogoutRequestModel
    {
        [Required(ErrorMessage = "AccessToken is required")]
        public string AccessToken { get; set; } = "";

        [Required(ErrorMessage = "RefreshToken is required")]
        public string RefreshToken { get; set; } = "";
    }
}
