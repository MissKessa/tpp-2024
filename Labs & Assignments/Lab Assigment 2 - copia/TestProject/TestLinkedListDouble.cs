using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;

namespace LinkedList.Tests
{
    [TestClass]
    public class TestLinkedListDouble
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            List<double> l = new();
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public List<double> AddTest()
        {
            List<double> l = new(1.0);
            Assert.AreEqual("(1)-", l.ToString());

            l.Add(2.77);
            Assert.AreEqual("(1)-(2.77)-", l.ToString());

            l.Add(3.1);
            Assert.AreEqual("(1)-(2.77)-(3.1)-", l.ToString());

            l.Add(1.0);
            Assert.AreEqual("(1)-(2.77)-(3.1)-(1)-", l.ToString());

            return l;
        }

        [TestMethod]
        public void AddAtPositionTest()
        {
            List<double> l = new(1.2);
            Assert.AreEqual("(1.2)-", l.ToString());

            l.Add(2.9, 0);
            Assert.AreEqual("(2.9)-(1.2)-", l.ToString());

            l.Add(3.8777, 0);
            Assert.AreEqual("(3.8777)-(2.9)-(1.2)-", l.ToString());

            l.Add(1.3, 1);
            Assert.AreEqual("(3.8777)-(1.3)-(2.9)-(1.2)-", l.ToString());

            l.Add(3.8777, 2);
            Assert.AreEqual("(3.8777)-(1.3)-(3.8777)-(2.9)-(1.2)-", l.ToString());

            l.Add(3.2, 5);
            Assert.AreEqual("(3.8777)-(1.3)-(3.8777)-(2.9)-(1.2)-(3.2)-", l.ToString());

            l.Add(3.1, 7);
            Assert.AreEqual("(3.8777)-(1.3)-(3.8777)-(2.9)-(1.2)-(3.2)-", l.ToString());
        }

        [TestMethod]
        public void RemoveFirstTest()
        {
            List<double> l = AddTest();
            Assert.AreEqual("(1)-(2.77)-(3.1)-(1)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("(2.77)-(3.1)-(1)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("(3.1)-(1)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("(1)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void RemoveByValueTest()
        {
            List<double> l = AddTest();
            Assert.AreEqual("(1)-(2.77)-(3.1)-(1)-", l.ToString());

            l.Remove(1.0);
            Assert.AreEqual("(2.77)-(3.1)-(1)-", l.ToString());

            l.Remove(3.1);
            Assert.AreEqual("(2.77)-(1)-", l.ToString());

            l.Remove(1.0);
            Assert.AreEqual("(2.77)-", l.ToString());

            l.Remove(2.77);
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void RemoveByPositionTest()
        {
            List<double> l = AddTest();
            Assert.AreEqual("(1)-(2.77)-(3.1)-(1)-", l.ToString());

            l.RemoveByPosition(2);
            Assert.AreEqual("(1)-(2.77)-(1)-", l.ToString());

            l.RemoveByPosition(0);
            Assert.AreEqual("(2.77)-(1)-", l.ToString());

            l.RemoveByPosition(1);
            Assert.AreEqual("(2.77)-", l.ToString());

            l.RemoveByPosition(0);
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void GetElementTest()
        {
            List<double> l = AddTest();
            Assert.AreEqual("(1)-(2.77)-(3.1)-(1)-", l.ToString());

            double element = l.GetElement(0);
            Assert.AreEqual(1, element);

            element = l.GetElement(1);
            Assert.AreEqual(2.77, element);

            element = l.GetElement(2);
            Assert.AreEqual(3.1, element); ;

            element = l.GetElement(3);
            Assert.AreEqual(1, element);
        }

        [TestMethod]
        public void ContainsTest()
        {
            List<double> l = AddTest();
            Assert.AreEqual("(1)-(2.77)-(3.1)-(1)-", l.ToString());

            Assert.AreEqual(true, l.Contains(1));
            Assert.AreEqual(true, l.Contains(2.77));
            Assert.AreEqual(true, l.Contains(3.1));
            Assert.AreEqual(false, l.Contains(0));
            Assert.AreEqual(false, l.Contains(4));
            Assert.AreEqual(false, l.Contains(3.11));
            Assert.AreEqual(false, l.Contains(-1));
            Assert.AreEqual(false, l.Contains(-2.77));
            Assert.AreEqual(false, l.Contains(-3.1));
        }
    }
}
