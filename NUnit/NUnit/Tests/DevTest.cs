using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnit.Tests
{
    [TestFixture]
    class DevTest
    {
        Calculator calculator = new Calculator();

        [Test]
        public void DevPositives()
        {
            Assert.AreEqual(4, calculator.Devide(12, 3));
        }
        [Test]
        public void DevPositiveAndNegative()
        {
            Assert.AreEqual(-4, calculator.Devide(-12, 3));
        }
        [Test]
        public void DevNegatives()
        {
            Assert.AreEqual(4, calculator.Devide(-12, -3));
        }
        [Test]
        public void DevWithZero()
        {
            Assert.AreEqual(0, calculator.Devide(0, 3));
        }
        [Test]
        public void DevWithMaxValue()
        {
            Assert.AreEqual(double.PositiveInfinity, calculator.Devide(double.MaxValue, 0));
        }
    }
}
