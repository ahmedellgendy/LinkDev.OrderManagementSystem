using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Customers
{
    public class CreateCustomerDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
