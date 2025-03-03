using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StamingRobot.Repository.Commons;
using StampingRobot.API.ViewModels.RequestModels;
using StampingRobot.API.ViewModels.ResponseModels;
using StampingRobot.Service.BussinessModels;
using StampingRobot.Service.Services;
using StampingRobot.Service.Services.Interface;

namespace StampingRobot.API.Controllers
{
    [Route("api/stamping-jobs")]
    [ApiController]
    public class StampingJobController : ControllerBase
    {
        private readonly IStampingJobService _stampingJobService;

        public StampingJobController(IStampingJobService stampingJobService)
        {
            _stampingJobService = stampingJobService;
        }

        [HttpGet]
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
        public async Task<IActionResult> CreateStampingJob([FromBody] CreateStampingJobRequestModel createStampingJobRequestModel)
        {
            try
            {
                var stampingJobModel = new StampingJobModel
                {
                    StepNumber = createStampingJobRequestModel.StepNumber,
                    Description = createStampingJobRequestModel.Description,
                    SessionId = createStampingJobRequestModel.SessionId,
                    Status = createStampingJobRequestModel.Status,
                    Parameters = createStampingJobRequestModel.Parameters
                };

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
        public Task<IActionResult> UpdateStampingJob(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteStampingJob(int id)
        {
            throw new NotImplementedException();
        }
    }
}
