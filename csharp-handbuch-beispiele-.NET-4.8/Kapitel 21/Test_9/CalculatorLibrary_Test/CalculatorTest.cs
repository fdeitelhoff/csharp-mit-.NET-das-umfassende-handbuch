using System;
using CalculatorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorLibrary_Test
{
    [TestClass]
    public class CalculatorTest
    {
        [DataTestMethod]
        [DataRow(20, 60, 80)]
        [DataRow(-20, 40, 20)]
        [DataRow(20, -60, -40)]
        public void Test_Add(int x, int y, long expected)
        {
            long actual = Calculator.Add(x, y);
            Assert.AreEqual(expected, actual);
        }
    }
}
