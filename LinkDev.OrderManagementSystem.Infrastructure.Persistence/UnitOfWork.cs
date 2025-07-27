using LinkDev.OrderManagementSystem.Application.Abstraction.Repositories;
using LinkDev.OrderManagementSystem.Domain.Contracts;
using LinkDev.OrderManagementSystem.Infrastructure.Persistence.Data;
using LinkDev.OrderManagementSystem.Infrastructure.Repositories;
using LinkDev.Talabat.Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderManagementDbContext _dbContext;
        private readonly Hashtable _repositories;

        public UnitOfWork(OrderManagementDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Hashtable();
        }

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<,>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TKey)), _dbContext);
                _repositories[type] = repositoryInstance!;
            }

            return (IGenericRepository<TEntity, TKey>)_repositories[type]!;
        }

        public async Task<int> CompleteAsync() => await _dbContext.SaveChangesAsync();

        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
    }
}
