using Entities.Accounts;
using Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace EFCore.Configurations
{
    public class AccountBaseConfiguration : IEntityTypeConfiguration<AccountBase> // för att hitta våra config filer
    {
        public void Configure(EntityTypeBuilder<AccountBase> builder)
        {
                builder.HasDiscriminator<string>("AccountType")
               .HasValue<UddevallaAccount>(nameof(UddevallaAccount))
               .HasValue<BankAccount>(nameof(BankAccount))
               .HasValue<GoldAccount>(nameof(GoldAccount))
               .HasValue<IskAccount>(nameof(IskAccount))
               .HasValue<MillionAccount>(nameof(MillionAccount));

        }
    }
}
