using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyTest
{
    [TestClass]
    public class TestLoggined
    {
        Random r = new Random();
        [TestMethod]
        public void TrueLogin()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }

        [TestMethod]
        public void TruePasswors()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }

        [TestMethod]
        public void FalseLogin()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }

        [TestMethod]
        public void FalsePassword()
        {
            int n = r.Next(1000, 100000);
            for (int i = 0; i < n; i++)
                Assert.AreEqual(i, i);
        }
    }
}
