using Lab5.BisnesLogic;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class ATMSystemTest
{
    [Fact]
    public void ATMSystemWithdrawMoneyShouldReturnTrueForValidAmountOnExistingAccount()
    {
        // Arrange
        string existingAccountNumber = "098";
        int pinCode = 98;
        decimal initialBalance = 500;
        decimal withdrawalAmount = 200;

        var mockBankDatabase = new Mock<IBankDatabase>();
        var existingAccount = new BankAccount(existingAccountNumber, pinCode);
        existingAccount.UpdateBalance(initialBalance);
        mockBankDatabase.Setup(bd => bd.GetAccount(It.IsAny<string>(), It.IsAny<int>())).Returns(existingAccount);

        var atmSystem = new ATMSystem(mockBankDatabase.Object);

        // Act
        bool result = atmSystem.WithdrawMoney(existingAccountNumber, pinCode, withdrawalAmount);

        // Assert
        Assert.True(result);
        mockBankDatabase.Verify(bd => bd.UpdateAccount(It.IsAny<BankAccount>()), Times.Once);
    }

    [Fact]
    public void AtmSystemWithdrawMoneyShouldUpdateAccountBalanceForValidWithdrawalAmount()
    {
        // Arrange
        string existingAccountNumber = "123";
        int pinCode = 123;
        decimal initialBalance = 500;
        decimal withdrawalAmount = 200;

        var mockBankDatabase = new Mock<IBankDatabase>();
        var existingAccount = new BankAccount(existingAccountNumber, pinCode);
        existingAccount.UpdateBalance(initialBalance);
        mockBankDatabase.Setup(bd => bd.GetAccount(It.IsAny<string>(), It.IsAny<int>())).Returns(existingAccount);

        var atmSystem = new ATMSystem(mockBankDatabase.Object);

        // Act
        bool result = atmSystem.WithdrawMoney(existingAccountNumber, pinCode, withdrawalAmount);

        // Assert
        Assert.True(result);
        Assert.Equal(initialBalance - withdrawalAmount, existingAccount.Balance);
        mockBankDatabase.Verify(bd => bd.UpdateAccount(existingAccount), Times.Once);
    }
}
