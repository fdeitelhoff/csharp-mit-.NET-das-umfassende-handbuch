using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_3
{
    [TestClass]
    public class AnotherTestClass
    {
        public TestContext TestContext { get; set; }
        private string text;

        [TestInitialize]
        public void Initialize()
        {
            if (TestContext.Properties.Contains("DoIt"))
                text = TestContext.Properties["DoIt"] as string;
            else
                text = "default";
        }

        [TestMethod]
        public void Test_Method1()
        {
            Assert.AreEqual("default", text);
        }

        [TestMethod]
        [TestProperty("DoIt", "non-default")]
        public void Test_Method2()
        {
            Assert.AreEqual("non-default", text);
        }
    }
}
