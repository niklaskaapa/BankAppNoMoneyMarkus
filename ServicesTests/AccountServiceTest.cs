using Entities.Accounts;
using Entities.Base;
using Entities.Types;
using NSubstitute;
using Services;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesTests
{
    public class AccountServiceTest
    {
        private readonly IAccountRepository _accountRepository;


        public AccountServiceTest()
        {
            var mock = Substitute.For<IAccountRepository>();
            _accountRepository = mock;
        }


        [Fact]

        public void AccountService_CreateAccount_RepositoryThrowsError_ShouldReturnFalse()
        {
            // Arrange
            _accountRepository.Add(Arg.Any<AccountBase>()).Returns(_ => throw new NullReferenceException());
            var service = new AccountService(_accountRepository);
            var accountDetails = new AccountDetails("test", "123", 0, AccountType.UddevallaAccount);

            //Act
            var result = service.CreateNewAccount(accountDetails);


            //Assert

            Assert.False(result);


        }



        public void AccountService_CreateAccount_ShouldReturnTrue()
        {
            var service = new AccountService(_accountRepository);
            var accountDetails = new AccountDetails("test", "123", 0, AccountType.UddevallaAccount);

            var result = service.CreateNewAccount(accountDetails);

            Assert.True(result);
        }

        [Fact]
        public void AccountService_GetAllAccounts_ShouldReturnTwoItems()
        {
            //arrange
            _accountRepository.GetAll().Returns([
                new BankAccount("test", "111", 0),
                new UddevallaAccount("test","1234", 100)
                ]);
            var service = new AccountService(_accountRepository);

            //Act
            var result = service.GetAllAccounts();

            //Assert
            Assert.Equal(2, result.Count);




        }



        [Fact]
        public void AccountService_GetAllAccounts_ShouldReturnZero()
        {
            //arrange
            _accountRepository.GetAll().Returns([]);
            var service = new AccountService(_accountRepository);

            //Act
            var result = service.GetAllAccounts();

            //Assert
            Assert.Empty(result);




        }

    }
}
