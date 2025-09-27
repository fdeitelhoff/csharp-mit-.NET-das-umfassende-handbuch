using System;
using GeometricObjectsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RectangleLibraryTest
{
    [TestClass]
    public class Test_Rectangle
    {
        static Rectangle rect;

        [ClassInitialize]
        public static void Setup(TestContext testcontext)
        {
            rect = new Rectangle { Length = 10, Width = 15 };
        }

        [ClassCleanup]
        public static void Cleanup() => rect = null;

        [TestMethod]
        public void Test_GetArea()
        {
            long expected = 150;
            long actual = rect.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_GetPerimeter()
        {
            long expected = 50;
            long actual = rect.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}
