using AutoMapper;
using LinkDev.OrderManagementSystem.Application.Abstraction.Contracts;
using LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Orders;
using LinkDev.OrderManagementSystem.Domain.Contracts;
using LinkDev.OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> CreateOrderAsync(CreateOrderDto orderDto, int userId)
        {
            var order = _mapper.Map<Order>(orderDto);
            order.Id = userId;
            order.Status = "Pending";
            order.CreatedOn = DateTime.UtcNow;

            await _unitOfWork.GetRepository<Order, int>().AddAsync(order);
            await _unitOfWork.CompleteAsync();

            return order.Id;
        }

        public async Task<OrderDetailsDto?> GetOrderByIdAsync(int orderId)
        {
            var order = await _unitOfWork.GetRepository<Order, int>().GetAsync(orderId);
            return _mapper.Map<OrderDetailsDto>(order);
        }

        public async Task<IEnumerable<OrderListDto>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.GetRepository<Order, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<OrderListDto>>(orders);
        }

        public async Task<IEnumerable<OrderListDto>> GetCustomerOrdersAsync(int customerId)
        {
            var allOrders = await _unitOfWork.GetRepository<Order, int>().GetAllAsync();
            var filtered = allOrders.Where(o => o.CustomerId == customerId);
            return _mapper.Map<IEnumerable<OrderListDto>>(filtered);
        }

        public async Task UpdateOrderStatusAsync(int orderId, string newStatus)
        {
            var repo = _unitOfWork.GetRepository<Order, int>();
            var order = await repo.GetAsync(orderId);

            if (order is null)
                throw new Exception("Order not found");

            order.Status = newStatus;
            repo.Update(order);
            await _unitOfWork.CompleteAsync();
        }
    }
}
