using Microsoft.AspNetCore.Http;
using StamingRobot.Repository.Entities;
using StamingRobot.Repository.Repositories.Interface;
using StamingRobot.Repository.UnitOfWork;
using StamingRobot.Repository.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.Ultils
{
    public interface ICurentUserService
    {
        public int GetUserId();

        String GetUserEmail();

        Task<User?> GetCurentAccount();
    }

    public class CurentUserService : ICurentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public CurentUserService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }
        public async Task<User?> GetCurentAccount()
        {
            int userId = GetUserId();
            var account = await _unitOfWork.UserRepository.GetByIdAsync(userId);

            return account;
        }

        public string GetUserEmail()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst("email")?.Value;
        }

        public int GetUserId()
        {
            try
            {
                return int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("user_ID")?.Value);
            }
            catch
            {
                throw new Exception("User not found");
            }
        }
    }
}
