using System;
using CalculatorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorLibrary_Test
{
    [TestClass]
    public class CalculatorTest
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                    "Add.xml",
                    "Value",
                    DataAccessMethod.Sequential)]
        public void Test_Add()
        {
            int value1 = Convert.ToInt32(TestContext.DataRow["Value1"]);
            int value2 = Convert.ToInt32(TestContext.DataRow["Value2"]);
            long expected = Convert.ToInt64(TestContext.DataRow["Result"]);
            long actual = Calculator.Add(value1, value2);
            Assert.AreEqual(expected, actual);
        }
    }
}
