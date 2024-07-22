using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPP.ObjectOrientation.Overload;
using System.Collections.Generic;
using System;
using System.Linq;
using LinkedList;

namespace dictionary.test
{
    [TestClass]
    public class IDictionary
    {
        [TestMethod]
        public IDictionary<IComparable, IComparable> AddTest()
        {
            IDictionary<IComparable, IComparable> dict = new Dictionary<IComparable, IComparable>();
            IComparable[] keys = new IComparable[] { 1, "2", new Person(12, "0", "0", "0") };
            IComparable[] values = new IComparable[] { new Person(), "45", 2 };

            dict.Add(1, new Person());
            Assert.AreEqual(1, dict.Count);

            dict.Add("2", "45");
            Assert.AreEqual(2, dict.Count);

            dict.Add(new Person(12,"0","0", "0"), 2);
            Assert.AreEqual(3, dict.Count);

            int counter = 0;
            foreach (KeyValuePair<IComparable, IComparable> d in dict)
            {
                Assert.AreEqual(keys[counter], d.Key);
                Assert.AreEqual(values[counter], d.Value);

                counter++;
            }

            return dict;
        }

        [TestMethod]
        public IDictionary<IComparable, IComparable> GetTest()
        {
            IDictionary<IComparable, IComparable> dict = AddTest();
            IComparable[] keys = new IComparable[] { 1, "2", new Person(12, "0", "0", "0") };
            IComparable[] values = new IComparable[] { new Person(), "45", 2 };

            Assert.AreEqual(values[0], dict[keys[0]]);
            Assert.AreEqual(values[1], dict[keys[1]]);
            Assert.AreEqual(values[2], dict[keys[2]]);
            return dict;
        }

        [TestMethod]
        public void SetTest()
        {
            IDictionary<IComparable, IComparable> dict = GetTest();
            IComparable[] keys = new IComparable[] { 1, "2", new Person(12, "0", "0", "0") };
            IComparable[] values = new IComparable[] { new Person(), "45", 2 };

            dict[keys[0]] = "343";
            values[0] = "343";

            Assert.AreEqual(values[0], dict[keys[0]]);
            Assert.AreEqual(values[1], dict[keys[1]]);
            Assert.AreEqual(values[2], dict[keys[2]]);

            dict[keys[0]] = 3;
            values[0] = 3;
            Assert.AreEqual(values[0], dict[keys[0]]);
            Assert.AreEqual(values[1], dict[keys[1]]);
            Assert.AreEqual(values[2], dict[keys[2]]);
        }

        [TestMethod]
        public void ContainsKeyTest()
        {
            IDictionary<IComparable, IComparable> dict = GetTest();
            IComparable[] keys = new IComparable[] { 1, "2", new Person(12, "0", "0", "0") };

            Assert.AreEqual(true, dict.ContainsKey(keys[0]));
            Assert.AreEqual(true, dict.ContainsKey(keys[1]));
            Assert.AreEqual(true, dict.ContainsKey(keys[2]));

            Assert.AreEqual(false, dict.ContainsKey(2));
            Assert.AreEqual(false, dict.ContainsKey(new Person()));
            Assert.AreEqual(false, dict.ContainsKey("84"));
        }

        [TestMethod]
        public void RemovePairTest()
        {
            IDictionary<IComparable, IComparable> dict = GetTest();
            IComparable[] keys = new IComparable[] { 1, "2", new Person(12, "0", "0", "0") };
            IComparable[] values = new IComparable[] { new Person(), "45", 2 };

            dict.Remove(keys[0]);
            Assert.AreEqual(2, dict.Count);
            Assert.AreEqual(false, dict.ContainsKey(keys[0]));
            Assert.AreEqual(true, dict.ContainsKey(keys[1]));
            Assert.AreEqual(true, dict.ContainsKey(keys[2]));

            dict.Remove(keys[1]);
            Assert.AreEqual(1, dict.Count);
            Assert.AreEqual(false, dict.ContainsKey(keys[0]));
            Assert.AreEqual(false, dict.ContainsKey(keys[1]));
            Assert.AreEqual(true, dict.ContainsKey(keys[2]));

            dict.Remove(keys[2]);
            Assert.AreEqual(0, dict.Count);
            Assert.AreEqual(false, dict.ContainsKey(keys[0]));
            Assert.AreEqual(false, dict.ContainsKey(keys[1]));
            Assert.AreEqual(false, dict.ContainsKey(keys[2]));
        }
    }
}
