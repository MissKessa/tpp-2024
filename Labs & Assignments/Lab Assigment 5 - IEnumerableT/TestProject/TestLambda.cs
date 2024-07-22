using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using LambdaFunctions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTP_HW_5;
using static System.Net.Mime.MediaTypeNames;

namespace Lambda.Tests
{
    [TestClass]
    public class TestLambda
    {
        [TestMethod]
        public void FindTest()
        {
            Predicate<Person> NameEndsInA = p => p.Name.EndsWith("a");
            Predicate<Person> IdEndsInA = p => p.Id.EndsWith("a");
            Person a = new Person("Maria", "b", "c");
            Person b = new Person("Marta", "b", "h");
            Person c = new Person("Mario", "b", "a");
            System.Collections.Generic.List<Person> l = new List<Person> { a, b, c };
            Assert.AreEqual(a, LambdaFunctions.Lambda.Find(l, NameEndsInA));
            Assert.AreEqual(c, LambdaFunctions.Lambda.Find(l, IdEndsInA));


            Predicate<Angle> RightAngle = a => a.Degrees == 90;
            Predicate<Angle> SecondCuadrant = a => a.Cosine() < 0 && a.Sine() > 0;
            Angle d = new Angle(90f);
            Angle e = new Angle(91f);
            Angle f = new Angle(89f);

            List<Angle> g = new List<Angle> { d, e, f };
            Assert.AreEqual(d, LambdaFunctions.Lambda.Find(g, RightAngle));
            Assert.AreEqual(e, LambdaFunctions.Lambda.Find(g, SecondCuadrant));
        }

        [TestMethod]
        public void FilterTest()
        {
            Predicate<Person> NameEndsInA = p => p.Name.EndsWith("a");
            Predicate<Person> IdEndsInA = p => p.Id.EndsWith("a");
            Person a = new Person("Maria", "b", "c");
            Person b = new Person("Marta", "b", "h");
            Person c = new Person("Mario", "b", "a");
            List<Person> l = new List<Person> { a, b, c };

            IEnumerable<Person> test = LambdaFunctions.Lambda.Filter(l, NameEndsInA);
            List<Person> result = new List<Person> { a, b };

            Assert.AreEqual(result.Count(), test.Count());

            for (int i = 0; i < test.Count(); i++)
            {
                Assert.AreEqual(result.ElementAt(i), test.ElementAt(i));
            }

            test = LambdaFunctions.Lambda.Filter(l, IdEndsInA);
            result = new List<Person> { c };

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

            List<Angle> g = new List<Angle> { d, e, f, h };

            IEnumerable<Angle> test2 = LambdaFunctions.Lambda.Filter(g, RightAngle);
            List<Angle> result2 = new List<Angle> { d };

            Assert.AreEqual(result2.Count(), test2.Count());
            for (int i = 0; i < test2.Count(); i++)
            {
                Assert.AreEqual(result2.ElementAt(i), test2.ElementAt(i));
            }

            test2 = LambdaFunctions.Lambda.Filter(g, SecondCuadrant);
            result2 = new List<Angle> { e, h };

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

            List<Angle> g = new List<Angle> { d, e, f, h };

            Assert.AreEqual(397f, LambdaFunctions.Lambda.Reduce(g,addAngles));

            Func<Dictionary<String, int>,Person, Dictionary<String, int>> countByName = delegate (Dictionary<String,int> dict, Person p)
            {
                if (dict == null)
                {
                    dict = new Dictionary<String, int>();
                }
                if (dict.ContainsKey(p.Name))
                {
                    dict[p.Name] += 1;
                } else
                {
                    dict.Add(p.Name, 1);
                }

                return dict;
            };

            Person a = new Person("Maria", "b", "c");
            Person b = new Person("Marta", "b", "h");
            Person c = new Person("Mario", "b", "a");
            Person x = new Person("Mario", "x", "p");
            List<Person> l = new List<Person> { a, b, c,x };

            Dictionary<String, int> result = new Dictionary<String, int>();
            result.Add("Maria", 1);
            result.Add("Marta", 1);
            result.Add("Mario", 2);

            Dictionary<String, int> nameCounting = LambdaFunctions.Lambda.Reduce(l, countByName);
            Assert.AreEqual(result.Count(), nameCounting.Count());

            for (int i = 0; i < result.Count(); i++)
            {
                String key = result.ElementAt(i).Key;
                Assert.AreEqual(true,nameCounting.ContainsKey(key));
                Assert.AreEqual(result[key], nameCounting[key]);
            }
        }
    }
}
