using StamingRobot.Repository.Entities;
using StamingRobot.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamingRobot.Repository.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<Robot> RobotRepository { get; }
        IGenericRepository<Stamp> StampRepository { get; }
        IGenericRepository<StampingProcess> StampingProcessRepository { get; }
        IGenericRepository<StampingSession> StampingSessionRepository { get; }
        IGenericRepository<StampingTask> StampingTaskRepository { get; }
        IGenericRepository<TaskAssignment> TaskAssignmentRepository { get; }
        IGenericRepository<User> UserRepository { get; }

        Task<int> SaveChanges();

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();

    }
}
