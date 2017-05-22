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
        public void ValidateEmail()
        {
            var sut = new ValidationEngine.ValidationEngine();

            sut.IsValid = sut.Validate("hej@hotmail.com");

            Assert.IsTrue(sut.IsValid);
        }
    }
}
