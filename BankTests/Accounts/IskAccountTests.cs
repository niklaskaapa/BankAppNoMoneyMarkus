using Entities.Accounts;
using Entities.Base;
using Entities.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesTests.Accounts
{
    public class IskAccountTests
    {

        private StockTransaction GetStockTransaction(int quantity = 1 , decimal purchaseAmount = 1000)
        {
            return new StockTransaction
            {
                Id = Guid.NewGuid(),
                Quantity = quantity,
                PurchasePrice = purchaseAmount,
                PurchaseDate = DateTime.Now,
            };
        }



        [Fact]

        public void IskAccount_Balance_ResultShouldBeZero()
        {
            var account = new IskAccount("test", "123", 0);

            var result = account.Balance();

            Assert.Equal(0, result);

        }

        [Fact]

        public void IskAccount_Balance_AddStockTransaction_DepositShouldBe1000()
        {
            //Arrange
            var account = new IskAccount("test", "123", 0);
            var transaction = GetStockTransaction(1,1000);


            //{
            //    Id = Guid.NewGuid(),
            //    Quantity = 1,
            //    PurchasePrice = 1000,
            //    PurchaseDate = DateTime.Now
            //};

            account.AddSecurityTransaction(transaction);


            //Act

            var result = account.Balance();

            //Assert

            Assert.Equal(1000, result);

        }

        [Fact]

        public void IskAccount_Balance_AddMutualTransaction_DepositShouldBe1000()
        {
            //Arrange
            var account = new IskAccount("test", "123", 0);

            account.AddSecurityTransaction(GetStockTransaction(1, 1000));

            //var transaction = new MutualFundTransaction
            //{
            //    Id = Guid.NewGuid(),
            //    Quantity = 1,
            //    PurchasePrice = 1000,
            //    PurchaseDate = DateTime.Now
            //};
            //account.AddSecurityTransaction(transaction);


            //Act

            var result = account.Balance();

            //Assert

            Assert.Equal(1000, result);

        }

        [Fact]

        public void IskAccount_Balance_AddTwoDifferentTransactions_ShouldBe2000()
        {
            //Arrange

            var account = new IskAccount("test", "123", 0);
            var fundTransaction = new MutualFundTransaction
            {
                Id = Guid.NewGuid(),
                Quantity = 1,
                PurchasePrice = 1000,
                PurchaseDate = DateTime.Now
            };

            var stockTransaction = GetStockTransaction(1, 1000);
            //{
            //    Id = Guid.NewGuid(),
            //    Quantity = 1,
            //    PurchasePrice = 1000,
            //    PurchaseDate = DateTime.Now
            //};
            account.AddSecurityTransaction(fundTransaction);
            account.AddSecurityTransaction(stockTransaction);



            var result = account.Balance();

            Assert.Equal(2000m, result);


        }



    }
}
