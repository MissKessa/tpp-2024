using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using LambdaFunctions;
using TPP.Functional.Continuations;
using TPP.Functional.HigherOrder;

namespace LinkedList
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //MeasureMemoizedPrime();
            Enumerable();
        }

        static void Enumerable()
        {
            IList<int> list = new List<int>() {1,2,3,4,5,6 };
            list.ForEach(x => Console.WriteLine(x));
        }

        static void Other()
        {
            IList<int> nums = new List<int>() { 2, 3, 4, 5 };
            Console.WriteLine(Lambda.ContainsDivisor(nums)(10));
            Console.WriteLine(Lambda.ContainsDivisor(nums)(9));
            Console.WriteLine(Lambda.ContainsDivisor(nums)(7));

            int i = 0;
            Lambda.RepeatUntilLoop(() => i == 10, () =>
            {
                Console.WriteLine(i + " ");
                i++;
            });

            int[,] a = new int[3, 4] {
             {0, 1, 2, 3} ,
             {4, 5, 6, 7} ,
             {8, 9, 10, 11} ,
             };
            int row = 0;
            int column = 0;
            Lambda.WhileLoop(() => (row < 3), () =>
            {
                Lambda.WhileLoop(() => (column < 4), () =>
                {
                    Console.Write("{0} ", a[row, column]);
                    column++;
                });
                Console.WriteLine();
                column = 0;
                row++;
            });

            i = 0;
            //Func<int> c = Lambda.ReturnCounter();
            Func<int> c = Lambda.Fibbonacci();
            while (i < 8)
            {
                Console.WriteLine(c()); //We call the returned function not the returnCounter
                i++;
            }

            const int numberOfTerms = 10;
            // * The 10 first tems in the Fibonacci sequence

            foreach (int value in Lambda.InfinitePrime())
            {
                if (value > 100)
                {
                    Console.WriteLine("Prime>100: {0}.", value);
                    break;
                }

            }
            Console.WriteLine();

            // * A new invocation is a new instance of the function
            //   and returns a new generator 
            var enumerator = Lambda.InfinitePrime().GetEnumerator();
            enumerator.MoveNext();
            Console.WriteLine("Term 1: {0}.", enumerator.Current);
            Console.WriteLine("");

            // * Finite terms, stating how many terms we want
            i = 1;
            foreach (int value in Lambda.FinitePrime(numberOfTerms))
                Console.WriteLine("Term {0}: {1}.", i++, value);
        }

        static void MeasureMemoizedPrime()
        {
            const int primeTerm = 10;
            bool result;

            var crono = new Stopwatch();
            crono.Start();
            result = MemoizedIsPrime.IsPrime(primeTerm);
            crono.Stop();
            long ticksMemoizationFirstCall = crono.ElapsedTicks;
            Console.WriteLine("Memoized version, first call: {0:N} ticks. Result: {1}.", ticksMemoizationFirstCall, result);

            crono.Restart();
            result = MemoizedIsPrime.IsPrime(primeTerm);
            crono.Stop();
            long ticksMemoizationSecondCall = crono.ElapsedTicks;
            Console.WriteLine("Memoized version, first call: {0:N} ticks. Result: {1}.", ticksMemoizationSecondCall, result);
        }

        static void LINQ() /// to run this you need: using System.Linq;
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

    }

}
