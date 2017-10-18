using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnit.Tests
{
    [TestFixture]
    class SumTest
    {
        Calculator calculator = new Calculator();

        [Test]
        public void SumPositives()
        {
            Assert.AreEqual(10, calculator.Sum(7, 3));
        }
        [Test]
        public void SumPositiveAndNegative()
        {
            Assert.AreEqual(-4, calculator.Sum(-7, 3));
        }
        [Test]
        public void SumNegatives()
        {
            Assert.AreEqual(-10, calculator.Sum(-7, -3));
        }
        [Test]
        public void SumWithZero()
        {
            Assert.AreEqual(3, calculator.Sum(0, 3));
        }
        [Test]
        public void SumWithMaxValue()
        {
            Assert.AreEqual(double.PositiveInfinity, calculator.Sum(double.MaxValue, double.MaxValue));
        }
    }
}
