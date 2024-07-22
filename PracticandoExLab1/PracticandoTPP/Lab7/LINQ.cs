using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;

namespace Lab7
{
    public static class LINQ
    {
        private static void Show<T>(this IEnumerable<T> e, String messageBefore = "", String separator = " ", String end = "\n")
        {
            Console.WriteLine(messageBefore);
            foreach (T item in e)
            {
                Console.Write(item);
                Console.Write(separator);
            }
            Console.Write(end);
        }
        public static void Exercise2()
        {
            //A
            IList<char> chars = new List<char>() { 'a', 'b', 'c', 'd', 'e' };
            var q = chars.Where(x => x >= 'c'); //filters the chars that are >=c: that is c, d, e
            q.Show(); //It shows c,d,e
            chars.Add('f'); //I add f
            q.Show(); //It shows c,d,e,f. This is because it uses Lazy execution

            q = chars.Where(x => x >= 'c').ToList(); //filters the chars that are >=c: that is c, d, e
            q.Show(); //It shows c,d,e
            chars.Add('f'); //I add f
            q.Show(); //It shows c,d,e. I added ToList, so it shows the value where I declared it

            //B
            IList<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            IList<int> numbers2 = new List<int>() { 3, 4, 5, 6, 7 };
            //numbers concatenated with numbers2
            numbers2.Aggregate(numbers, (acc, x) => { acc.Add(x); return acc; }).Show("Concatenated "); //overloaded version of aggregate: takes the collection, and a function that takes an accumulator and element, and returns the accumulator
            //We are initialize acc with numbers, as they are references we will modify numbers when modifying acc
            //We use numbers as the seed of acc
            numbers.Show("numbers ");

            //To get rid of this effect we use:
            numbers2.Aggregate(numbers.ToList(), (acc, x) => { acc.Add(x); return acc; }).Show("Concatenated ");
            numbers.Show("numbers ");
        }

        ///Returns the max element of a collecion by using Aggregate
        public static T MyMax<T>(this IEnumerable<T> e) where T:IComparable<T>
        {
            T max=e.ElementAt(0);
            Func<T,T,T> a = (max,item) =>
            {
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
                return max;
            };

            max= e.Aggregate(max, a);
            return max;
        }

        public static void Exercise3_1()
        {
            IList<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            IList<int> numbers2 = new List<int>() { 3, 7, 4, 5, 6};

            Console.WriteLine(numbers.MyMax());
            Console.WriteLine(numbers2.MyMax());
        }

        //Returns the collection without the repetions removed using Where
        public static IEnumerable<T> RemoveRepetionsWhere<T>(this IEnumerable<T> e)
        {
            IList<T> noRep= new List<T>();
            Func<T,bool> p = (item) =>
            {
                if (!noRep.Contains(item))
                {
                    noRep.Add(item);
                    return true;
                }
                return false;
            };

            return e.Where(p);
        }

        //Returns the collection without the repetions removed using Aggregate
        public static IEnumerable<T> RemoveRepetionsAggregate<T>(this IEnumerable<T> e)
        {
            IList<T> noRep = new List<T>();
            Func<IList<T>, T, IList<T>> f = (noRep,item) =>
            {
                if (!noRep.Contains(item))
                {
                    noRep.Add(item);
                }
                return noRep;
            };

            return e.Aggregate(noRep, f);
        }

        public static void Exercise3_2()
        {
            IList<int> numbers = new List<int>() { 1, 2, 2, 3, 4, 5, 1 };
            IList<int> numbers2 = new List<int>() { 3, 3,7,8,8,3 };

            foreach(int i in numbers.RemoveRepetionsWhere())
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            foreach (int i in numbers2.RemoveRepetionsWhere())
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            foreach (int i in numbers.RemoveRepetionsAggregate())
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            foreach (int i in numbers2.RemoveRepetionsAggregate())
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        //Returns the difference of the 2 list (set difference)
        public static IEnumerable<T> Difference<T>(this IEnumerable<T> e, IEnumerable<T> b)
        {
            return e.Where((T item) => { return !b.Contains(item); }) ;
        }

        public static void Exercise3_3()
        {
            IList<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            IList<int> numbers2 = new List<int>() { 3, 7, 4, 5, 6 };

            foreach (int i in numbers.Difference(numbers2))
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            foreach (int i in numbers2.Difference(numbers))
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        //Returns the sum of the squares of the even elements 
        public static int SumSquareEvenNumbers(this IEnumerable<int> e)
        {
            Func<int, bool> evenNumbers = (x) => x % 2 == 0;
            Func<int, int> squareNumbers = (x) => x=x*x;
            int sum = 0;
            Func<int, int, int> sumNumbers = (sum, x) => sum += x;

            return e.Where(evenNumbers).Select(squareNumbers).Aggregate(sum, sumNumbers);
        }

        public static void Exercise3_4()
        {
            IList<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            IList<int> numbers2 = new List<int>() { 3, 7, 4, 5, 6 };

            Console.WriteLine(numbers.SumSquareEvenNumbers());
            Console.WriteLine(numbers2.SumSquareEvenNumbers());
        }

        //Counts how many times each value is repeated in the collection
        public static IDictionary<T, int> CountAll<T>(this IEnumerable<T> e)
        {
            IDictionary<T, int> counter= new Dictionary<T, int>();
            Func<IDictionary<T, int>, T, IDictionary<T, int>> f = (counter, item) =>
            {
                if (!counter.ContainsKey(item))
                {
                    counter[item]=0;
                }
                counter[item] += 1;
                return counter;
            };

            return e.Aggregate(counter,f);
        }

        public static void Exercise3_5()
        {
            IList<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            IList<int> numbers2 = new List<int>() { 3, 7, 4, 3, 5, 6 };

            foreach (var item in numbers.CountAll())
            {
                Console.WriteLine($"{item.Key} -> {item.Value} ");
            }
            Console.WriteLine();

            foreach (var item in numbers2.CountAll())
            {
                Console.WriteLine($"{item.Key} -> {item.Value} ");
            }
            Console.WriteLine();
        }

        //Euclidean distance vectors: v = (v1,v2,v3...); x=(x1,x2,x3...)
        //Euclidean distance = sqrt((x1-v1)^2 + (x2-v2)^2 + ....)
        public static double EuclideanDistanceVectors(this IEnumerable<double> e, IEnumerable<double> d)
        {
            //double result = 0;
            //foreach(var pair in e.Zip(d))
            //{
            //    result += (pair.Second - pair.First) * (pair.Second - pair.First);
            //}
            //return Math.Sqrt(result);

            var pairs=e.Zip(d);
            double result = 0;
            return Math.Sqrt(pairs.Aggregate(result, (result, pair) =>
            {
                result += (pair.Second - pair.First) * (pair.Second - pair.First);
                return result;
            }));
        }

        public static void Exercise3_6()
        {
            IList<double> numbers = new List<double>() { 1.0, 2.0, 3.0, 4.0, 5.0  };
            IList<double> numbers2 = new List<double>() { 1.0, 1.0, 1.0, 1.0, 1.0 };

            Console.WriteLine(numbers.EuclideanDistanceVectors(numbers2));
        }

        //Identical to map but it receives an array of functions that each is applied to ech element
        //If the functions array doesn't have any element, each position of the enumerable returned will be the same as e (the parameter)
        //All the functions take and return a T value
        public static IEnumerable<IEnumerable<T>> MapMulti<T> (this IEnumerable<T>e, IEnumerable<Func<T,T>> fs)
        {
            IList<IList<T>> results = new List<IList<T>>();
            if (fs.Count()==0) { 
                results.Add(e.ToList());
                return results;
            }

            for(int i=0; i<fs.Count(); i++)
            {
                IList<T> res=new List<T>();
                Func<T,T> f=fs.ElementAt(i);
                for(int j=0; j<e.Count(); j++)
                {
                    res.Add(f(e.ElementAt(j)));
                }
                results.Add(res);
            }
            return results;
            
        }

        public static void ExtraMapMulti()
        {
            List<Func<int, int>> fs = new List<Func<int, int>>();
            Func<int, int> f1 =(x)=>x*x;
            Func<int, int> f2 = (x) => x / 2;
            fs.Add(f1);
            fs.Add(f2);

            IEnumerable<int> l= new List<int>() {1,2,3 };
            IEnumerable<IEnumerable<int>> r = l.MapMulti(fs);
            foreach(var i in r)
            {
                foreach(var t in i)
                {
                    Console.Write(t + ",");
                }
                Console.WriteLine();
            }
        }

        //Same as Filter, but it returns only the elements that satisfy all the predicates
        public static IEnumerable<T> FilterMulti<T>(this IEnumerable<T> e, IEnumerable<Predicate<T>> ps)
        {
            IList<T> filtered = new List<T>();

            foreach(T item in e)
            {
                Boolean correct = true;
                foreach(Predicate<T> p in ps)
                {
                    if (!p(item))
                    {
                        correct = false;
                        break;
                    }
                }
                if (correct)
                {
                    filtered.Add(item);
                }
            }
            return filtered;
        }

        public static void ExtraFilterMulti()
        {
            List<Predicate<int>> fs = new List<Predicate<int>>();
            Predicate<int> f1 = (x) => x %2==0;
            Predicate<int> f2 = (x) => x >0;
            fs.Add(f1);
            fs.Add(f2);

            IEnumerable<int> l = new List<int>() { 1, 2, 3 , -2};
            IEnumerable<int> r = l.FilterMulti(fs);
            foreach (var i in r)
            {
                    Console.Write(i + ",");
             
            }
        }

        //Counts the number of ints that are positive and the number of ints that are negative
        public static IDictionary<char,int> CountPositiveAndNegative(this IEnumerable<int> e)
        {
            IDictionary<char, int> d = new Dictionary<char, int>();
            d.Add('+', 0);
            d.Add('-', 0);
            d.Add('0', 0);

            Func<IDictionary<char, int>, int, IDictionary<char, int>> f = (d, x) =>
            {
                if (x == 0) d['0']++;
                else if (x > 0) d['+']++;
                else d['-']++;

                return d;
            };

            return e.Aggregate(d,f);
        }

        public static void ExtraCountPositiveAndNegative()
        { 
            IEnumerable<int> l = new List<int>() { 1, 2,0,0, 3, -2 };
            var d = l.CountPositiveAndNegative();
            Console.WriteLine(d['0']);
            Console.WriteLine(d['+']);
            Console.WriteLine(d['-']);
        }

        //Returns an IEnumerable and an int that contains the elements of the list between n and m, and the total number of elements between n and m
        public static IEnumerable<int> RangeCount(this IEnumerable<int> e, int n, int m, out int size)
        {
            IList<int> l= new List<int>();
            foreach(int x in e)
            {
                if(x>=n && x<=m) l.Add(x);
            }
            size=l.Count;
            return l.OrderBy((x) => x);
        }

        public static void ExtraRangeCount()
        {
            IEnumerable<int> l = new List<int>() { 1, 2, 0, 0, 3, -2 };
            int size;
            var g = l.RangeCount(0, 1, out size);

            Console.WriteLine(size);
            foreach(int x in g) Console.WriteLine(x);
           
        }

        //Receives 2 functions of int type and returns the value sbetween f1 and f2
        public static IEnumerable<int> FuncRange(this IEnumerable<int> e, Func<int,int>f1, Func<int, int> f2)
        {
            IList<int> l= new List<int>();
            foreach(int x in e)
            {
                l.Add(f1(x));
                l.Add(f2(x));
            }
            return l.OrderBy((x)=>x);
        }
        public static void ExtraFuncRange()
        {
            IEnumerable<int> l = new List<int>() { 1, 2, 0, 0, 3, -2 };
            var g = l.FuncRange((x)=>x*2, (x)=>x*1);

            foreach (int x in g) Console.WriteLine(x);

        }

    }
}
