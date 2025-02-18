using StamingRobot.Repository.Entities;
using StamingRobot.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamingRobot.Repository.Repositories
{
    public class StampingTaskRepository : GenericRepository<StampingTask>, IStampingTaskRepository
    {
        private readonly StampingRobotContext _dbContext;

        public StampingTaskRepository(StampingRobotContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
