using Microsoft.AspNetCore.Authorization;
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
    [Route("api/stamping-sessions")]
    [ApiController]
    public class StampingSessionController : ControllerBase
    {
        private readonly IStampingSessionService _stampingSessionService;
        private readonly ICurentUserService _curentUserService;

        public StampingSessionController(IStampingSessionService stampingSessionService, ICurentUserService curentUserService)
        {
            _stampingSessionService = stampingSessionService;
            _curentUserService = curentUserService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetStampingSessionPaging([FromQuery] PaginationParameter paginationParameter, [FromQuery] FilterSession filterSession)
        {
            try
            {
                var result = await _stampingSessionService.GetStampingSessions(paginationParameter, filterSession);

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
                        Message = "Stamping session is empty"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetStampingSessionById(int id)
        {
            try
            {
                var result = await _stampingSessionService.GetStampingSessionById(id);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "Stamping session is not found"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{userId}/user")]
        [Authorize]
        public async Task<IActionResult> GetStampingSessionByUserId(int userId, [FromQuery] PaginationParameter paginationParameter, [FromQuery] FilterSession filterSession)
        {
            try
            {
                var result = await _stampingSessionService.GetStampingSessionsByUser(paginationParameter, filterSession, userId);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound(new ResponseModel
                {
                    HttpCode= StatusCodes.Status404NotFound,
                    Message = "User Id not found"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateStampingSession([FromBody] CreateStampingSessionRequestModel createStampingSession)
        {
            try
            {
                StampingSessionModel stampingSession = new StampingSessionModel
                {
                    Quantity = createStampingSession.Quantity,
                    UserId = _curentUserService.GetUserId(),
                    RobotId = createStampingSession.RobotId,
                    ProductId = createStampingSession.ProductId
                };

                var result = await _stampingSessionService.CreateStampingSession(stampingSession);

                if (result)
                {
                    return Ok(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Create stamping session successfully"
                    });
                }
                else
                {
                    return BadRequest(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status400BadRequest,
                        Message = "Create stamping session failed"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateStampingSession(int id, [FromBody] UpdateStampingSessionRequestModel updateStampingSession)
        {
            try
            {
                var stampingSession = await _stampingSessionService.GetStampingSessionById(id);
                if (stampingSession == null)
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "StampingSession not found"
                    });
                }

                var stampingSessionModel = new StampingSessionModel
                {
                    Id = id,
                    Quantity = updateStampingSession.Quantity,
                    Status = updateStampingSession.Status,
                    RobotId = updateStampingSession.RobotId,
                    ProductId = updateStampingSession.ProductId
                };

                var result = await _stampingSessionService.UpdateStampingSession(stampingSessionModel);

                if (result)
                {
                    return Ok(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Update stamping session successfully"
                    });
                }
                else
                {
                    return BadRequest(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status400BadRequest,
                        Message = "Update stamping session failed"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteStampingSession(int id)
        {
            try
            {
                var result = await _stampingSessionService.DeleteStampingSession(id);

                if (result)
                {
                    return Ok(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Delete stamping session successfully"
                    });
                }
                else
                {
                    return BadRequest(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status400BadRequest,
                        Message = "Delete stamping session failed"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
    }
}
