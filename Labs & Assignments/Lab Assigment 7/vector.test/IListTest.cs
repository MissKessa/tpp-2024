using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TPP.ObjectOrientation.Overload;
namespace vector.test
{
    [TestClass]
    public class IListTest
    {
        [TestMethod]
        public IList<IComparable> AddTest()
        {
            IList<IComparable> list = new List<IComparable>();
            IComparable[] list2 = new IComparable[] { 1, "2", new Person()};
            Assert.AreEqual(0, list.Count);

            list.Add(1);
            Assert.AreEqual(1, list.Count);

            list.Add("2");
            Assert.AreEqual(2, list.Count);

            list.Add(new Person());
            Assert.AreEqual(3, list.Count);

            foreach (var (a, b) in list.Zip(list2 )) //go through both at the same time
            {
                Assert.AreEqual(a, b);
            }

            return list;
        }

        [TestMethod]
        public IList<IComparable> GetTest() {
            IList<IComparable> list = AddTest();
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual("2", list[1]);
            Assert.AreEqual(new Person(), list[2]);
            return list;
        }

        [TestMethod]
        public void SetTest()
        {
            IList<IComparable> list = GetTest();

            list[0] = "343";
            Assert.AreEqual("343", list[0]);
            Assert.AreEqual("2", list[1]);
            Assert.AreEqual(new Person(), list[2]);

            list[0] = new Person();
            Assert.AreEqual(new Person(), list[0]);
            Assert.AreEqual("2", list[1]);
            Assert.AreEqual(new Person(), list[2]);
        }

        [TestMethod]
        public void ContainsTest()
        {
            IList<IComparable> list = GetTest();
            Assert.AreEqual(true, list.Contains(new Person()));
            Assert.AreEqual(true, list.Contains(1));
            Assert.AreEqual(true, list.Contains("2"));

            Assert.AreEqual(false, list.Contains("3"));
            Assert.AreEqual(false, list.Contains((Person)null));
            Assert.AreEqual(false, list.Contains(0));
        }

        [TestMethod]
        public void GetIndexTest()
        {
            IList<IComparable> list = GetTest();
            Assert.AreEqual(0, list.IndexOf(1));
            Assert.AreEqual(1, list.IndexOf("2"));
            Assert.AreEqual(2, list.IndexOf(new Person()));
        }

        [TestMethod]
        public void RemoveElementTest()
        {
            IList<IComparable> list = GetTest();
            list.Remove(1);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(true, list.Contains(new Person()));
            Assert.AreEqual(true, list.Contains("2"));
            Assert.AreEqual(false, list.Contains(1));

            list.Remove("2");
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(true, list.Contains(new Person()));
            Assert.AreEqual(false, list.Contains("2"));
            Assert.AreEqual(false, list.Contains(1));

            list.Remove(new Person());
            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(false, list.Contains(new Person()));
            Assert.AreEqual(false, list.Contains("2"));
            Assert.AreEqual(false, list.Contains(1));

        }


    }
}
