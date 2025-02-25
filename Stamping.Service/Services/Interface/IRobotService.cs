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
        Task<Pagination<RobotModel>> GetAllRobotPagination (PaginationParameter paginationParameter, FilterRobot filter);
    }
}
