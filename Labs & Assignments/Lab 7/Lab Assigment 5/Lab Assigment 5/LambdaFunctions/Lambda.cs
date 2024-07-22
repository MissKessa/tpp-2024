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

        static bool ContainsDivisor(IEnumerable<int> nums, int n)
        {
            foreach (var e in nums)
            {
                if (n % e == 0)
                    return true;
            }
            return false;
        }

        public static Predicate<int> ContainsDivisor(IEnumerable<int> nums)
        {
            return n => { 
                foreach (var e in nums) { 
                    if (n % e == 0) 
                        return true; } 
                return false; };
        }

        public static void RepeatUntilLoop(Func<bool> condition,Action body)
        {
            body();
            if (!condition())
            {
                RepeatUntilLoop(condition, body);
            }
        }
        
        public static void WhileLoop(Func<bool> condition, Action body)
        {
            if (condition())
            {
                body();
                WhileLoop(condition, body);
            }
        }

        public static Func<int> ReturnCounter()
        {
            int counter = 0;
            return () => {
                counter = counter + 1;
                return counter;
            };
        }

        public static Func<int> Fibbonacci()
        {
            int fib1 = 0;
            int fib2 = 1;
            int counter = 0;
            return () =>
            {
                if (counter == 0)
                {
                    counter++;
                    return 1;
                }
                int f = fib1 + fib2;
                fib1 = fib2;
                fib2 = f;
                return f;
            };
        }


        /// <summary>
        /// Returns a generator of infinite terms of the Fibonacci sequence
        /// </summary>
        static internal IEnumerable<int> InfiniteFibonacci() //Lazy way = generator
        {
            int first = 1, second = 1;
            while (true)
            {
                // * Returns the first one and stores the execution state.
                // * In the subsequent invocation, the state is retrieved
                //   and the invocation continues after the yield statement
                yield return first;
                int addition = first + second;
                first = second;
                second = addition;
            }
        }

        public static IEnumerable<int> InfinitePrime()
        {
            IList<int> list = new List<int>();
            int candidate = 2;
            list.Add(candidate);
            while (true){
                yield return candidate;

                candidate= list[list.Count - 1];
                for (int i = candidate+1; i < candidate * 2; i++)
                {
                    bool isPrime = true;
                    foreach(int prime in list)
                    {
                        if (i % prime == 0)
                        {
                            isPrime = false;
                            break;
                        }

                    }

                    if (isPrime)
                    {
                        candidate = i;
                        list.Add(candidate);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Returns a generator of finite terms of the Fibonacci sequence
        /// </summary>
        static internal IEnumerable<int> FiniteFibonacci(int maximumTerm)
        {
            int first = 1, second = 1, term = 1;
            while (true)
            {
                yield return first;
                int addition = first + second;
                first = second;
                second = addition;
                if (term++ == maximumTerm)
                    // * No more terms are returned (we are done)
                    yield break;
            }
        }

        public static IEnumerable<int> FinitePrime(int maximumTerm)
        {
            IList<int> list = new List<int>();
            int counter = 1;
            int candidate = 2;
            list.Add(candidate);
            while (counter<maximumTerm)
            {
                yield return candidate;

                candidate = list[list.Count - 1];
                for (int i = candidate + 1; i < candidate * 2; i++)
                {
                    bool isPrime = true;
                    foreach (int prime in list)
                    {
                        if (i % prime == 0)
                        {
                            isPrime = false;
                            break;
                        }

                    }

                    if (isPrime)
                    {
                        candidate = i;
                        list.Add(candidate);
                        break;
                    }
                }
                counter++;
            }
        }
    }
}
