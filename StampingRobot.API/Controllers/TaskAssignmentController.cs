using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StamingRobot.Repository.Commons;
using StampingRobot.API.ViewModels.RequestModels;
using StampingRobot.Service.Services;
using StampingRobot.Service.Services.Interface;

namespace StampingRobot.API.Controllers
{
    [Route("api/task-assignments")]
    [ApiController]
    public class TaskAssignmentController : ControllerBase
    {
        private readonly ITaskAssignmentService _taskAssignmentService;

        public TaskAssignmentController(ITaskAssignmentService taskAssignmentService)
        {
            _taskAssignmentService = taskAssignmentService;
        }

        [HttpGet]
        public Task<IActionResult> GetAllTaskAssignmentPaging([FromQuery] PaginationParameter paginationParameter, [FromQuery] FilterTaskAssignment filterTaskAssignment)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetTaskAssignmentById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<IActionResult> CreateTaskAssignment([FromBody] TaskAssignmentRequestModel taskAssignmentRequestModel)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task<IActionResult> UpdateTaskAssignment(int id, [FromBody] TaskAssignmentRequestModel taskAssignmentRequestModel)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteTaskAssignment(int id)
        {
            throw new NotImplementedException();
        }
    }
}
