﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.BussinessModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Must be email format!")]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Fullname is required")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = "";

        [Required(ErrorMessage = "Phone number is required!")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number!")]
        [RegularExpression(@"^0([0-9]{9})$", ErrorMessage = "Invalid Phone Number!")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(12, MinimumLength = 7, ErrorMessage = "Password must be 7-12 Character")]
        [PasswordPropertyText]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Role is required")]
        public int Role { get; set; }
    }
}
