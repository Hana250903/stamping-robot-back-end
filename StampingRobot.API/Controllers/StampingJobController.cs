using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using Newtonsoft.Json;
using StamingRobot.Repository.Commons;
using StampingRobot.API.Hubs;
using StampingRobot.API.ViewModels.RequestModels;
using StampingRobot.API.ViewModels.ResponseModels;
using StampingRobot.Service.BussinessModels;
using StampingRobot.Service.Services;
using StampingRobot.Service.Services.Interface;
using StamingRobot.Repository.Entities;

namespace StampingRobot.API.Controllers
{
    [Route("api/stamping-jobs")]
    [ApiController]
    public class StampingJobController : ControllerBase
    {
        private readonly IStampingJobService _stampingJobService;
        private readonly IHubContext<RobotHub> _hubContext;

        public StampingJobController(IStampingJobService stampingJobService, IHubContext<RobotHub> hubContext)
        {
            _stampingJobService = stampingJobService;
            _hubContext = hubContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetStampingJobPaging([FromQuery] PaginationParameter paginationParameter, [FromQuery] FilterStampingJob filterStampingJob)
        {
            try
            {
                var result = await _stampingJobService.GetStampingJobPagination(paginationParameter, filterStampingJob);

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
                        Message = "Stamping job is empty"
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

        [HttpGet("{Id}")]
        [Authorize]
        public async Task<IActionResult> GetStampingJobById(int Id)
        {
            try
            {
                var result = await _stampingJobService.GetStampingJobByIdAsync(Id);
                if (result == null)
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "Stamping job not found"
                    });
                }
                return Ok(result);
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
        public async Task<IActionResult> CreateStampingJob([FromBody] List<CreateStampingJobRequestModel> createStampingJobRequestModel)
        {
            try
            {
                List<StampingJobModel> stampingJobModel = createStampingJobRequestModel.Select(c => new StampingJobModel
                {
                    StepNumber = c.StepNumber,
                    Description = c.Description,
                    SessionId = c.SessionId,
                    Action = c.Action
                }).ToList();

                var result = await _stampingJobService.CreateStampingJobAsync(stampingJobModel);

                if (result)
                {
                    return Ok(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Stamping process created successfully"
                    });
                }
                else
                {
                    return BadRequest(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status400BadRequest,
                        Message = "Stamping process created failed"
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
        public async Task<IActionResult> UpdateStampingJob(int id, [FromBody] UpdateStampingJobRequestModel updateStampingJobRequestModel)
        {
            try
            {
                StampingJobModel stampingJobModel = new StampingJobModel
                {
                    Id = id,
                    Description = updateStampingJobRequestModel.Description,
                    Status = updateStampingJobRequestModel.Status,
                    Action = updateStampingJobRequestModel.Action
                };

                var result = await _stampingJobService.UpdateStampingJobAsync(stampingJobModel);

                if (result)
                {
                    return Ok(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Update successfull"
                    });
                }
                else
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "Stamping Job not exist"
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
        public async Task<IActionResult> DeleteStampingJob(int id)
        {
            try
            {
                var result = await _stampingJobService.DeleteStampingJobAsync(id);
                if (result)
                {
                    return Ok(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Delete successfully"
                    });
                }
                else
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode= StatusCodes.Status404NotFound,
                        Message = "Stamping Job not found"
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            try
            {
                var result = await _stampingJobService.UpdateStatus(id, status);

                if (result)
                {
                    return Ok(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Update status successfully"
                    });
                }
                return NotFound(new ResponseModel
                {
                    HttpCode = StatusCodes.Status404NotFound,
                    Message = "Stamping session not found"
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
    }
}
