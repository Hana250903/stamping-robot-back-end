using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Newtonsoft.Json;
using StampingRobot.API.ViewModels.RequestModels;
using StampingRobot.API.ViewModels.ResponseModels;
using StampingRobot.Service.BussinessModels;
using StampingRobot.Service.Services;
using StampingRobot.Service.Services.Interface;
using StampingRobot.Service.Ultils;

namespace StampingRobot.API.Controllers
{
    [Route("api/authen")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICurentUserService _curentUserService;
        private readonly IOtpService _otpService;

        public AuthenController(IUserService userService, ICurentUserService curentUserService, IOtpService otpService)
        {
            _userService = userService;
            _curentUserService = curentUserService;
            _otpService = otpService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] RegisterModel registerModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userService.RegisterAsync(registerModel);
                    
                    var response = new ResponseModel
                    {
                        HttpCode = StatusCodes.Status201Created,
                        Message = "Create user successfully!"
                    };
                    return Ok(response);
                }
                return ValidationProblem(ModelState);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                };

                return BadRequest(response);
            }
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginWithEmail([FromBody] LoginRequestModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var result = await _userService.LoginByEmailAndPassword(loginModel.Email, loginModel.Password);
                    if (result.HttpCode == StatusCodes.Status200OK)
                    {
                        return Ok(result);
                    }
                    return Unauthorized(result);
                }
                return ValidationProblem(ModelState);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                };
                return BadRequest(response);
            }
        }

        [HttpPost("refesh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            try
            {
                var result = await _userService.RefreshToken(refreshToken);
                if (result.HttpCode == StatusCodes.Status200OK)
                {
                    return Ok(result);
                }
                return Unauthorized(result);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                };
                return BadRequest(response);
            }
        }

        [HttpPost("login-google")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] string credential)
        {
            try
            {
                var result = await _userService.LoginWithGoogle(credential);
                if (result.HttpCode == StatusCodes.Status200OK)
                {
                    return Ok(result);
                }
                return Unauthorized(result);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                };
                return BadRequest(response);
            }
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOTP([FromBody] string email)
        {
            try
            {
                var userId = _curentUserService.GetUserId();

                var result = await _userService.SendOTPEmail(email, userId);
                
                var response = new ResponseModel
                {
                    HttpCode = StatusCodes.Status200OK,
                    Message = "Send OTP successfully!"
                };
                return Ok(response);

            }
            catch (Exception ex)
            {
                var response = new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                };
                return BadRequest(response);
            }
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOTP([FromBody] OTPRequestModel verifyOTPModel)
        {
            try
            {
                var result = await _otpService.VerifyOtp(verifyOTPModel.Email, verifyOTPModel.OTPCode);
                if (result)
                {
                    var response = new ResponseModel
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Verify OTP successfully!"
                    };
                    return Ok(response);
                }
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = "OTP is invalid!"
                });
            }
            catch (Exception ex)
            {
                var response = new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                };
                return BadRequest(response);
            }   
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(string refreshToken)
        {
            try
            {
                var userId = _curentUserService.GetUserId();

                var result = await _userService.LogOut(refreshToken, userId);
                
                return Ok(new ResponseModel
                {
                    HttpCode = StatusCodes.Status200OK,
                    Message = "Logout successfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                });
            }
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestModel changePasswordModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = _curentUserService.GetUserId();

                    var result = await _userService.ChangePasswordUserRoleAsync(new ChangePasswordModel
                    {
                        Id = userId,
                        OldPassword = changePasswordModel.OldPassword,
                        NewPassword = changePasswordModel.NewPassword,
                        ConfirmPassword = changePasswordModel.ConfirmPassword
                    });

                    if (result == true)
                    {
                        return Ok(new ResponseModel
                        {
                            HttpCode = StatusCodes.Status200OK,
                            Message = "Change password successfully!"
                        });
                    }
                    else
                    {
                        return BadRequest(new ResponseModel
                        {
                            HttpCode = StatusCodes.Status400BadRequest,
                            Message = "Change password failed!"
                        });
                    }
                }
                return ValidationProblem(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                });
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestModel password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = _curentUserService.GetUserId();

                    var result = await _userService.ForgotPassword(new ForgotPasswordModel
                    {
                        Id = userId,
                        Password = password.Password,
                        ConfirmPassword = password.ConfirmPassword
                    });

                    if (result == true)
                    {
                        return Ok(new ResponseModel
                        {
                            HttpCode = StatusCodes.Status200OK,
                            Message = "Forgot password successfully!"
                        });
                    }
                    else
                    {
                        return BadRequest(new ResponseModel
                        {
                            HttpCode = StatusCodes.Status400BadRequest,
                            Message = "Forgot password failed!"
                        });
                    }
                }
                return ValidationProblem(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                });
            }
        }
    }
}
