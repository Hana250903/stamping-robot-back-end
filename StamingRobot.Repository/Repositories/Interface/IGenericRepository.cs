﻿using Microsoft.EntityFrameworkCore.Storage;
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
        Task<TEntity?> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task SoftDeleteAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        Task UpdateRangeAsync(List<TEntity> entities);
        Task SoftDeleteRangeAsync(List<TEntity> entities);
        Task PermanentDeletedAsync(TEntity entity);

        Task PermanentDeletedListAsync(List<TEntity> entities);

        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<List<TEntity>?> GetByConditionAsync(Expression<Func<TEntity, bool>>? condition = null, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);

        Task<TEntity?> GetLastInsertedAsync();

        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);

    }
}
