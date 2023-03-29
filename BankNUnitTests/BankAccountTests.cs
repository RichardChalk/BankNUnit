using BankNUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankNUnitTests
{
    internal class BankAccountTests
    {
        [Test]
        public void Depositing_Funds_Updates_Balance()
        {
            // ARRANGE
            var _sut = new BankAccount(1000);
            var amountToDeposit = 500;
            var expectedBalance = 1500; // 1000 + 500

            // ACT
            _sut.Deposit(amountToDeposit);
            var result = _sut.Balance;

            // ASSERT
            Assert.AreEqual(expectedBalance, result);
        }

        [Test]
        public void Depositing_Negative_Throws_Error()
        {
            // ARRANGE
            var _sut = new BankAccount(1000);
            var amountToDeposit = -100;

            // ACT + ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Deposit(amountToDeposit));
        }


        [Test]
        public void Withdrawing_Funds_Updates_Balance()
        {
            // ARRANGE
            var _sut = new BankAccount(1500);
            var amountToWithdraw = 250;
            var expectedBalance = 1250; // 1500 - 250

            // ACT
            _sut.Withdraw(amountToWithdraw);
            var result = _sut.Balance;

            // ASSERT
            Assert.AreEqual(expectedBalance, result);
        }

        [Test]
        public void Withdrawing_Negative_Throws_Error()
        {
            // ARRANGE
            var _sut = new BankAccount(1000);
            var amountToWithdraw = -100;

            // ACT + ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Withdraw(amountToWithdraw));
        }

        [Test]
        public void Withdrawing_More_Than_Balance_Throws_Error()
        {
            // ARRANGE
            var _sut = new BankAccount(1000);
            var amountToWithdraw = 1100;

            // ACT + ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Withdraw(amountToWithdraw));
        }



        [Test]
        public void Transfering_Funds_Updates_Both_Accounts()
        {
            // ARRANGE
            var _sut = new BankAccount(1250);
            var otherAccount = new BankAccount(250);
            var amountToTransfer = 1000;
            var expectedAccountBalance = 250; // 1250 - 1000 
            var expectedOtherAccountBalance = 1250; // 250 + 1000

            // ACT
            _sut.Transfer(otherAccount, amountToTransfer);
            var resultAccount = _sut.Balance;
            var resultOtherAccount = otherAccount.Balance;

            // ASSERT
            Assert.AreEqual(expectedAccountBalance, resultAccount);
            Assert.AreEqual(expectedOtherAccountBalance, resultOtherAccount);
        }

        [Test]
        public void Transfer_To_Nonexisting_Account_Throws_Error()
        {
            // ARRANGE
            var _sut = new BankAccount(1000);
            var amountToTransfer = 500;

            // ACT + ASSERT
            Assert.Throws<ArgumentNullException>(() => _sut.Transfer(null, amountToTransfer));
        }
    }
}
