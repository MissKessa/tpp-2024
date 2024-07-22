using Microsoft.VisualStudio.TestTools.UnitTesting;
using Set;
using System;

namespace Set.Tests  
{
    [TestClass]
    public class TestSetInt
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            Set<int> l = new();
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public Set<int> AddTest()
        {
            Set<int> l = new(1);
            Assert.AreEqual("(1)-", l.ToString());

            l.Add(2);
            Assert.AreEqual("(1)-(2)-", l.ToString());

            l.Add(3);
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());

            l.Add(1);
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());

            return l;
        }

        [TestMethod]
        public void AddAtPositionTest()
        {
            Set<int> l = new(1);
            Assert.AreEqual("(1)-", l.ToString());

            l.Add(2, 0);
            Assert.AreEqual("(2)-(1)-", l.ToString());

            l.Add(3, 0);
            Assert.AreEqual("(3)-(2)-(1)-", l.ToString());

            l.Add(4, 1);
            Assert.AreEqual("(3)-(4)-(2)-(1)-", l.ToString());

            l.Add(3, 2);
            Assert.AreEqual("(3)-(4)-(2)-(1)-", l.ToString());

            l.Add(3, 5);
            Assert.AreEqual("(3)-(4)-(2)-(1)-", l.ToString());

            l.Add(3, 7);
            Assert.AreEqual("(3)-(4)-(2)-(1)-", l.ToString());
        }

        [TestMethod]
        public void RemoveFirstTest()
        {
            Set<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("(2)-(3)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("(3)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void RemoveByValueTest()
        {
            Set<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());

            l.Remove(1);
            Assert.AreEqual("(2)-(3)-", l.ToString());

            l.Remove(3);
            Assert.AreEqual("(2)-", l.ToString());

            l.Remove(2);
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void RemoveByPositionTest()
        {
            Set<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());

            l.RemoveByPosition(2);
            Assert.AreEqual("(1)-(2)-", l.ToString());

            l.RemoveByPosition(0);
            Assert.AreEqual("(2)-", l.ToString());

            l.RemoveByPosition(0);
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void GetElementTest()
        {
            Set<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());

            int element = l.GetElement(0);
            Assert.AreEqual(1,element);

            element = l.GetElement(1);
            Assert.AreEqual(2, element);

            element = l.GetElement(2);
            Assert.AreEqual(3, element);
        }

        [TestMethod]
        public void ContainsTest()
        {
            Set<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());

            Assert.AreEqual(true, l.Contains(1));
            Assert.AreEqual(true, l.Contains(2));
            Assert.AreEqual(true, l.Contains(3));
            Assert.AreEqual(false, l.Contains(0));
            Assert.AreEqual(false, l.Contains(4));
            Assert.AreEqual(false, l.Contains(-1));
            Assert.AreEqual(false, l.Contains(-2));
            Assert.AreEqual(false, l.Contains(-3));
        }

        [TestMethod]
        public void PlusTest()
        {
            Set<int> l = new();
            l = l + 1;
            Assert.AreEqual("(1)-", l.ToString());

            l = l + 2;
            Assert.AreEqual("(1)-(2)-", l.ToString());

            l = l + 3;
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());

            l = l + 1;
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());
        }

        [TestMethod]
        public void MinusTest()
        {
            Set<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());

            l = l - 1;
            Assert.AreEqual("(2)-(3)-", l.ToString());

            l = l - 3;
            Assert.AreEqual("(2)-", l.ToString());

            l = l - 2;
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void GetTest()
        {
            Set<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());

            int element = l[0];
            Assert.AreEqual(1, element);

            element = l[1];
            Assert.AreEqual(2, element);

            element = l[2];
            Assert.AreEqual(3, element);
        }

        [TestMethod]
        public void UnionTest()
        {
            Set<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());

            Assert.AreEqual(l.ToString(), (l|l).ToString());

            Set<int> t = new(2);
            t.Add(4);
            t.Add(5);
            t.Add(6);
            Assert.AreEqual("(2)-(4)-(5)-(6)-", t.ToString());

            Assert.AreEqual("(1)-(2)-(3)-(4)-(5)-(6)-", (l | t).ToString());
            Assert.AreEqual("(2)-(4)-(5)-(6)-(1)-(3)-", (t | l).ToString());
        }

        [TestMethod]
        public void IntersectTest()
        {
            Set<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());

            Assert.AreEqual(l.ToString(), (l & l).ToString());

            Set<int> t = new(2);
            t.Add(4);
            t.Add(5);
            t.Add(6);
            Assert.AreEqual("(2)-(4)-(5)-(6)-", t.ToString());

            Assert.AreEqual("(2)-", (l & t).ToString());
            Assert.AreEqual("(2)-", (t & l).ToString());
        }

        [TestMethod]
        public void DifferenceTest()
        {
            Set<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());

            Assert.AreEqual("", (l - l).ToString());

            Set<int> t = new(2);
            t.Add(4);
            t.Add(5);
            t.Add(6);
            Assert.AreEqual("(2)-(4)-(5)-(6)-", t.ToString());

            Assert.AreEqual("(4)-(5)-(6)-", (t - l).ToString());
            Assert.AreEqual("(1)-(3)-", (l - t).ToString());
        }

        [TestMethod]
        public void CaretTest()
        {
            Set<int> l = AddTest();
            Assert.AreEqual("(1)-(2)-(3)-", l.ToString());

            Assert.AreEqual(true, l^1);
            Assert.AreEqual(true, l ^ 2);
            Assert.AreEqual(true, l ^ 3);
            Assert.AreEqual(false, l ^ 0);
            Assert.AreEqual(false, l ^ 4);
            Assert.AreEqual(false, l ^ -1);
            Assert.AreEqual(false, l ^ -2);
            Assert.AreEqual(false, l ^ -3);
        }
    }
}
