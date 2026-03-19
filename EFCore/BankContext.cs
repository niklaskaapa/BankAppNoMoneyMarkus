using Entities.Accounts;
using Entities.Base;
using Entities.Security;
using Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EFCore
{
    internal class BankContext : DbContext
    {
        public DbSet<AccountBase> AccountBases { get; set; }
        public DbSet<SecurityBase> SecurityBases  { get; set; }
        public DbSet<SecurityTransactionBase> SecurityTransactionBases  { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BankDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankContext).Assembly);
                

        }


    }
}
