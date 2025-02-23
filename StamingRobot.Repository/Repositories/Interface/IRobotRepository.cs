using StamingRobot.Repository.Commons;
using StamingRobot.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamingRobot.Repository.Repositories.Interface
{
    public interface IRobotRepository : IGenericRepository<Robot>
    {
        Task<List<Robot>> GetAllWithFilter(FilterRobot filter);
    }
}
