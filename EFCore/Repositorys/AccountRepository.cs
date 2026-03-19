using Entities.Base;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Repositorys
{
    internal class AccountRepository : IAccountRepository
    {
        private readonly BankContext context;

        public AccountRepository(BankContext context)
        {
            this.context = context;
        }


        public bool Add(AccountBase account)
        {
            context.Add(account);
            context.SaveChanges();
            return true;
        }

        public bool Delete(Guid id)
        {
            var account = context.AccountBases.FirstOrDefault(a => a.Id == id);

            if (account == null) return false;
            
            context.Remove(account);
            context.SaveChanges();
            return true;

                
        }

        public List<AccountBase> GetAll() => context.AccountBases.ToList();
        


        

        public AccountBase GetById(Guid id)
        {
            return context.AccountBases.First(a => a.Id == id);

        }

        public bool Update(AccountBase account)
        {
            context.AccountBases.Update(account);
            context.SaveChanges();
            return true;
        }


    }
}
