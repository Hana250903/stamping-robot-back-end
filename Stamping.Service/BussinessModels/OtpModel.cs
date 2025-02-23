using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.BussinessModels
{
    public class OtpModel
    {
        public string Email { get; set; } = "";

        public int OTPCode { get; set; } = 0;

        public DateTime OTPTime { get; set; }
    }
}
