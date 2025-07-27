using LinkDev.OrderManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Infrastructure.Persistence.Data.Config
{
    public class OrderItemConfiguration
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Quantity)
                   .IsRequired();

            builder.Property(o => o.UnitPrice)
                   .IsRequired();

            builder.Property(o => o.Discount)
                   .IsRequired();

            builder.HasOne(o => o.Product)
                   .WithMany()
                   .HasForeignKey(o => o.ProductId);
        }
    }
}
