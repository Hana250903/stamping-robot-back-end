using StamingRobot.Repository.Commons;
using StampingRobot.Service.BussinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.Services.Interface
{
    public interface ITaskAssignmentService
    {
        Task<Pagination<TaskAssignmentModel>> GetTaskAssignments(PaginationParameter paginationParameter, FilterTaskAssignment filterTaskAssignment);
        Task<TaskAssignmentModel> GetTaskAssignmentById(int id);
        Task<bool> CreateTaskAssignment(TaskAssignmentModel assignment);
        Task<bool> UpdateTaskAssignment(TaskAssignmentModel assignment);
        Task<bool> DeleteTaskAssignment(int id);
    }
}
