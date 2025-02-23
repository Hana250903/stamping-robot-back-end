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
using StampingRobot.API.ViewModels.ResponseModels;
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
        public async Task<IActionResult> GetAllRobotsPagingAsync([FromQuery] PaginationParameter paginationParameter,[FromQuery] FilterRobot filter)
        {
            try
            {
                var result = await _robotService.GetAllRobotPagination(paginationParameter, filter);

                if (result != null)
                {
                    var metadate = new
                    {
                        result.TotalCount,
                        result.PageSize,
                        result.CurrentPage,
                        result.TotalPages,
                        result.HasNext,
                        result.HasPrevious
                    };

                    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadate));

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
    }
}
