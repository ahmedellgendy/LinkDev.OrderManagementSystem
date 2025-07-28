using LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Orders;
using LinkDev.OrderManagementSystem.Application.Abstraction.Repositories;


namespace LinkDev.OrderManagementSystem.Application.Abstraction.Contracts
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(CreateOrderDto orderDto, int userId);
        Task<OrderDetailsDto?> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<OrderListDto>> GetAllOrdersAsync();
        Task<IEnumerable<OrderListDto>> GetCustomerOrdersAsync(int customerId);
        Task UpdateOrderStatusAsync(int orderId, string newStatus);
        Task DeleteOrderAsync(int orderId);
    }
}
