using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnit.Tests
{
    [TestFixture]
    class SubTest
    {
        Calculator calculator = new Calculator();

        [Test]
        public void SubPositives()
        {
            Assert.AreEqual(4, calculator.Sub(7, 3));
        }
        [Test]
        public void SubPositiveAndNegative()
        {
            Assert.AreEqual(-10, calculator.Sub(-7, 3));
        }
        [Test]
        public void SuNegatives()
        {
            Assert.AreEqual(-4, calculator.Sub(-7, -3));
        }
        [Test]
        public void SubWithZero()
        {
            Assert.AreEqual(-3, calculator.Sub(0, 3));
        }
        [Test]
        public void SubWithMaxValue()
        {
            Assert.AreEqual(double.MaxValue, calculator.Sub(double.MaxValue, 3));
        }
    }
}
