using Entities.Accounts;

namespace BankTests.Bases;

public class AccountBaseTests
{
    [Theory]
    [InlineData(1000, 1, 2023, 10)] // 1000 @ 1% for a full year = 10
    [InlineData(0, 1, 2023, 0)]  // zero balance = no interest
    [InlineData(1000, 0, 2023, 0)]  // zero rate = no interest
    [InlineData(-500, 1, 2023, 0)]  // negative starting balance is clamped to 0
    [InlineData(10000, 1, 2025, 100)]
    public void AccountBase_CalculateInterestForTheYear_ShouldReturnExpected(
        decimal startingBalance, decimal interestRate, int year, decimal expected)
    {
        var account = new BankAccount("Test", "1234", startingBalance, interestRate);

        var result = account.CalculateInterestForTheYear(year);

        Assert.Equal(expected, Math.Round(result, 2));
    }

    [Fact]
    public void AccountBase_CalculateInterestForTheYear_InvalidYear_ShouldReturnMinusOne()
    {
        var account = new BankAccount("Test", "1234", 1000, 1);

        var result = account.CalculateInterestForTheYear(-1);

        Assert.Equal(-1, result);
    }

    [Theory]
    [InlineData(0, 1, 2025, 100)]
    public void AccountBase_CalculateInterestForTheYear_DepositYearBefore_ShouldReturnExpected(
        decimal startingBalance, decimal interestRate, int year, decimal expected)
    {
        var account = new BankAccount("Test", "1234", startingBalance, interestRate);
        account.Deposit(10000, DateTime.Parse("2024-04-30"));

        var result = account.CalculateInterestForTheYear(year);

        Assert.Equal(expected, Math.Round(result, 2));
    }

    [Theory]
    [InlineData(10000, 1, 2025, 150)]
    public void AccountBase_CalculateInterestForTheYear_DepositMiddleOfYear_ShouldReturnExpected(
    decimal startingBalance, decimal interestRate, int year, decimal expected)
    {
        var account = new BankAccount("Test", "1234", startingBalance, interestRate);
        account.Deposit(10000, DateTime.Parse($"{year}-01-01").AddDays(182));

        var result = account.CalculateInterestForTheYear(year);

        Assert.Equal(expected, Math.Round(result, 0));
    }

    //[Fact]

    //public void AccountBase_Deposit_ValueAmount1000()
    //{
    //    // Arrange

    //    var account = new BankAccount("test", "123", 0);

    //    // Act

    //    account.Deposit(1000, DateTime.Now);


    //    //Assert
    //    Assert.Equal(1000, account.Balance());


    //}

    //[Fact]

    //public void AccountBase_Deposit_NegativeAmount_BalanceSholdBeZero()
    //{
    //    //Arange
    //    var account = new BankAccount("test", "123", 0);

    //    // Act
    //    account.Deposit(-100);

    //    //Assert
    //    Assert.Equal(0, account.Balance());
    //}


    [Fact]

    public void AccountBase_Deposit_BalanceShouldBe2000()
    {
        //Arrange
        var account = new BankAccount("test", "123", 500);

        // Act
        account.Deposit(1000);
        account.Deposit(500);


        //Assert
        Assert.Equal(2000, account.Balance());
    }

    [Theory]
    [InlineData(0, 1000, 1000)]
    [InlineData(0, -100, 0)]
    public void AccountBase_Deposit_ResultShouldBeExpected(decimal startingBalance, decimal deposit, decimal expected)
    {
        //Arrange
        var account = new BankAccount("test", "123", startingBalance);


        //Act
        account.Deposit(deposit);

        //Assert
        Assert.Equal(expected, account.Balance());
    }


    [Theory]
    [InlineData(500, 1000, 500)]
    [InlineData(1000, 500, 500)]
    [InlineData(15000, 11000, 4000)]
    [InlineData(15000, -1000, 15000)]
    [InlineData(1000, 0, 1000)]
    [InlineData(1000, 1000, 0)]

    public void Account_Withdraw_BalanceShouldBeExpected(decimal startingBalance, decimal withdrawAmount, decimal expected)
    {
        //Arrange
        var account = new BankAccount("test", "123", startingBalance);


        //Act
        account.Withdraw(withdrawAmount);

        //Assert

        Assert.Equal(expected, account.Balance());

    }


    [Fact]

    public void AccountBase_Balance_ResultShouldBe500()
    {
        // Arrange
        var account = new UddevallaAccount("test", "123", 500);

        //Act
        var result = account.Balance();

        //Assert
        
        Assert.Equal(500, result);
    }

    [Fact]

    public void AccountBase_Balance_ResultBeZero()
    {
        var account = new UddevallaAccount("test", "123", 0);

        var result = account.Balance();

        Assert.Equal(0, result);
    }



}
