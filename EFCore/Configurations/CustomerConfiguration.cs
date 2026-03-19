using Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()                       //Not null
                .HasMaxLength(256);


            builder.Property(c => c.SecurityNumber)
                .HasMaxLength(13)
                .IsRequired();

            builder.Property(c => c.Address)
                .HasMaxLength (256);


        }
    }
}
