using Entities.Base;
using Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace EFCore.Configurations
{
    public class SecurityTransactionBaseConfiguration : IEntityTypeConfiguration<SecurityTransactionBase>
    {
        public void Configure(EntityTypeBuilder<SecurityTransactionBase> builder)
        {
            builder.HasDiscriminator<string>("SecurityTransactionType")
                .HasValue<MutualFundTransaction>(nameof(MutualFundTransaction))
                .HasValue<StockTransaction>(nameof(StockTransaction));
        }
    }
}
