using StampingRobot.Service.BussinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.Services.Interface
{
    public interface IOtpService
    {
        Task<OtpModel> AddNewOtp(string email);

        Task<bool> VerifyOtp(string email, int OtpCode);
    }
}
