using Microsoft.EntityFrameworkCore.Storage;
using StamingRobot.Repository.Entities;
using StamingRobot.Repository.Repositories;
using StamingRobot.Repository.Repositories.Interface;
using StamingRobot.Repository.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamingRobot.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly StampingRobotContext _stampingRobotContext;
        private IDbContextTransaction? _transaction = null;
        public IGenericRepository<Product> ProductRepository { get; }
        public IGenericRepository<Robot> RobotRepository { get; }
        public IGenericRepository<Stamp> StampRepository { get; }
        public IGenericRepository<StampingProcess> StampingProcessRepository { get; }
        public IGenericRepository<StampingSession> StampingSessionRepository { get; }
        public IGenericRepository<StampingTask> StampingTaskRepository { get; }
        public IGenericRepository<TaskAssignment> TaskAssignmentRepository { get; }
        public IGenericRepository<User> UserRepository { get; } 

        public UnitOfWork(StampingRobotContext context)
        {
            _stampingRobotContext = context;
            ProductRepository = new GenericRepository<Product>(context);
            RobotRepository = new GenericRepository<Robot>(context);
            StampRepository = new GenericRepository<Stamp>(context);
            StampingProcessRepository = new GenericRepository<StampingProcess>(context);
            StampingSessionRepository = new GenericRepository<StampingSession>(context);
            StampingTaskRepository = new GenericRepository<StampingTask>(context);
            TaskAssignmentRepository = new GenericRepository<TaskAssignment>(context);
            UserRepository = new GenericRepository<User>(context);
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _stampingRobotContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
            }
        }

        public void Dispose()
        {
            _stampingRobotContext.Dispose(); // Giải phóng tài nguyên quản lý
            GC.SuppressFinalize(this); // Garbage Collector không cần thực thi phương thức hủy nữa
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task<int> SaveChanges()
        {
            return await _stampingRobotContext.SaveChangesAsync();
        }
    }
}
