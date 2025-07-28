using LinkDev.OrderManagementSystem.Application.Abstraction.Repositories;
using LinkDev.OrderManagementSystem.Infrastructure.Persistence.Data;
using LinkDev.Talabat.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Infrastructure.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {

        protected readonly OrderManagementDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(OrderManagementDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false)
        {
            if (withTracking)
                return await _dbSet.ToListAsync();
            else
                return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetAsync(TKey id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public async Task AddAsync(TEntity entity) => await _dbContext.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);

        public Task<int> CompleteAsync() => _dbContext.SaveChangesAsync();

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }
    }

}
