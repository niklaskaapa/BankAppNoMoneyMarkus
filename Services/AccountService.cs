using Entities.Base;
using Services.Factories;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class AccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public bool CreateNewAccount(AccountDetails accountDetails) 
        {
            var account = AccountFactory.CreateAccount(accountDetails);
            try
            {
                accountRepository.Add(account);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }



        public List<AccountBase> GetAllAccounts()
        {
            return accountRepository.GetAll();
        }


    }
}
