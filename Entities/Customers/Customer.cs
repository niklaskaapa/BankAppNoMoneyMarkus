using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Customers
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SecurityNumber { get; set; }
        public string Address { get; set; }

        public List<AccountBase> Accounts { get; set; }


    }
}
