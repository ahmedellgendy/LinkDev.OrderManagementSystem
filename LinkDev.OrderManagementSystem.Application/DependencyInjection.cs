using LinkDev.OrderManagementSystem.Application.Abstraction.Contracts;
using LinkDev.OrderManagementSystem.Application.Mapping;
using LinkDev.OrderManagementSystem.Application.Services;
using LinkDev.OrderManagementSystem.Domain.Contracts;
using LinkDev.OrderManagementSystem.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Mapper => Mapper.AddProfile(new MappingProfile()));

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthService, AuthService>();


            return services;
        }
    }
}
