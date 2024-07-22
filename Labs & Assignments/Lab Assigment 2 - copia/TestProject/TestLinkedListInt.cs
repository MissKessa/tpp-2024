using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList;
using System;

namespace LinkedList.Tests  
{
    [TestClass]
    public class TestLinkedListInt
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            List<int> l = new();
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public List<int> AddTest()
        {
            List<int> l = new(1);
            Assert.AreEqual("(1)-", l.ToString());

            l.Add(2);
            Assert.AreEqual("(1)-(2)-", l.ToString());

            l.Add(3);
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());

            l.Add(1);
            Assert.AreEqual("(1)-(2)-(3)-(1)-", l.ToString());

            return l;
        }

        [TestMethod]
        public void AddAtPositionTest()
        {
            List<int> l = new(1);
            Assert.AreEqual("(1)-", l.ToString());

            l.Add(2, 0);
            Assert.AreEqual("(2)-(1)-", l.ToString());

            l.Add(3, 0);
            Assert.AreEqual("(3)-(2)-(1)-", l.ToString());

            l.Add(1, 1);
            Assert.AreEqual("(3)-(1)-(2)-(1)-", l.ToString());

            l.Add(3, 2);
            Assert.AreEqual("(3)-(1)-(3)-(2)-(1)-", l.ToString());

            l.Add(3, 5);
            Assert.AreEqual("(3)-(1)-(3)-(2)-(1)-(3)-", l.ToString());

            l.Add(3, 7);
            Assert.AreEqual("(3)-(1)-(3)-(2)-(1)-(3)-", l.ToString());
        }

        [TestMethod]
        public void RemoveFirstTest()
        {
            List<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-(1)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("(2)-(3)-(1)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("(3)-(1)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("(1)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void RemoveByValueTest()
        {
            List<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-(1)-", l.ToString());

            l.Remove(1);
            Assert.AreEqual("(2)-(3)-(1)-", l.ToString());

            l.Remove(3);
            Assert.AreEqual("(2)-(1)-", l.ToString());

            l.Remove(1);
            Assert.AreEqual("(2)-", l.ToString());

            l.Remove(2);
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void RemoveByPositionTest()
        {
            List<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-(1)-", l.ToString());

            l.RemoveByPosition(2);
            Assert.AreEqual("(1)-(2)-(1)-", l.ToString());

            l.RemoveByPosition(0);
            Assert.AreEqual("(2)-(1)-", l.ToString());

            l.RemoveByPosition(1);
            Assert.AreEqual("(2)-", l.ToString());

            l.RemoveByPosition(0);
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void GetElementTest()
        {
            List<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-(1)-", l.ToString());

            int element = l.GetElement(0);
            Assert.AreEqual(1,element);

            element = l.GetElement(1);
            Assert.AreEqual(2, element);

            element = l.GetElement(2);
            Assert.AreEqual(3, element); ;

            element = l.GetElement(3);
            Assert.AreEqual(1, element);
        }

        [TestMethod]
        public void ContainsTest()
        {
            List<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-(1)-", l.ToString());

            Assert.AreEqual(true, l.Contains(1));
            Assert.AreEqual(true, l.Contains(2));
            Assert.AreEqual(true, l.Contains(3));
            Assert.AreEqual(false, l.Contains(0));
            Assert.AreEqual(false, l.Contains(4));
            Assert.AreEqual(false, l.Contains(-1));
            Assert.AreEqual(false, l.Contains(-2));
            Assert.AreEqual(false, l.Contains(-3));
        }
    }
}
