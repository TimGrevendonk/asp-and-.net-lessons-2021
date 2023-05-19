using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
using System;

namespace BankTest
{
    // Mandatory annotation for any class that contains test methods.
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void Constructoe_Balance0_Returns0()
        {
            // Arrange.
            Account account = new Account();
            // ACT.
            double balance = account.Balance;
            // Assert.
            Assert.AreEqual(0, balance);
        }

        [TestMethod]
        public void Credit_999OnBalance_Returns999()
        {
            // Arrange.
            Account account = new Account();
            // Act
            account.Credit(999);
            // Assert.
            Assert.AreEqual(999, account.Balance);
        }

        [TestMethod]
        public void Debit_500FromBalance500_Returns0()
        {
            // Arrange.
            Account account = new Account();
            // Act.
            account.Credit(500);
            account.Debit(500);
            // Assert.
            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        public void Debit_10FromBalance500_Returns490()
        {
            // Arrange.
            Account account = new Account();
            // Act.
            account.Credit(500);
            account.Debit(10);
            // Assert.
            Assert.AreEqual(490, account.Balance);
        }

        [TestMethod]
        public void Credit_NegativeAmount_ReturnsOutOfRangeException()
        {
            // ARRANGE
            Account account = new Account();
            // ASSERT // ACT							 
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => account.Credit(-200));
        }

        [TestMethod]
        public void Credit_0Amount_ReturnsOutOfRangeException()
        {
            // ARRANGE
            Account account = new Account();
            // ASSERT 
            // ACT							 
            Assert.ThrowsException<ArgumentOutOfRangeException>
            (() => account.Credit(0));
        }

        [TestMethod]
        public void Balance_AmountBiggerThanBalance_BalanceInsufficientException()
        {
            // Arrange.
            Account account = new Account();
            // Assert.
            account.Credit(400);
            // Act.
            Assert.ThrowsException<BalanceInsufficientException>(() => account.Debit(410));
        }
    }
}
