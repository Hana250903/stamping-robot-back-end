using StamingRobot.Repository.Commons;
using StamingRobot.Repository.Entities;
using StampingRobot.Service.BussinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.Services.Interface
{
    public interface IRobotService
    {
        Task<Pagination<RobotModel>> GetRobotPagination (PaginationParameter paginationParameter, FilterRobot filter);

        Task<RobotModel> GetRobotByIdAsync(int id);

        Task<bool> CreateRobotAsync(RobotModel robotModel);

        Task<bool> UpdateRobotAsync(RobotModel robotModel);

        Task<bool> DeleteRobotAsync(int id);

        Task<bool> UpdateStatus(int id, string status);
    }
}
