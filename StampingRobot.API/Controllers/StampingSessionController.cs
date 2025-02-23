using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StamingRobot.Repository.Commons;
using StampingRobot.Service.Services;
using StampingRobot.Service.Services.Interface;

namespace StampingRobot.API.Controllers
{
    [Route("api/stamping-session")]
    [ApiController]
    public class StampingSessionController : ControllerBase
    {
        private readonly IStampingSessionService _stampingSessionService;

        public StampingSessionController(IStampingSessionService stampingSessionService)
        {
            _stampingSessionService = stampingSessionService;
        }

        [HttpGet]
        public Task<IActionResult> GetAllStampingSessionPaging([FromQuery] PaginationParameter paginationParameter)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{userId}")]
        public Task<IActionResult> GetStampingSessionByUserId(int userId, [FromQuery] PaginationParameter paginationParameter, [FromQuery] FilterSession filterSession)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<IActionResult> CreateStampingSession()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task<IActionResult> UpdateStampingSession(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteStampingSession(int id)
        {
            throw new NotImplementedException();
        }


    }
}
