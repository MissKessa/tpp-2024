using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stack;
using System;
using System.Runtime.Serialization;
using TPP.ObjectOrientation.Overload;
using LinkedList;

namespace Stack.Tests  
{

    [TestClass]
    public class TestStack
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            Stack s= new Stack(7);
            Assert.AreEqual("", s.ToString());
            Assert.AreEqual((uint) 7, s.MaxNumberOfElements);

            s = new Stack(1);
            Assert.AreEqual("", s.ToString());
            Assert.AreEqual((uint)1, s.MaxNumberOfElements);

            try { new Stack(0); throw new Exception("It must have failed");}
            catch (ArgumentException ex) { }
        }

        [TestMethod]
        public void ListTest()
        {
            Stack s = new Stack(7);
            Assert.AreEqual("", s.ToString());

            List l = new(1);
            l.Add(2.13);
            l.Add(new Person());
            l.Add("AA");
            s.List = l;
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-(AA)-", s.ToString());

            try { s.List = null; throw new Exception("It must have failed"); }
            catch (ArgumentException ex) { }

            try {s.List = l;}
            catch (ArgumentException ex) { }
        }

        [TestMethod]
        public void MaxNumberOfElementsTest()
        {
            Stack s = new Stack(1);
            Assert.AreEqual("", s.ToString());
            Assert.AreEqual((uint)1, s.MaxNumberOfElements);

            s.MaxNumberOfElements = 7;
            Assert.AreEqual("", s.ToString());
            Assert.AreEqual((uint)7, s.MaxNumberOfElements);

            try { s.MaxNumberOfElements =0; throw new Exception("It must have failed"); }
            catch (ArgumentException ex) { }
        }

        public void PushTest()
        {
            Stack s = new Stack(7);
            Assert.AreEqual("", s.ToString());

            try { s.Push(null); throw new Exception("It must have failed"); }
            catch (ArgumentException ex) { }

            List l = new(1);
            l.Add(2.13);
            s.List = l;
            try { s.Push(2); throw new Exception("It must have failed"); }
            catch (InvalidOperationException ex) { }

            s = new Stack(7);
            s.Push(1);
            Assert.AreEqual("(1)-", s.ToString());
            s.Push(2.13);
            Assert.AreEqual("(1)-(2.13)-", s.ToString());
            s.Push(new Person());
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-", s.ToString());
            s.Push("AA");
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-(AA)-", l.ToString());
        }

        [TestMethod]
        public void PopTest()
        {
            Stack s = new Stack(7);
            Assert.AreEqual("", s.ToString());
            try { s.Pop(); throw new Exception("It must have failed"); }
            catch (InvalidOperationException ex) { }

            List l = new(1);
            l.Add(2.13);
            l.Add(new Person());
            l.Add("AA");
            s.List = l;
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-(AA)-", s.ToString());

            s.Pop();
            Assert.AreEqual("(1)-(2.13)-(A B, age:0, id:1)-", s.ToString());
            s.Pop();
            Assert.AreEqual("(1)-(2.13)-", s.ToString());
            s.Pop();
            Assert.AreEqual("(1)-", s.ToString());
            s.Pop();
            Assert.AreEqual("", s.ToString());
        }

        [TestMethod]
        public void CapacityTest()
        {
            Stack s = new Stack(3);
            Assert.AreEqual(true, s.IsEmpty);
            Assert.AreEqual(false, s.IsFull);

            s.Push(1);
            Assert.AreEqual(false, s.IsEmpty);
            Assert.AreEqual(false, s.IsFull);

            s.Push(1);
            Assert.AreEqual(false, s.IsEmpty);
            Assert.AreEqual(false, s.IsFull);

            s.Push(1);
            Assert.AreEqual(false, s.IsEmpty);
            Assert.AreEqual(true, s.IsFull);

            s.Pop();
            Assert.AreEqual(false, s.IsEmpty);
            Assert.AreEqual(false, s.IsFull);

            s.Pop();
            Assert.AreEqual(false, s.IsEmpty);
            Assert.AreEqual(false, s.IsFull);

            s.Pop();
            Assert.AreEqual(true, s.IsEmpty);
            Assert.AreEqual(false, s.IsFull);
        }

     }
}
