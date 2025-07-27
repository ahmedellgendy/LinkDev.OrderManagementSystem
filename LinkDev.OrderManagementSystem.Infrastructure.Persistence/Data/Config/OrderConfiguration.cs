using LinkDev.OrderManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Infrastructure.Persistence.Data.Config
{
    public class OrderConfiguration
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.HasKey(o => o.Id);

            builder.Property(o => o.OrderDate)
                   .IsRequired();

            builder.Property(o => o.TotalAmount)
                   .IsRequired();

            builder.Property(o => o.PaymentMethod)
                   .IsRequired();

            builder.HasMany(o => o.OrderItems)
                   .WithOne(i => i.Order)
                   .HasForeignKey(i => i.OrderId);

            builder.HasOne(o => o.Invoice)
                   .WithOne(i => i.Order)
                   .HasForeignKey<Invoice>(i => i.OrderId);

        }

    }
}
