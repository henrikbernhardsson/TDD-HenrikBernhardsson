using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ValidationEngineTests
{
    [TestFixture]
    public class ValidationEngineTests
    {
        [Test]
        public void ValidateValidEmail()
        {
            var sut = new ValidationEngine.ValidationEngine();

            sut.IsValid = sut.Validate("hej@hotmail.com");

            Assert.IsTrue(sut.IsValid);
        }

        [Test]
        public void ValidateEmailThatIsMissingAtSign()
        {
            var sut = new ValidationEngine.ValidationEngine();

            sut.IsValid = sut.Validate("hejhotmail.com");

            Assert.IsFalse(sut.IsValid);
        }
        [Test]
        public void ValidateEmailThatIsMissingDot()
        {
            var sut = new ValidationEngine.ValidationEngine();

            sut.IsValid = sut.Validate("hej@hotmailcom");

            Assert.IsFalse(sut.IsValid);
        }
        [Test]
        public void ValidateEmailThatIsNull()
        {
            var sut = new ValidationEngine.ValidationEngine();

            sut.IsValid = sut.Validate(null);

            Assert.IsFalse(sut.IsValid);
        }
    }
}