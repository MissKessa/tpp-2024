using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_Assigment;
using Lab2_Assigment.List;
using System;

namespace LinkedList.Tests  
{
    [TestClass]
    public class TestLinkedListMixed
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            List l = new();
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public List AddTest()
        {
            List l = new(1);
            Assert.AreEqual("(1)-", l.ToString());

            l.AddValue(2.13);
            Assert.AreEqual("(1)-(2.13)-", l.ToString());

            l.AddValue(new Person());
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-", l.ToString());

            l.AddValue("AA");
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-(AA)-", l.ToString());

            return l;
        }

        [TestMethod]
        public void AddAtPositionTest()
        {
            List l = new(1);
            Assert.AreEqual("(1)-", l.ToString());

            l.AddValueAtPosition(2.13,0);
            Assert.AreEqual("(2.13)-(1)-", l.ToString());

            l.AddValueAtPosition(new Person(),1);
            Assert.AreEqual("(2.13)-(A B, age:0, id:1)-(1)-", l.ToString());

            l.AddValueAtPosition("AA",2);
            Assert.AreEqual("(2.13)-(A B, age:0, id:1)-(AA)-(1)-", l.ToString());
        }

        [TestMethod]
        public void RemoveFirstTest()
        {
            List l = AddTest();
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
            List l = AddTest();
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-(AA)-", l.ToString());

            l.RemoveByValue(2.13);
            Assert.AreEqual("(1)-(A B, age:0, id:1)-(AA)-", l.ToString());

            l.RemoveByValue("AA");
            Assert.AreEqual("(1)-(A B, age:0, id:1)-", l.ToString());

            l.RemoveByValue(new Person());
            Assert.AreEqual("(1)-", l.ToString());

            l.RemoveByValue(1);
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void RemoveByPositionTest()
        {
            List l = AddTest();
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
            List l = AddTest();
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-(AA)-", l.ToString());

            Assert.AreEqual(1, (int)l.GetElement(0));

            Assert.AreEqual(2.13, (double)l.GetElement(1));

            Assert.AreEqual(new Person(), (Person)l.GetElement(2));

            Assert.AreEqual("AA", (String)l.GetElement(3));
        }

        [TestMethod]
        public void ContainsTest()
        {
            List l = AddTest();
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
