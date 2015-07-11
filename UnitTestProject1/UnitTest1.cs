using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperatorOverloading.Model;

namespace OperatorOverloading.UnitTest
{
    

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethod2()
        {
            var money = new Money(100, "USD");
            var amount = money.ConvertCurrency("YEN");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethod3()
        {
            var money = new Money(100, "USD");
            var amount = money.ConvertCurrency("IN");

        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethod4()
        {
            var money = new Money(100, "USD");
            var amount = money.ConvertCurrency("");

        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethod5()
        {
            var money = new Money(100, "USD");
            var amount = money.ConvertCurrency("\0");

        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethod6()
        {
            var money = new Money(100, "USD");
            var amount = money.ConvertCurrency("   ");

        }
         [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethod9()
        {
            var money = new Money(100, "INR");
            var amount = money.ConvertCurrency("YEN");

        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethod10()
        {
            var money = new Money(100, "YEN");
            var amount = money.ConvertCurrency("INR");

        }

    }
}
       