using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnit.Tests
{
    [TestFixture]
    class MultTest
    {
        Calculator calculator = new Calculator();

        [Test]
        public void MultPositives()
        {
            Assert.AreEqual(21, calculator.Mult(7, 3));
        }
        [Test]
        public void MultPositiveAndNegative()
        {
            Assert.AreEqual(-21, calculator.Mult(-7, 3));
        }
        [Test]
        public void MultNegatives()
        {
            Assert.AreEqual(21, calculator.Mult(-7, -3));
        }
        [Test]
        public void MultWithZero()
        {
            Assert.AreEqual(0, calculator.Mult(0, 3));
        }
        [Test]
        public void MultWithMaxValue()
        {
            Assert.AreEqual(double.PositiveInfinity, calculator.Mult(double.MaxValue, 3));
        }
    }
}
