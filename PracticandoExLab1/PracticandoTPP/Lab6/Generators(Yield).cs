using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public static class Generators
    {
        //Generate a list of even ints between 100 and 500 by using lazy evaluation
        public static IEnumerable<int> EvenGenerator()
        {
            int number = 100;
            int end = 500;
            while (true)
            {
                yield return number;
                if(number==end) yield break;
                number += 2;
            }
        }
        /// <summary>
        /// Returns a generator of infinite terms of the Fibonacci sequence
        /// </summary>
        static internal IEnumerable<int> InfiniteFibonacci()
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

        private static void FibProgram()
        {
            const int numberOfTerms = 10;
            // * The 10 first tems in the Fibonacci sequence
            int i = 1;
            foreach (int value in InfiniteFibonacci())
            {
                Console.WriteLine("Term {0}: {1}.", i, value);
                if (i++ == numberOfTerms)
                    break;
            }
            Console.WriteLine();

            // * Finite terms, stating how many terms we want
            i = 1;
            foreach (int value in FiniteFibonacci(numberOfTerms))
                Console.WriteLine("Term {0}: {1}.", i++, value);
        }

        static public IEnumerable<int> InfinitePrime()
        {
            int prime = 2;
            while (true)
            {
                // * Returns the first one and stores the execution state.
                // * In the subsequent invocation, the state is retrieved
                //   and the invocation continues after the yield statement
                yield return prime;
                prime = NextPrime(prime);
            }
        }

        static public IEnumerable<int> FinitePrime(int maximumTerm)
        {
            int prime = 2;
            int counter = 0;
            while (true)
            {
                counter++;
                yield return prime;
                if (counter == maximumTerm)
                    // * No more terms are returned (we are done)
                    yield break;
                prime = NextPrime(prime);
            }
        }

        private static int NextPrime(int prime)
        {
            int next = prime;
            for (int i = prime + 1; i < prime * 2; i++)
            {
                Boolean isPrime = true;
                for (int j=2; j<i/2+1; j++)
                {
                    if (i % j == 0) { isPrime = false; break; };
                }

                if (isPrime) return i;
            }
            return next;
        }


        public static void Exercise5()
        {
            const int numberOfTerms = 10;
            // * The 10 first tems in the Fibonacci sequence
            int i = 1;
            foreach (int value in InfinitePrime())
            {
                Console.WriteLine("Term {0}: {1}.", i, value);
                if (i++ == numberOfTerms)
                    break;
            }
            Console.WriteLine();

            // * Finite terms, stating how many terms we want
            i = 1;
            foreach (int value in FinitePrime(numberOfTerms))
                Console.WriteLine("Term {0}: {1}.", i++, value);
        }

        public static void ExtraEvenGenerator()
        {
            const int numberOfTerms = 10;
            // * The 10 first tems in the Fibonacci sequence
            int i = 1;
            foreach (int value in EvenGenerator())
            {
                Console.WriteLine("Term {0}: {1}.", i, value);
                if (i++ == numberOfTerms)
                    break;
            }
        }

    }
}
