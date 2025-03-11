using Microsoft.EntityFrameworkCore.Storage;
using StamingRobot.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StamingRobot.Repository.Repositories.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task SoftDeleteAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        Task<int> UpdateRangeAsync(List<TEntity> entities);
        Task<int> SoftDeleteRangeAsync(List<TEntity> entities);
        Task<int> PermanentDeletedAsync(TEntity entity);

        Task<int> PermanentDeletedListAsync(List<TEntity> entities);

        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<List<TEntity>?> GetByConditionAsync(Expression<Func<TEntity, bool>> condition);

        Task<TEntity?> GetLastInsertedAsync();

        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);

    }
}
