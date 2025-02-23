using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StamingRobot.Repository.Commons;
using StampingRobot.API.ViewModels.RequestModels;
using StampingRobot.Service.Services.Interface;

namespace StampingRobot.API.Controllers
{
    [Route("api/stamps")]
    [ApiController]
    public class StampController : ControllerBase
    {
        private readonly IStampService _stamService;

        public StampController(IStampService stampService)
        {
            _stamService = stampService;
        }

        [HttpGet]
        public Task<IActionResult> GetAllStampPaging([FromQuery] PaginationParameter paginationParameter, [FromQuery] FilterStamp filterStamp)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetStampById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<IActionResult> CreateStamp([FromBody] StampRequestModel stampRequestModel)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task<IActionResult> UpdateStamp(int id, [FromBody] StampRequestModel stampRequestModel)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteStamp(int id)
        {
            throw new NotImplementedException();
        }
    }
}
