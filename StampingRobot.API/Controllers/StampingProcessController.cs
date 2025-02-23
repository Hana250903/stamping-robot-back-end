using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StamingRobot.Repository.Commons;
using StampingRobot.Service.Services;
using StampingRobot.Service.Services.Interface;

namespace StampingRobot.API.Controllers
{
    [Route("api/stamping-process")]
    [ApiController]
    public class StampingProcessController : ControllerBase
    {
        private readonly IStampingProcessService _stampingProcessService;

        public StampingProcessController(IStampingProcessService stampingProcessService)
        {
            _stampingProcessService = stampingProcessService;
        }

        [HttpGet]
        public Task<IActionResult> GetAllStampingProcessPaging([FromQuery] PaginationParameter paginationParameter)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{sessionId}")]
        public Task<IActionResult> GetStampingProcessBySessionId(int sessionId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<IActionResult> CreateStampingProcess()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task<IActionResult> UpdateStampingProcess(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteStampingProcess(int id)
        {
            throw new NotImplementedException();
        }
    }
}
