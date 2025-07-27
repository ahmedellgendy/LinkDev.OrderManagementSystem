using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Orders
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public string? PaymentMethod { get; set; }
        public List<CreateOrderItemDto>? OrderItems { get; set; }
    }
}
