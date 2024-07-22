using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class MemoizedIsPrime
    {
        public static Boolean IsPrime(int number)
        {
            for (int i=2; i<number/2 +1; i++) { 
                if (number%i==0) return false;
            }
            return true;
        }

        public static Func<int,int> MemoizedPrime() //with closure
        {
            Dictionary<int, int> primes = new Dictionary<int, int>();
            primes.Add(0, 2);

            return (int position) =>
            {
                if (primes.ContainsKey(position)) return primes[position];

                //not calculated yet
                int lastPos = primes.Keys.Last();
                int lastPrime = primes.Values.Last();

                while (lastPos != position)
                {
                    for (int i=lastPrime+1; i < lastPrime * 2; i++)
                    {
                        if (IsPrime(i))
                        {
                            lastPos++;
                            primes.Add(lastPos, i);
                            lastPrime = i;
                            break;
                        }
                    }
                }

                return primes[position];

            };
        }

        public static void Exercise6()
        {
            var f = MemoizedPrime();
            Console.WriteLine(f(0));
            Console.WriteLine(f(20));
            Console.WriteLine(f(1));
        }
    }

    //EXAMPLE: Memoized Fibbonacci
    static class MemoizedFibb
    {
        static Func<int, int> MemoizedFibonacciR() //Recursive and closure
        {
            //cache dictionary
            IDictionary<int, int> cache = new Dictionary<int, int>();
            //initialization
            cache[0] = 1;
            cache[1] = 1;
            //the returned memoized function because it is recursive, it must be defined now, in order to call it later
            Func<int, int> f = null;
            //assign the lambda with the actual code to the previous function 
            f = (n) =>
            {
                //if it is in the cache, return it
                if (cache.Keys.Contains(n))
                    return cache[n];
                //otherwise, obtain nest term index
                else
                {
                    //A trace to show when a term is computed
                    Console.Write("*");
                    //compute the next term, note that the recursive
                    //call computes the previous terms if they
                    //do not exist
                    cache[n] = f(n - 1) + f(n - 2);
                    //return the requested term
                    return cache[n];
                }
            };
            return f;
        }

        static Func<int, int> MemoizedFibonacci() //Iterative and closure
        {
            //cache dictionary
            IDictionary<int, int> cache = new Dictionary<int, int>();
            //initialization
            cache[0] = 1;
            cache[1] = 1;
            //the returned memoized function
            return (n) =>
            {
                //if it is in the cache, return it
                if (cache.Keys.Contains(n))
                    return cache[n];
                else
                {
                    //otherwise, obtain next term index
                    int i = cache.Keys.Last() + 1;
                    //compute the terms from that index to the requested one
                    //and store them
                    while (cache.Keys.Last() < n)
                    {
                        //A trace to show when a term is computed
                        Console.Write("*");
                        cache[i] = cache[i - 1] + cache[i - 2];
                        i++;
                    }
                    //return the requested term
                    return cache[n];
                }
            };
        }
    }
    class MemoizedFact { 
        static int Factorial(int n)
        {
            int f = 1;
            for (int i = 2; i <= n; i++)
                f *= i;
            return f;
        }

        static Func<int, int> MemoizedFactorial()
        {
            // Cache definition, initially empty
            IDictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            return n =>
            {
                // If the requested value alerady exists in the cache
                if (keyValuePairs.Keys.Contains(n))
                    return keyValuePairs[n];
                //otherwise it is computed, stored an returned
                else
                {
                    keyValuePairs[n] = Factorial(n);
                    return keyValuePairs[n];
                }
            };
        }
    }

}
