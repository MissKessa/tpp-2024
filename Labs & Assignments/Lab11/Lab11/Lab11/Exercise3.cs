using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    /*
     * Generate a sorted random integer array (for instance 1000 numbers between
2 and 10000, int type) obtain a collection with the subset of numbers that are primes. Use
three different approaches, Parallel.For, Parallel.ForEach and PLINQ. Check
the ordering in the result. You don’t need to encapsulate this in a method for the sake of
simplicity.
     * */
    internal class Exercise3
    {
        public static void Execute()
        {
            //Exercise 3
            var data = Utils.CreateRandomIntVector(1000000, 2, 10000).OrderBy(x => x).ToArray(); //toArray is needed as OrderbY returns an IEnumerable
            var forResult = PrimesFor(data);
            Utils.Show(forResult.Take(50), ' ', '\n');//sequential way exercise 3

            var parallelForResult = PrimesParallelFor(data);
            Utils.Show(parallelForResult.Take(50), ' ', '\n');//parallel for way exercise 3

            var parallelForEachResult = PrimesParallelForEach(data);
            Utils.Show(parallelForEachResult.Take(50), ' ', '\n');//parallel foreach way exercise 3

            var invokeForResult = PrimesForInvoke(data);
            Utils.Show(invokeForResult.Take(50), ' ', '\n');//invoke for way exercise 3

            var overloadedForResult = OverloadedParallelFor(data);
            Utils.Show(overloadedForResult.Take(50), ' ', '\n');

            Console.WriteLine($"{forResult.Count()} {parallelForResult.Count()} {parallelForEachResult.Count()} {parallelForEachResult.Count()} {overloadedForResult.Count()}");
            Console.WriteLine(Utils.Compare(forResult, parallelForResult));
            Console.WriteLine(Utils.Compare(forResult, parallelForEachResult));
            Console.WriteLine(Utils.Compare(forResult, invokeForResult));
            Console.WriteLine(Utils.Compare(forResult, overloadedForResult));
        }

        /// <summary>
        /// Subset of primes in an int array, sequential implementation
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>A collection with the prime numbers</returns>
        static IEnumerable<int> PrimesFor(int[] data)
        {
            IList<int> result = new List<int>();
            for (int i = 0; i < data.Length; i++)
            {
                if (Utils.IsPrime(data[i]))
                    result.Add(data[i]);
            }
            return result;
        }

        static IEnumerable<int> PrimesParallelFor(int[] data)
        {
            IList<int> result = new List<int>();
            //Parallel.For(0, data.Length, (i) => //This doesn't work as we don't use locks
            //{
            //    if (Utils.IsPrime(data[i]))
            //        result.Add(data[i]);
            //});

            Parallel.For(0, data.Length, (i) =>
            {
                if (Utils.IsPrime(data[i]))
                    lock (data)
                    {
                        result.Add(data[i]);
                    }
            });

            return result;
        }

        static IEnumerable<int> PrimesParallelForEach(int[] data)
        {
            IList<int> result = new List<int>();

            Parallel.ForEach(data, (element) =>
            {
                if (Utils.IsPrime(element))
                    lock (data)
                    {
                        result.Add(element);
                    }
            });

            return result;
        }

        static IEnumerable<int> PrimesForInvoke(int[] data)
        {
            IList<int> result = new List<int>();
            Parallel.Invoke(
                () =>
                {
                    for (int i = 0; i < data.Length; i += 2)
                    {
                        if (Utils.IsPrime(data[i]))
                            lock (result)
                                result.Add(data[i]);
                    }
                }
                , () =>
                {
                    for (int j = 1; j < data.Length; j += 2)
                    {
                        if (Utils.IsPrime(data[j]))
                            lock (result)
                                result.Add(data[j]);
                    }
                }
            );
            //Low bottleneck as the chances of the lock (or mutual exclusion) are very low.
            //If it's hight, use 2 different data structures to the result, and concatenates
            return result;
        }

        private static IList<int> OverloadedParallelFor(int[] data)
        {
            IList<int> result = new List<int>();

            Parallel.For(0, data.Length, () => new List<int>(),
                (j, loop, subresult) =>
                {
                    if (Utils.IsPrime(data[j]))
                        subresult.Add(data[j]);
                    return subresult;
                },
                subFinalresult => {
                    lock (result)
                    {
                        foreach (int i in subFinalresult)
                        {
                            result.Add(i);
                        }
                    }
                });

            return result;
        }
    }
}
