using System.Collections.Generic;
using Extra_Exercise_3;
using NSubstitute;
using NUnit.Framework;

namespace NSubExcercise.Tests
{
    [TestFixture]
    [Category("ExerciseNSubstitute")]
    public class ExtraExercise3NSubstitute
    {
        private IAuditLogger _iAuditLoggerMock;
        private Bank _sut;
        private Account _account;

        [SetUp]
        public void Setup()
        {
            _iAuditLoggerMock = Substitute.For<IAuditLogger>();
            _sut = new Bank(_iAuditLoggerMock);
            _account = new Account
            {
                Name = "Henrik",
                Number = "46",
                Balance = 0
            };
        }

        [Test]
        public void CanCreateBankAccount()
        {
            _sut.CreateAccount(_account);

            var result = _sut.GetAccount("46");

            Assert.AreEqual("Henrik", result.Name);
            Assert.AreEqual("46", result.Number);
            Assert.AreEqual(0, result.Balance);
        }
        [Test]
        public void CanNotCreateDuplicateAccounts()
        {

            _sut.CreateAccount(_account);

            Assert.Throws<DuplicateAccount>(() =>
                _sut.CreateAccount(_account));
        }
        [Test]
        public void WhenCreatingAnAccount_AMessageIsWrittenToTheAuditLog()
        {
            _sut.CreateAccount(_account);

            _iAuditLoggerMock.Received().AddMessage(Arg.Is<string>(a => a.Contains(_account.Name) && a.Contains(_account.Number)));
        }
        [Test]
        public void WhenCreatingAnValidAccount_OneMessageAreWrittenToTheAuditLog()
        {
            _sut.CreateAccount(_account);

            _iAuditLoggerMock.Received(1).AddMessage(Arg.Any<string>());
        }
        [Test]
        public void WhenCreatingAnInvalidAccount_TwoMessagesAreWrittenToTheAuditLog()
        {
            var invalidAccount = new Account() { Name = "Emil", Number = "ingetNummer", Balance = 1 };

            Assert.Throws<InvalidAccount>(() => _sut.CreateAccount(invalidAccount));
            _iAuditLoggerMock.Received(2).AddMessage(Arg.Any<string>());

        }
        [Test]
        public void WhenCreatingAnInvalidAccount_AWarn12AndErro45MessageIsWrittenToAuditLog()
        {
            var invalidAccount = new Account() { Name = "Emil", Number = "ingetNummer", Balance = 1 };

            Assert.Throws<InvalidAccount>(() => _sut.CreateAccount(invalidAccount));
            _iAuditLoggerMock.Received().AddMessage(Arg.Is<string>(m => m.Contains("Warn12") || m.Contains("Error45")));
        }
        [Test]
        public void VerifyThat_GetAuditLog_GetsTheLogFromTheAuditLogger()
        {
            _iAuditLoggerMock.GetLog().Returns(new List<string>() { "One", "Two", "Three" });

            var result = _sut.GetAuditLog();

            Assert.AreEqual(3, result.Count);
        }
    }
}
