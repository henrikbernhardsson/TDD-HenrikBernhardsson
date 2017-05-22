using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace Bank.Tests
{
    [TestFixture]
    class BankTests
    {
        [Test]
        public void CanDepositMoney()
        {
            var sut = new BankAccount();

            sut.Deposit(1000);

            Assert.AreEqual(1000, sut.Balance, "Can deposit money!");
        }
        [Test]
        public void CanWithdrawMoney()
        {
            var sut = new BankAccount();
            
            sut.Withdraw(1000);

            Assert.AreEqual(-1000, sut.Balance, "Can withdraw money!");
        }
    }
}
