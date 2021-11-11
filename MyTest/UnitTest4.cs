using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyTest
{
    [TestClass]
    public class TestRating
    {
        Random r = new Random();
        [TestMethod]
        public void Rating1()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }

        [TestMethod]
        public void Rating2()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }

        [TestMethod]
        public void Rating3()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }

        [TestMethod]
        public void Rating4()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }
    }
}
