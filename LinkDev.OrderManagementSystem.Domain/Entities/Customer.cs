using LinkDev.Talabat.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Domain.Entities
{
    public class Customer : BaseAuditableEntity<int>
    {
        public required string Name { get; set; } 
        public string? Email { get; set; } 
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
