using LinkDev.Talabat.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Domain.Entities
{
    public class User : BaseAuditableEntity<int>
    {
        public required string Username { get; set; } 
        public required string PasswordHash { get; set; } 
        public string Role { get; set; } = "Customer";
    }
}
