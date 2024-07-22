using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public static class Closure
    {
        //Example of a closure returning the next counter every time is call (the returned one)
        private static Func<int> ReturnCounter()
        {
            int counter = 0;
            return () =>
            {
                counter++;
                return counter;
            };
        }

        //Closure returning the next fibbonacci
        public static Func<int> NextFibbonacci()
        {
            int fib1 = 1;
            int fib2 = 1;
            int fib = -1;
            return () =>
            {
                if (fib < 1)
                {
                    fib++;
                    return 1;
                }
                fib = fib1 + fib2;
                fib1 = fib2;
                fib2 = fib;
                return fib;
            };

        }

        public static void Exercise4()
        {
            Func<int> fib=NextFibbonacci();

            int i = 0;
            while (i < 10)
            {
                Console.WriteLine(fib());
                i++;
            }
        }
    }
}
