using LinkDev.OrderManagementSystem.Application.Abstraction.Repositories;
using LinkDev.OrderManagementSystem.Domain.Entities;
using LinkDev.OrderManagementSystem.Infrastructure.Persistence.Data;
using LinkDev.OrderManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product, int>, IProductRepository
    {
        public ProductRepository(OrderManagementDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Product?> GetProductWithStockAsync(int productId)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Id == productId && p.Stock > 0);
        }
    }
}
