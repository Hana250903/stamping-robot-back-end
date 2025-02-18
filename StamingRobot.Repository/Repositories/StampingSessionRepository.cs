using StamingRobot.Repository.Entities;
using StamingRobot.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamingRobot.Repository.Repositories
{
    public class StampingSessionRepository : GenericRepository<StampingSession>, IStampingSessionRepository
    {
        private readonly StampingRobotContext _dbContext;

        public StampingSessionRepository(StampingRobotContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
