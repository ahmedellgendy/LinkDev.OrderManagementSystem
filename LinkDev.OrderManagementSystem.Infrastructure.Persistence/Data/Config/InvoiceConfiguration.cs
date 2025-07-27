using LinkDev.OrderManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.OrderManagementSystem.Infrastructure.Persistence.Data.Config
{
    public class InvoiceConfiguration
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {

            builder.HasKey(i => i.Id);

            builder.Property(i => i.InvoiceDate)
                   .IsRequired();

            builder.Property(i => i.TotalAmount)
                   .IsRequired();

        }

    }
}
