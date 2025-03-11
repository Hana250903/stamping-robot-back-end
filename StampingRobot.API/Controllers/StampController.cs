using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StamingRobot.Repository.Commons;
using StampingRobot.API.ViewModels.RequestModels;
using StampingRobot.API.ViewModels.ResponseModels;
using StampingRobot.Service.BussinessModels;
using StampingRobot.Service.Services.Interface;

namespace StampingRobot.API.Controllers
{
    [Route("api/stamps")]
    [ApiController]
    public class StampController : ControllerBase
    {
        private readonly IStampService _stampService;

        public StampController(IStampService stampService)
        {
            _stampService = stampService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetStampPaging([FromQuery] PaginationParameter paginationParameter, [FromQuery] FilterStamp filterStamp)   
        {
            try
            {
                var result = await _stampService.GetStamps(paginationParameter, filterStamp);
                if (result == null)
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "Stamp empty"
                    });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetStampById(int id)
        {
            try
            {
                var result = await _stampService.GetStampById(id);
                if (result == null)
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "Stamp not found"
                    });
                }
                return Ok(result);
            }
            catch (Exception ex )
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateStamp([FromBody] StampRequestModel stampRequestModel)
        {
            try
            {
                StampModel stampModel = new StampModel()
                {
                    Size = stampRequestModel.Size,
                    Type = stampRequestModel.Type,
                    InkColor = stampRequestModel.InkColor,
                };

                var result = await _stampService.CreateStamp(stampModel);
                if (result)
                {
                    return Ok(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Create stamp successfully"
                    });
                }
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = "Create failed"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message,
                });
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateStamp(int id, [FromBody] StampRequestModel stampRequestModel)
        {
            try
            {
                var stamp = await _stampService.GetStampById(id);
                if(stamp == null)
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "Stamp not found"
                    });
                }

                StampModel stampModel = new StampModel()
                {
                    Id = id,
                    Size = stampRequestModel.Size,
                    Type = stampRequestModel.Type,
                    InkColor = stampRequestModel.InkColor,
                };

                var result = await _stampService.UpdateStamp(stampModel);
                if (result)
                {
                    return Ok(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Update successfully"
                    });
                }
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = "Update failed"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message,
                });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteStamp(int id)
        {
            try
            {
                var result = await _stampService.DeleteStamp(id);
                if (result)
                {
                    return Ok(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Delete succesfully"
                    });
                }
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = "Delete failed"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message,
                });
            }
        }
    }
}
