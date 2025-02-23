using StamingRobot.Repository.Commons;
using StamingRobot.Repository.Entities;
using StampingRobot.Service.BussinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.Services.Interface
{
    public interface IUserService
    {
        Task<Pagination<User>> GetAllUserPagination(PaginationParameter paginationParameter, FilterUser filterUser);

        Task<User> GetUserById(int id);

        #region Authen
        public Task<AuthenModel> LoginByEmailAndPassword(string email, string password);

        public Task<bool> RegisterAsync(RegisterModel model);

        public Task<AuthenModel> RefreshToken(string jwtToken);

        public Task<bool> SendOTPEmail(string email, int userId);

        public Task<bool> ForgotPassword(ForgotPasswordModel model);

        public Task<bool?> ChangePasswordUserRoleAsync(ChangePasswordModel model);

        public Task<AuthenModel> LoginWithGoogle(string credential);

        public Task<bool> LogOut(string refreshToken, int userId);

        #endregion
    }
}
