using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaFunctions
{
    public class Lambda
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="T">The type of object in the collection</typeparam>
        /// <param name="e">The collection</param>
        /// <param name="p">The predicate</param>
        /// <returns>Returns the first element in a collection that fulfills a specific predicate. 
        /// If no element equal to the parameter exists, the default value is returned.</returns>
        public static T Find<T>(IEnumerable<T> e, Predicate<T> p)
        {
            foreach (T t in e)
            {
                if (p(t)) return t;
            }
            return default(T);
        }

        /// <summary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e">The collection</param>
        /// <param name="p">The predicate</param>
        /// <returns>Returns all the elements in a collection that fulfills a given predicate.</returns>
        public static IEnumerable<T> Filter<T>(IEnumerable<T> e, Predicate<T> p)
        {
            List<T> result = new List<T>();
            foreach (T t in e)
            {
                if (p(t)) result.Add(t);
            }
            return result;
        }


        public static W Reduce<T, W>(IEnumerable<T> e, Func<W, T, W> func)
        {
            W result = func(default(W), e.ElementAt(0));
            for (int i = 1; i < e.Count(); i++)
            {
                result = func(result, e.ElementAt(i));
            }
            return result;
        }

        public W Reduce<T,W>(IEnumerable<T> e, Func<W, T, W> func, W seed = default(W)) //Reduce with seed optional parameter
        {
            W result = func(seed, e.ElementAt(0));
            for (int i = 1; i < e.Count(); i++)
            {
                result = func(result, e.ElementAt(i));
            }
            return result;
        }

        //static void ApplyAction<T>(IEnumerable<T> e, Action<T> a)
        //{
        //    foreach (T item in e)
        //    {
        //        a(item);
        //    }

        //}
        //}

        //static void Ejer1()
        //{
        //    Func<double, double> asinh = (double x) => (Math.Log10(x + Math.Sqrt(Math.Pow(x, 2) + 1)));
        //    Func<double, double> acosh = (double x) => (Math.Log10(x + Math.Sqrt(Math.Pow(x, 2) - 1)));
        //    Func<double, double> atanh = (double x) => ((Math.Log10(1 + x) - Math.Log(1 - x)) / 2);
        //}

        //static void Ejer2()
        //{
        //    IList<int> ints = new List<int>() { 1, 2, 3, 4, 5 };
        //    IList<char> chars = new List<char>() { 'a', 'b', 'c', 'd', 'e' };
        //    ApplyAction(ints, x => Console.Write($"{x}"));
        //    Console.WriteLine();
        //    ApplyAction(chars, x => Console.Write($"{x}"));
        //}

        //static void Ejer3()
        //{
        //    IList<int> ints = new List<int>() { 1, 2, 3, 4, 5 };
        //    IList<char> chars = new List<char>() { 'a', 'b', 'c', 'd', 'e' };



        //    Predicate<int> isPrime = delegate (int x)
        //    {
        //        for (int i = 2; i < x; i++)
        //        {
        //            if (x % i == 0)
        //                return false;
        //        }
        //        return true;
        //    };
        //    Console.WriteLine();
        //    Console.WriteLine(Count(ints, isEven));
        //    Console.WriteLine(Count(ints, isPrime));
        //}

    }
}
