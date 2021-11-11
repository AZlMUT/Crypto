using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyTest
{
    [TestClass]
    public class TestMethods
    {
        Random r = new Random();

        [TestMethod]
        public void Method1()
        {
            int n = r.Next(1000,100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }


        [TestMethod]
        public void Method2()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }

        [TestMethod]
        public void Method3()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }

        [TestMethod]
        public void Method4()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }

        [TestMethod]
        public void Method5()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }

        [TestMethod]
        public void Method6()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }

        [TestMethod]
        public void Method7()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }

        [TestMethod]
        public void Method8()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }

        [TestMethod]
        public void Method9()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }
    }
}
