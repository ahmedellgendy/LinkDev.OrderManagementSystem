using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Orders
{
    public class OrderListDto
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }
    }
}
