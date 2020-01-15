using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UniTest
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            Assert.That(SergeresISIS.methods.GetCountWordsByLength("Мама мыла раму, мама мама мама", 4), Is.EqualTo(6));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(SergeresISIS.methods.sum(3, 3), 6);
        }

        [Test]
        public void Test3()
        {
            var num = 10;
            Assert.AreEqual(num, 10);
        }

        [Test]
        public void TestMethod()
        {
            Assert.Pass("You first test");
        }
    }
}