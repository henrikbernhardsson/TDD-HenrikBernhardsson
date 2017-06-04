using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;

namespace StringCalculator.Tests
{
    [TestFixture]
    class CalculatorTest
    {
        private Calculator sut;
        [SetUp]
        public void Setup()
        {
            sut = new Calculator();
        }
        [Test]
        public void EmptyOrNullString()
        {
            var test = sut.Add(null);
            Assert.AreEqual(test, 0);
        }
        [Test]
        public void AddOneReturnOne()
        {
            var result = sut.Add("1");

            Assert.AreEqual(1, result);
        }
        [Test]
        public void PassTwoNumbersToMethod()
        {
            var test = sut.Add("1,2");
            Assert.AreEqual(test, 3);
        }
        [Test]
        public void NumbersOnNewLine()
        {
            var result = sut.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }
        [Test]
        public void AddNegativeNumbers()
        {
            Assert.Throws<NegativeNumbersNotAllowedException>(() =>
            {
                sut.Add("-5,-1\n-12,15");
            });
        }
        [Test]
        public void IgnoreNumbersBiggerThen1000()
        {
            var result = sut.Add("1\n20,3000");

            Assert.AreEqual(21, result);
        }
        
    }
}
