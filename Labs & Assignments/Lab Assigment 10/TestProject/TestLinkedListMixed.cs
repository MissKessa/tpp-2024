using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList;
using System;
using TPP.ObjectOrientation.Overload;

namespace LinkedList.Tests  
{
    [TestClass]
    public class TestLinkedListMixed
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            LinkedList.List<Object> l = new();
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public LinkedList.List<Object> AddTest()
        {
            LinkedList.List<Object> l = new(1);
            Assert.AreEqual("(1)-", l.ToString());

            l.Add(2.13);
            Assert.AreEqual("(1)-(2.13)-", l.ToString());

            l.Add(new Person());
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-", l.ToString());

            l.Add("AA");
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-(AA)-", l.ToString());

            return l;
        }

        [TestMethod]
        public void AddAtPositionTest()
        {
            LinkedList.List<Object> l = new(1);
            Assert.AreEqual("(1)-", l.ToString());

            l.Add(2.13,0);
            Assert.AreEqual("(2.13)-(1)-", l.ToString());

            l.Add(new Person(),1);
            Assert.AreEqual("(2.13)-(A B, age:0, id:1)-(1)-", l.ToString());

            l.Add("AA",2);
            Assert.AreEqual("(2.13)-(A B, age:0, id:1)-(AA)-(1)-", l.ToString());
        }

        [TestMethod]
        public void RemoveFirstTest()
        {
            LinkedList.List<Object> l = AddTest();
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-(AA)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("(2.13)-(A B, age:0, id:1)-(AA)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("(A B, age:0, id:1)-(AA)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("(AA)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void RemoveByValueTest()
        {
            LinkedList.List<Object> l = AddTest();
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-(AA)-", l.ToString());

            l.Remove(2.13);
            Assert.AreEqual("(1)-(A B, age:0, id:1)-(AA)-", l.ToString());

            l.Remove("AA");
            Assert.AreEqual("(1)-(A B, age:0, id:1)-", l.ToString());

            l.Remove(new Person());
            Assert.AreEqual("(1)-", l.ToString());

            l.Remove(1);
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void RemoveByPositionTest()
        {
            LinkedList.List<Object> l = AddTest();
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-(AA)-", l.ToString());

            l.RemoveByPosition(2);
            Assert.AreEqual("(1)-(2.13)-(AA)-", l.ToString());

            l.RemoveByPosition(1);
            Assert.AreEqual("(1)-(AA)-", l.ToString());

            l.RemoveByPosition(0);
            Assert.AreEqual("(AA)-", l.ToString());

            l.RemoveByPosition(0);
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void GetElementTest()
        {
            LinkedList.List<Object> l = AddTest();
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-(AA)-", l.ToString());

            Assert.AreEqual(1, (int)l.GetElement(0));

            Assert.AreEqual(2.13, (double)l.GetElement(1));

            Assert.AreEqual(new Person(), (Person)l.GetElement(2));

            Assert.AreEqual("AA", (String)l.GetElement(3));
        }

        [TestMethod]
        public void ContainsTest()
        {
            LinkedList.List<Object> l = AddTest();
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-(AA)-", l.ToString());

            Assert.AreEqual(true, l.Contains(1));
            Assert.AreEqual(true, l.Contains(2.13));
            Assert.AreEqual(true, l.Contains(new Person()));
            Assert.AreEqual(true, l.Contains("AA"));
            Assert.AreEqual(false, l.Contains(0));
            Assert.AreEqual(false, l.Contains(2.07));
            Assert.AreEqual(false, l.Contains(new Person(id:"YY")));
            Assert.AreEqual(false, l.Contains("AB"));
        }
    }
}
