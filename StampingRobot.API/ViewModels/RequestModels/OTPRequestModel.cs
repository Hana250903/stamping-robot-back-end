using System.ComponentModel.DataAnnotations;

namespace StampingRobot.API.ViewModels.RequestModels
{
    public class OTPRequestModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "OTP is required")]
        [Display(Name = "OTP")]
        public int OTPCode { get; set; } = 0;
    }
}
