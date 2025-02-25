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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly StampingRobotContext _dbContext;

        public UserRepository(StampingRobotContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUserWithFilter(FilterUser filter)
        {
            var list = _dbContext.Users.Where(c => (filter.Role == null || c.Role.Equals(filter.Role)) &&
                    (filter.IsDelete == null || c.IsDeleted == filter.IsDelete))
                .Select(c => new
                {
                    c.Id,
                    c.FullName,
                    c.Phone,
                    c.Email,
                    c.GoogleId,
                    c.CodeOtpEmail,
                    c.Password,
                    c.Role,
                    c.IsDeleted
                }).AsQueryable();

            var result = list.Select(c => new User
            {
                Id = c.Id,
                FullName = c.FullName,
                Phone = c.Phone,
                Email = c.Email,
                GoogleId = c.GoogleId,
                CodeOtpEmail = c.CodeOtpEmail,
                Password = c.Password,
                Role = c.Role,
                IsDeleted = c.IsDeleted
            }).AsNoTracking();

            return await result.ToListAsync();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbContext.Users.Where(c => c.Email.Equals(email)).FirstOrDefaultAsync();
        }
    }
}
