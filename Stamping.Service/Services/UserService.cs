using AutoMapper;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StamingRobot.Repository.Commons;
using StamingRobot.Repository.Entities;
using StamingRobot.Repository.Enum;
using StamingRobot.Repository.Repositories;
using StamingRobot.Repository.Repositories.Interface;
using StamingRobot.Repository.UnitOfWork;
using StamingRobot.Repository.UnitOfWork.Interface;
using StampingRobot.Service.BussinessModels;
using StampingRobot.Service.Helpers;
using StampingRobot.Service.Services.Interface;
using StampingRobot.Service.Ultils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOtpService _otp;
        private readonly IMailService _mailService;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration, IUnitOfWork unitOfWork, IOtpService otp, IMailService mailService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _otp = otp;
            _mailService = mailService;
        }

        public async Task<Pagination<User>> GetAllUserPagination(PaginationParameter paginationParameter, FilterUser filterUser)
        {
            var list = await _userRepository.GetAllUserWithFilter(filterUser);

            var result = list.Skip((paginationParameter.PageIndex - 1) * paginationParameter.PageSize)
                .Take(paginationParameter.PageSize)
                .ToList();

            return new Pagination<User>(result, list.Count, paginationParameter.PageIndex, paginationParameter.PageSize);
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            var userModel = _mapper.Map<User>(user);

            return userModel;
        }

        #region Authen
        public async Task<bool?> ChangePasswordUserRoleAsync(ChangePasswordModel model)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(model.Id);

                if (user == null)
                {
                    throw new Exception("User is not exist");
                }

                var checkPassword = PasswordUltils.VerifyPassword(model.OldPassword, user.Password);

                if (checkPassword)
                {
                    if (model.OldPassword.Equals(model.NewPassword))
                    {
                        throw new Exception("New password is same old password");
                    }
                    else
                    {
                        var passwordHash = PasswordUltils.HashPassword(model.NewPassword);
                        user.Password = passwordHash;
                        await _userRepository.UpdateAsync(user);
                        await _unitOfWork.SaveChanges();
                        return true;
                    }
                }

                throw new Exception("Password incorrect");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ForgotPassword(ForgotPasswordModel model)
        {
            var user = await _userRepository.GetByIdAsync(model.Id);
            if (user == null)
            {
                return false;
            }

            var hashPassword = PasswordUltils.HashPassword(model.Password);
            user.Password = hashPassword;
            await _userRepository.UpdateAsync(user);
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<AuthenModel> LoginByEmailAndPassword(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return new AuthenModel
                {
                    HttpCode = 401,
                    Message = "Email is not exist"
                };
            }
            else
            {
                if (user.IsDeleted)
                {
                    return new AuthenModel
                    {
                        HttpCode = 401,
                        Message = "User is deleted"
                    };
                }

                var checkPassword = PasswordUltils.VerifyPassword(password, user.Password);
                if (checkPassword)
                {
                    var assetToken = await GenerateAccessToken(user);
                    var refreshToken = GenerateRefreshToken(email);

                    user.RefreshToken = refreshToken;

                    await _userRepository.UpdateAsync(user);
                    await _unitOfWork.SaveChanges();

                    return new AuthenModel
                    {
                        HttpCode = 200,
                        AccessToken = assetToken,
                        RefreshToken = refreshToken,
                        Message = "Login success",
                    };
                }
                else
                {
                    return new AuthenModel
                    {
                        HttpCode = 401,
                        Message = "Password is incorrect"
                    };
                }
            }

        }

        public async Task<AuthenModel> LoginWithGoogle(string credential)
        {
            await _unitOfWork.BeginTransactionAsync();
            string clientId = _configuration["Google:ClientId"];

            var setting = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new List<string> { clientId }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(credential, setting);

            if (payload == null)
            {
                throw new Exception("Invalid credential");
            }

            var user = await _userRepository.GetUserByEmail(payload.Email);

            if (user != null)
            {
                if (user.IsDeleted)
                {
                    return new AuthenModel
                    {
                        HttpCode = 401,
                        Message = "User is deleted"
                    };
                }

                var accessToken = await GenerateAccessToken(user);
                var refreshToken = GenerateRefreshToken(user.Email);

                user.RefreshToken = refreshToken;

                await _userRepository.UpdateAsync(user);
                await _unitOfWork.SaveChanges();

                return new AuthenModel
                {
                    HttpCode = 200,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    Message = "Login success",
                };
            }
            else
            {
                try
                {
                    User newUser = new User
                    {
                        FullName = payload.Name,
                        Email = payload.Email,
                        IsDeleted = false,
                        GoogleId = payload.JwtId,
                        Role = Role.Employee,
                        Phone = "".Trim(),
                    };

                    var acessToken = await GenerateAccessToken(newUser);
                    var refeshToken = GenerateRefreshToken(newUser.Email);

                    newUser.RefreshToken = refeshToken;

                    await _userRepository.AddAsync(newUser);

                    var result = await _unitOfWork.SaveChanges();

                    if (result > 0)
                    {
                        await _unitOfWork.CommitTransactionAsync();
                        return new AuthenModel
                        {
                            HttpCode = 200,
                            AccessToken = acessToken,
                            RefreshToken = refeshToken,
                            Message = "Login success",
                        };
                    }

                    throw new Exception("Login error");
                }
                catch (Exception e)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    throw e;
                }
            }
        }
        public async Task<bool> LogOut(string refreshToken, int userId)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var handler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = authSigningKey,
                ValidateIssuer = true,
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                ValidateAudience = true,
                ValidAudience = _configuration["JWT:ValidAudience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            }; 
            try
            {
                SecurityToken validationToken;
                var principal = handler.ValidateToken(refreshToken, validationParameters, out validationToken);
                var email = principal.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
                if (email != null)
                {
                    var existUser = await _userRepository.GetUserByEmail(email);
                    if (existUser != null)
                    {
                        if (existUser.RefreshToken != refreshToken)
                        {
                            throw new Exception("Refresh Token can not use");
                        }
                        existUser.RefreshToken = null;
                        await _userRepository.UpdateAsync(existUser);
                        await _unitOfWork.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AuthenModel> RefreshToken(string jwtToken)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var handler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = authSigningKey,
                ValidateIssuer = true,
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                ValidateAudience = true,
                ValidAudience = _configuration["JWT:ValidAudience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                SecurityToken validatedToken;
                var principal = handler.ValidateToken(jwtToken, validationParameters, out validatedToken);
                var email = principal.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
                if (email != null)
                {
                    var existUser = await _userRepository.GetUserByEmail(email);

                    if (existUser != null)
                    {
                        if (existUser.RefreshToken != jwtToken || validatedToken.ValidTo < DateTime.UtcNow.AddHours(7))
                        {
                            throw new Exception("Refresh Token can not use");
                        }

                        var accessToken = await GenerateAccessToken(existUser);
                        var refreshToken = GenerateRefreshToken(email);
                        return new AuthenModel
                        {
                            HttpCode = 200,
                            Message = "Refresh token successfully",
                            AccessToken = accessToken,
                            RefreshToken = refreshToken
                        };
                    }
                }

                return new AuthenModel
                {
                    HttpCode = 401,
                    Message = "Email is not exist"
                };
            }
            catch (Exception ex)
            {
                return new AuthenModel
                {
                    HttpCode = 401,
                    Message = ex.Message
                };
            }
        }

        public async Task<bool> RegisterAsync(RegisterModel model)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                User newUser = new User
                {
                    FullName = model.FullName,
                    Phone = model.PhoneNumber,
                    Email = model.Email,
                };

                var checkEmail = await _userRepository.GetUserByEmail(newUser.Email);

                if (checkEmail != null)
                {
                    throw new Exception("Email is existed");
                }

                newUser.Password = PasswordUltils.HashPassword(model.Password);

                switch (model.Role)
                {
                    case 1:
                        newUser.Role = Role.Employee;
                        break;
                    case 2:
                        newUser.Role = Role.Admin;
                        break;
                    default:
                        throw new Exception($"Invalid role: {model.Role}");
                }

                await _userRepository.AddAsync(newUser);

                var result = await _unitOfWork.SaveChanges();
                await _unitOfWork.CommitTransactionAsync();
                return true;
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<bool> SendOTPEmail(string email, int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User is not exist");
            }
            else if (user.Email != email)
            {
                throw new Exception("Email is not match");
            }

            var otp = await _otp.AddNewOtp(email);

            var mail = new MailRequest
            {
                ToEmail = email,
                Subject = "OTP Code reset password",
                Body = MailContent.EmailOtpContent(user.FullName, otp.OTPCode)
            };

            await _mailService.SendEmailAsync(mail);
            return true;
        }

        #endregion

        private async Task<string> GenerateAccessToken(User user)
        {
            var authClaims = new List<Claim>();

            authClaims.Add(new Claim("email", user.Email.ToString()));
            authClaims.Add(new Claim("fullname", user.FullName.ToString()));
            authClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            //authClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            authClaims.Add(new Claim("user_ID", user.Id.ToString()));
            authClaims.Add(new Claim("role", user.Role.ToString()));
            var accessToken = GenerateJWTToken.CreateToken(authClaims, _configuration, DateTime.UtcNow);
            return new JwtSecurityTokenHandler().WriteToken(accessToken);
        }

        private string GenerateRefreshToken(string email)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim("email", email.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var refreshToken = GenerateJWTToken.CreateRefreshToken(claims, _configuration, DateTime.UtcNow);
            return new JwtSecurityTokenHandler().WriteToken(refreshToken).ToString();
        }
    }
}
