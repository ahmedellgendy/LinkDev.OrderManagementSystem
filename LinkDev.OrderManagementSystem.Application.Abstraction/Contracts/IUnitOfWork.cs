﻿using LinkDev.Talabat.Domain.Common;
using LinkDev.OrderManagementSystem.Application.Abstraction.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Domain.Contracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
        where TEntity : BaseEntity<TKey> where TKey : IEquatable<TKey>;

        
        Task<int> CompleteAsync();
    }
}
