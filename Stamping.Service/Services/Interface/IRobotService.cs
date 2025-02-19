using StamingRobot.Repository.Commons;
using StamingRobot.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.Services.Interface
{
    public interface IRobotService
    {
        Task<Pagination<Robot>> GetAllRobotPagination (PaginationParameter paginationParameter, Filter filter);
    }
}
