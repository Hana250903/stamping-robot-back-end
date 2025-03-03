using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StamingRobot.Repository.Commons;
using StampingRobot.API.ViewModels.RequestModels;
using StampingRobot.API.ViewModels.ResponseModels;
using StampingRobot.Service.BussinessModels;
using StampingRobot.Service.Services;
using StampingRobot.Service.Services.Interface;
using StampingRobot.Service.Ultils;

namespace StampingRobot.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICurentUserService _curentUserService;

        public UserController(IUserService userService, ICurentUserService curentUserService)
        {
            _userService = userService;
            _curentUserService = curentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserWithFilter([FromQuery] PaginationParameter paginationParameter, [FromQuery] FilterUser filterUser)
        {
            try
            {
                var result = await _userService.GetUserPagination(paginationParameter, filterUser);

                if (result != null)
                {
                    var metadata = new
                    {
                        result.TotalCount,
                        result.PageSize,
                        result.CurrentPage,
                        result.TotalPages,
                        result.HasNext,
                        result.HasPrevious
                    };

                    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                    return Ok(result);
                }
                else
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "User is empty"
                    });
                }
            }
            catch (Exception ex)
            {
                var responseModel = new ResponseModel()
                {
                    HttpCode = StatusCodes.Status404NotFound,
                    Message = ex.Message
                };
                return BadRequest(responseModel);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            try
            {
                var user = await _userService.GetUserById(Id);

                if (user == null)
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "User not exist"
                    });
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode= StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody]UserUpdateRequestModel updateUserModel)
        {
            try
            {
                var userId = _curentUserService.GetUserId();

                var user = new UserModel
                {
                    Id = userId,
                    FullName = updateUserModel.FullName,
                    Phone = updateUserModel.Phone
                };

                var result = await _userService.UpdateUser(user);
                if(result != null)
                {
                    return Ok(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Update user success"
                    });
                }
                else
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "User not exist"
                    });
                }
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            try
            {
                var result = await _userService.DeleteUser(Id);
                if (result)
                {
                    return Ok(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Delete user success"
                    });
                }
                else
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "User not exist"
                    });
                }
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
