using StamingRobot.Repository.Entities;
using StamingRobot.Repository.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.BussinessModels
{
    public class UserModel : BaseEntity
    {
        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int? CodeOtpemail { get; set; }

        public Role Role { get; set; }
    }

    public class ChangePasswordModel
    {
        public int Id { get; set; }

        public string? OldPassword { get; set; } = "";

        public string? NewPassword { get; set; } = "";

        public string? ConfirmPassword { get; set; } = "";
    }

    public class ForgotPasswordModel
    {
        public int Id {get; set;}
        public string Password { get; set; } = "";
        public string ConfirmPassword { get; set; } = "";
    }
}
