using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_Assigment;
using Lab2_Assigment.List;
using System;

namespace LinkedList.Tests  
{
    [TestClass]
    public class TestLinkedListPerson
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
            List l = new(new Person());
            Assert.AreEqual("(A B, age:0, id:1)-", l.ToString());

            l.AddValue(new Person(name:"C", id:"2"));
            Assert.AreEqual("(A B, age:0, id:1)-(C B, age:0, id:2)-", l.ToString());

            l.AddValue(new Person(age: 3, id: "2"));
            Assert.AreEqual("(A B, age:0, id:1)-(C B, age:0, id:2)-(A B, age:3, id:2)-", l.ToString());

            return l;
        }

        [TestMethod]
        public void AddAtPositionTest()
        {
            List l = new(new Person());
            Assert.AreEqual("(A B, age:0, id:1)-", l.ToString());

            l.AddValueAtPosition(new Person(name: "C", id: "2"), 0);
            Assert.AreEqual("(C B, age:0, id:2)-(A B, age:0, id:1)-", l.ToString());

            l.AddValueAtPosition(new Person(age: 3, id: "2"), 1);
            Assert.AreEqual("(C B, age:0, id:2)-(A B, age:3, id:2)-(A B, age:0, id:1)-", l.ToString());

            l.AddValueAtPosition(new Person(age: 3, id: "2"), 3);
            Assert.AreEqual("(C B, age:0, id:2)-(A B, age:3, id:2)-(A B, age:0, id:1)-(A B, age:3, id:2)-", l.ToString());
        }

        [TestMethod]
        public void RemoveFirstTest()
        {
            List l = AddTest();
            Assert.AreEqual("(A B, age:0, id:1)-(C B, age:0, id:2)-(A B, age:3, id:2)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("(C B, age:0, id:2)-(A B, age:3, id:2)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("(A B, age:3, id:2)-", l.ToString());

            l.RemoveFirst();
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void RemoveByValueTest()
        {
            List l = AddTest();
            Assert.AreEqual("(A B, age:0, id:1)-(C B, age:0, id:2)-(A B, age:3, id:2)-", l.ToString());

            l.RemoveByValue(new Person());
            Assert.AreEqual("(C B, age:0, id:2)-(A B, age:3, id:2)-", l.ToString());

            l.RemoveByValue(new Person(id:"2"));
            Assert.AreEqual("(A B, age:3, id:2)-", l.ToString());

            l.RemoveByValue(new Person(id:"2"));
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void RemoveByPositionTest()
        {
            List l = AddTest();
            Assert.AreEqual("(A B, age:0, id:1)-(C B, age:0, id:2)-(A B, age:3, id:2)-", l.ToString());

            l.RemoveByPosition(2);
            Assert.AreEqual("(A B, age:0, id:1)-(C B, age:0, id:2)-", l.ToString());

            l.RemoveByPosition(1);
            Assert.AreEqual("(A B, age:0, id:1)-", l.ToString());

            l.RemoveByPosition(0);
            Assert.AreEqual("", l.ToString());
        }

        [TestMethod]
        public void GetElementTest()
        {
            List l = AddTest();
            Assert.AreEqual("(A B, age:0, id:1)-(C B, age:0, id:2)-(A B, age:3, id:2)-", l.ToString());

            Person element = (Person)l.GetElement(0);
            Assert.AreEqual(new Person(),element);

            element = (Person)l.GetElement(1);
            Assert.AreEqual(new Person(name:"C", id:"2"), element);

            element = (Person)l.GetElement(2);
            Assert.AreEqual(new Person(age: 3, id: "2"), element);
        }

        [TestMethod]
        public void ContainsTest()
        {
            List l = AddTest();
            Assert.AreEqual("(A B, age:0, id:1)-(C B, age:0, id:2)-(A B, age:3, id:2)-", l.ToString());

            Assert.AreEqual(true, l.Contains(new Person()));
            Assert.AreEqual(true, l.Contains(new Person(name: "C", id: "2")));
            Assert.AreEqual(true, l.Contains(new Person(age: 3, id: "2")));
            Assert.AreEqual(false, l.Contains(new Person(id: "3")));
        }
    }
}
