using LinkDev.OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Application.Abstraction.Repositories
{
    public interface IProductRepository : IGenericRepository<Product, int>
    {
        Task<Product?> GetProductWithStockAsync(int productId);
    }
}
