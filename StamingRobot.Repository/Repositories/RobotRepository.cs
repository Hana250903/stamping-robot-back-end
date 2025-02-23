using Microsoft.EntityFrameworkCore;
using StamingRobot.Repository.Commons;
using StamingRobot.Repository.Entities;
using StamingRobot.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamingRobot.Repository.Repositories
{
    public class RobotRepository : GenericRepository<Robot>, IRobotRepository
    {
        private readonly StampingRobotContext _dbContext;

        public RobotRepository(StampingRobotContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<Robot>> GetAllWithFilter(FilterRobot filter)
        {
            var list = _dbContext.Robots
                .Where(c => (filter.Name == null || c.Model.Contains(filter.Name, StringComparison.OrdinalIgnoreCase)))
                .Select(c => new
                {
                    c.Model,
                    c.Status,
                    c.Position,
                    c.UserId,
                }).AsQueryable();

            var result = list.Select(c => new Robot
            {
                Model = c.Model,
                Status = c.Status,
                Position = c.Position,
                UserId = c.UserId,
            }).AsNoTracking();

            return await result.ToListAsync();
        }
    }
}
