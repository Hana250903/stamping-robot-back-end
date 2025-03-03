using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StamingRobot.Repository.Commons;
using StamingRobot.Repository.Entities;
using StampingRobot.API.ViewModels.RequestModels;
using StampingRobot.API.ViewModels.ResponseModels;
using StampingRobot.Service.BussinessModels;
using StampingRobot.Service.Services.Interface;

namespace StampingRobot.API.Controllers
{
    [Route("api/robots")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private readonly IRobotService _robotService;

        public RobotController(IRobotService robotService)
        {
            _robotService = robotService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRobotsPagingAsync([FromQuery] PaginationParameter paginationParameter,[FromQuery] FilterRobot filter)
        {
            try
            {
                var result = await _robotService.GetRobotPagination(paginationParameter, filter);

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
                        Message = "Robot is empty"
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRobotByIdAsync(int id)
        {
            try
            {
                var result = await _robotService.GetRobotByIdAsync(id);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "Robot is not found"
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

        [HttpPost]
        public async Task<IActionResult> CreateRobotAsync([FromBody] RobotRequestModel robotRequestModel)
        {
            try
            {
                var robotModel = new RobotModel
                {
                    Name = robotRequestModel.Name,
                    Model = robotRequestModel.Model,
                    Status = robotRequestModel.Status
                };
                var result = await _robotService.CreateRobotAsync(robotModel);
                if (result)
                {
                    return Ok(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status201Created,
                        Message = "Create robot successfully"
                    });
                }
                else
                {
                    return BadRequest(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status400BadRequest,
                        Message = "Create robot failed"
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
    }
}
