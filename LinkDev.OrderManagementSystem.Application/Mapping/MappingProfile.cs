using AutoMapper;
using LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Customers;
using LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Invoices;
using LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Orders;
using LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Products;
using LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Users;
using LinkDev.OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<CreateCustomerDto, Customer>();

            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<CreateProductDto, Product>();

            CreateMap<UpdateProductDto, Product>();

            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<CreateOrderDto, Order>();

            CreateMap<OrderItem, OrderItemDto>().ReverseMap();

            CreateMap<CreateOrderItemDto, OrderItem>();

            CreateMap<Invoice, InvoiceDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
