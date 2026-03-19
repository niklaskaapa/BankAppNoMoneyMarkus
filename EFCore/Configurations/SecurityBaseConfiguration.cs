using Entities.Base;
using Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace EFCore.Configurations
{
    public class SecurityBaseConfiguration : IEntityTypeConfiguration<SecurityBase>
    {
        public void Configure(EntityTypeBuilder<SecurityBase> builder)
        {

            builder.HasDiscriminator<string>("SecurityType")
                .HasValue<MutualFund>(nameof(MutualFund))
                .HasValue<Stock>(nameof(Stock));
        }
    }
}
