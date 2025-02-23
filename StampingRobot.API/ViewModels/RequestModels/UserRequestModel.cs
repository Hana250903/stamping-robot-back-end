using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StampingRobot.API.ViewModels.RequestModels
{
    public class UserUpdateRequestModel
    {
        [Required(ErrorMessage = "FullName is required")]
        [Display(Name = "FullName")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Phone is required")]
        [Display(Name = "Phone")]
        public string Phone { get; set; } = null!;
    }

    public class UserPasswordRequestModel
    {
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;
    }

    public class ChangePasswordRequestModel
    {
        [Required(ErrorMessage = "OldPassword is required")]
        [Display(Name = "OldPassword")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; } = "";
        [Required(ErrorMessage = "NewPassword is required")]
        [Display(Name = "NewPassword")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = "";

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; } = "";
    }

    public class ForgotPasswordRequestModel
    {
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        public string Password { get; set; } = "";

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = "";
    }

}
