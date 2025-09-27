using System;
using CalculatorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorLibrary_Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Test_Add()
        {
            // Arrange
            int value1 = 20;
            int value2 = 67;
            long expected = 80;
            // Act
            long actual = Calculator.Add(value1, value2);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Subtract()
        { 
            // Arrange
            int value1 = 20;
            int value2 = 60;
            long expected = -40;
            // Act
            long actual = Calculator.Subtract(value1, value2);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Multiply()
        {
            // Arrange
            int value1 = 20;
            int value2 = 60;
            long expected = 1200;
            // Act
            long actual = Calculator.Multiply(value1, value2);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Divide()
        {
            // Arrange
            double value1 = 20;
            double value2 = 60;
            double expected = 0.3333;
            // Act
            double actual = Calculator.Divide(value1, value2);
            //Assert
            Assert.AreEqual(expected, actual, 0.01);
        }
    }
}
