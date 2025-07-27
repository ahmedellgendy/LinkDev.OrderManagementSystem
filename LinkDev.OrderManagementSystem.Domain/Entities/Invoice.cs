using LinkDev.Talabat.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Domain.Entities
{
    public class Invoice : BaseAuditableEntity<int>
    {
        public int OrderId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Order? Order { get; set; } 
    }
}
