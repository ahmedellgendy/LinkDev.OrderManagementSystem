﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Application.Abstraction.Dtos.Products
{
    public class UpdateProductDto
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
