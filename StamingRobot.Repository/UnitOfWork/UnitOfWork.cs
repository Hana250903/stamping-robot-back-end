using Microsoft.EntityFrameworkCore.Storage;
using StamingRobot.Repository.Entities;
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
        private readonly StampingRobotContext _StampingRobotContext;
        private IDbContextTransaction? _transaction = null;

        public UnitOfWork(StampingRobotContext cursusContext)
        {
            _StampingRobotContext = cursusContext;
        }
        public async Task BeginTransactionAsync()
        {
            _transaction = await _StampingRobotContext.Database.BeginTransactionAsync();
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
            _StampingRobotContext.Dispose(); // Giải phóng tài nguyên quản lý
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
            return await _StampingRobotContext.SaveChangesAsync();
        }
    }
}
