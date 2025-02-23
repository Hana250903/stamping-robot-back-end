using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace StampingRobot.Service.Helpers
{
    public class MailContent
    {
        public static string EmailOtpContent(string userName, int otpCode)
        {
            return "<div style=\"background-color:#f8f8f8;font-family:sans-serif;padding:15px\">"
        + "    <div style=\"max-width:600px;margin:auto;background:white;padding:20px;border-radius:10px;box-shadow:0px 0px 10px rgba(0,0,0,0.1);\">"
        + "        <h2 style=\"color:#333;text-align:center;\">Mã OTP của bạn</h2>"
        + "        <p>Xin chào <strong>" + userName + "</strong>,</p>"
        + "        <p>Bạn vừa yêu cầu mã OTP để khôi phục mật khẩu của mình.</p>"
        + "        <div style=\"text-align:center;margin:20px 0;\">"
        + "            <span style=\"font-size:24px;font-weight:bold;color:#ff6600;background:#f3f3f3;padding:10px 20px;border-radius:5px;display:inline-block;\">" + otpCode + "</span>"
        + "        </div>"
        + "        <p>Mã này sẽ hết hạn sau 5 phút. Nếu bạn không yêu cầu, vui lòng bỏ qua email này.</p>"
        + "        <p style=\"margin-top:20px;font-size:14px;color:#666;\">Trân trọng,<br>Đội ngũ hỗ trợ</p>"
        + "    </div>"
        + "</div>";
        }
    }
}
