using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SergeresISISTests
{
   
    [TestClass]
    public class tests
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(SergeresISIS.methods.GetCountWordsByLength("Мама мыла раму, мама мама мама", 4), (6));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(SergeresISIS.methods.sum(3, 3), 6);
        }

        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual(SergeresISIS.methods.CountSPACE("Ехал Грека через реку   видит в реке рака"), 9);
        }

        [TestMethod]
        public void Test5()
        {
            Assert.IsTrue(SergeresISIS.methods.Palindrom("шалаш"));
        }

        [TestMethod]
        public void Test6()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Assert.AreEqual(SergeresISIS.methods.ArrLen(numbers), 10);
        }

        [TestMethod]
        public void Test7()
        {
            Assert.IsFalse(SergeresISIS.methods.NotEqueal(5,6));
        }

        [TestMethod]
        public void Test8()
        {
            Assert.AreEqual(SergeresISIS.methods.dev(10, 2), 5);
        }

        [TestMethod]
        public void Test9()
        {
            Assert.AreEqual(SergeresISIS.methods.dif(5, 6), -1);
        }

        [TestMethod]
        public void Test10()
        {
            Assert.AreEqual(SergeresISIS.methods.mult(4, 3), 12);
        }

        [TestMethod]
        public void Test3()
        {
            var num = 10;
            Assert.AreEqual(num, 10);
        }
    }
}
