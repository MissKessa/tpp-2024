using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTP_HW_5;

namespace LinkedList.Tests.FunctionalProgramming
{
    [TestClass]
    public class TestLinkedListFuctionalProgramming
    {
        [TestMethod]
        public void FindTest()
        {
            Predicate<Person> NameEndsInA = p => p.Name.EndsWith("a");
            Predicate<Person> IdEndsInA = p => p.Id.EndsWith("a");
            Person a = new Person("Maria", "b", "c");
            Person b = new Person("Marta", "b", "h");
            Person c = new Person("Mario", "b", "a");
            LinkedList.List<Person> l = new LinkedList.List<Person> { a, b, c };
            Assert.AreEqual(a, l.Find(NameEndsInA));
            Assert.AreEqual(c, l.Find(IdEndsInA));


            Predicate<Angle> RightAngle = a => a.Degrees == 90;
            Predicate<Angle> SecondCuadrant = a => a.Cosine() < 0 && a.Sine() > 0;
            Angle d = new Angle(90f);
            Angle e = new Angle(91f);
            Angle f = new Angle(89f);

            LinkedList.List<Angle> g = new LinkedList.List<Angle> { d, e, f };
            Assert.AreEqual(d, g.Find(RightAngle));
            Assert.AreEqual(e, g.Find(SecondCuadrant));
        }

        [TestMethod]
        public void FilterTest()
        {
            Predicate<Person> NameEndsInA = p => p.Name.EndsWith("a");
            Predicate<Person> IdEndsInA = p => p.Id.EndsWith("a");
            Person a = new Person("Maria", "b", "c");
            Person b = new Person("Marta", "b", "h");
            Person c = new Person("Mario", "b", "a");
            LinkedList.List<Person> l = new LinkedList.List<Person> { a, b, c };

            LinkedList.List<Person> test = l.Filter(NameEndsInA);
            LinkedList.List<Person> result = new LinkedList.List<Person> { a, b };

            Assert.AreEqual(result.Count(), test.Count());

            for (int i = 0; i < test.Count(); i++)
            {
                Assert.AreEqual(result.ElementAt(i), test.ElementAt(i));
            }

            test = l.Filter(IdEndsInA);
            result = new LinkedList.List<Person> { c };

            Assert.AreEqual(result.Count(), test.Count());
            for (int i = 0; i < test.Count(); i++)
            {
                Assert.AreEqual(result.ElementAt(i), test.ElementAt(i));
            }


            Predicate<Angle> RightAngle = a => a.Degrees == 90;
            Predicate<Angle> SecondCuadrant = a => a.Cosine() < 0 && a.Sine() > 0;
            Angle d = new Angle(90f);
            Angle e = new Angle(91f);
            Angle f = new Angle(89f);
            Angle h = new Angle(127f);

            LinkedList.List<Angle> g = new LinkedList.List<Angle> { d, e, f, h };

            LinkedList.List<Angle> test2 = g.Filter(RightAngle);
            LinkedList.List<Angle> result2 = new LinkedList.List<Angle> { d };

            Assert.AreEqual(result2.Count(), test2.Count());
            for (int i = 0; i < test2.Count(); i++)
            {
                Assert.AreEqual(result2.ElementAt(i), test2.ElementAt(i));
            }

            test2 = g.Filter(SecondCuadrant);
            result2 = new LinkedList.List<Angle> { e, h };

            Assert.AreEqual(result2.Count(), test2.Count());
            for (int i = 0; i < test2.Count(); i++)
            {
                Assert.AreEqual(result2.ElementAt(i), test2.ElementAt(i));
            }
        }

        [TestMethod]
        public void ReduceTest()
        {
            Func<Double, Angle, Double> addAngles = (Double prev, Angle ang) => prev + ang.Degrees;
            Angle d = new Angle(90f);
            Angle e = new Angle(91f);
            Angle f = new Angle(89f);
            Angle h = new Angle(127f);

            LinkedList.List<Angle> g = new LinkedList.List<Angle> { d, e, f, h };

            Assert.AreEqual(397f, g.Reduce(addAngles));

            Func<Dictionary<String, int>, Person, Dictionary<String, int>> countByName = delegate (Dictionary<String, int> dict, Person p)
            {
                if (dict == null)
                {
                    dict = new Dictionary<String, int>();
                }
                if (dict.ContainsKey(p.Name))
                {
                    dict[p.Name] += 1;
                }
                else
                {
                    dict.Add(p.Name, 1);
                }

                return dict;
            };

            Person a = new Person("Maria", "b", "c");
            Person b = new Person("Marta", "b", "h");
            Person c = new Person("Mario", "b", "a");
            Person x = new Person("Mario", "x", "p");
            LinkedList.List<Person> l = new LinkedList.List<Person> { a, b, c, x };

            Dictionary<String, int> result = new Dictionary<String, int>();
            result.Add("Maria", 1);
            result.Add("Marta", 1);
            result.Add("Mario", 2);

            Dictionary<String, int> nameCounting = l.Reduce(countByName);
            Assert.AreEqual(result.Count(), nameCounting.Count());

            for (int i = 0; i < result.Count(); i++)
            {
                String key = result.ElementAt(i).Key;
                Assert.AreEqual(true, nameCounting.ContainsKey(key));
                Assert.AreEqual(result[key], nameCounting[key]);
            }
        }

        [TestMethod]
        public void InvertTest()
        {
            Angle d = new Angle(90f);
            Angle e = new Angle(91f);
            Angle f = new Angle(89f);
            Angle h = new Angle(127f);

            LinkedList.List<Angle> g = new LinkedList.List<Angle> { d, e, f, h };
            LinkedList.List<Angle> result = g.Invert();
            LinkedList.List<Angle> gReversed = new LinkedList.List<Angle> { h,f,e,d };

            for(int i=0; i<result.Count(); i++)
            {
                Assert.AreEqual(gReversed.GetElement(i),result.GetElement(i));
            }
        }

        [TestMethod]
        public void MapTest()
        {
            Person a = new Person("Maria", "b", "c");
            Person b = new Person("Marta", "b", "h");
            Person c = new Person("Mario", "b", "a");
            LinkedList.List<Person> l = new LinkedList.List<Person> { a, b, c };

            Func<Person,String> getNames= (p) => p.Name;

            LinkedList.List<String> result=l.Map(getNames);

            LinkedList.List<String> names= new LinkedList.List<String> { a.Name,b.Name,c.Name};

            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(names.GetElement(i), result.GetElement(i));
            }
        }

        [TestMethod]
        public void ForEachTest()
        {
            Person a = new Person("Maria", "b", "c");
            Person b = new Person("Marta", "b", "h");
            Person c = new Person("Mario", "b", "a");
            LinkedList.List<Person> l = new LinkedList.List<Person> { a, b, c };

            Action<Person> changeName = (p) => p.Name="AAAA";

            l.ForEach(changeName);


            Person d = new Person("AAAA", "b", "c");
            Person e = new Person("AAAA", "b", "h");
            Person f = new Person("AAAA", "b", "a");
            LinkedList.List<Person> result = new LinkedList.List<Person> { d,e,f };

            for (int i = 0; i < l.Count(); i++)
            {
                Assert.AreEqual(result.GetElement(i).Name, l.GetElement(i).Name);
                Assert.AreEqual(result.GetElement(i).Surname, l.GetElement(i).Surname);
                Assert.AreEqual(result.GetElement(i).Id, l.GetElement(i).Id);
            }
        }


    }
}
