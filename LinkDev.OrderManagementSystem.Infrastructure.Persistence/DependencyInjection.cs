using LinkDev.OrderManagementSystem.Application.Abstraction.Repositories;
using LinkDev.OrderManagementSystem.Infrastructure.Persistence.Data;
using LinkDev.OrderManagementSystem.Infrastructure.Persistence.Repositories;
using LinkDev.OrderManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("OrderManagementDb"));
            });

            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();
            

            return services;
        }
    } 
}
