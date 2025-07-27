﻿using LinkDev.Talabat.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Domain.Entities
{
    public class OrderItem : BaseAuditableEntity<int>
    {
        
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public Order Order { get; set; } = default!;
        public Product Product { get; set; } = default!;
    }
}
