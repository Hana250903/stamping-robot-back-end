using Microsoft.Extensions.Caching.Memory;
using StampingRobot.Service.BussinessModels;
using StampingRobot.Service.Services.Interface;
using StampingRobot.Service.Ultils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.Services
{
    public class OtpService : IOtpService
    {
        private readonly IMemoryCache _memoryCache;

        public OtpService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<OtpModel> AddNewOtp(string email)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime currentTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);  
            var otp = new OtpModel
            {
                Email = email,
                OTPCode = StringUltils.GenerateNumber(6),
                OTPTime = currentTime.AddMinutes(5)
            };

            _memoryCache.Set(email, otp, TimeSpan.FromMinutes(5));

            //Trả đối tượng otp về cho controller(không phụ thuộc cache)
            return Task.FromResult(otp);
        }

        public Task<bool> VerifyOtp(string email, int OtpCode)
        {
            if (_memoryCache.TryGetValue(email, out OtpModel otp))
            {
                //Kiểm tra mã otp có trùng với mã otp trong cache không
                if (otp.OTPCode == OtpCode && otp.OTPTime >= DateTime.UtcNow)
                {
                    //Nếu trùng thì xóa otp trong cache
                    _memoryCache.Remove(email);
                    return Task.FromResult(true);
                }
            }
            return Task.FromResult(false);
        }
    }
}
