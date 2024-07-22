using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Structures
    {
        //Structure that behaves like an if-else structure.
        public static T IfElse<T>(T x, Predicate<T> p, Func<T,T> ifF, Func<T, T>elseF)
        {
            if(p(x)) return ifF(x);
            return elseF(x);
        }
        /// <summary>
        /// High-order function that simulates a While control structure
        /// </summary>
        /// <param name="condition">Function to be evaluated at the begining of each iteration,
        /// know whether the loop has finished or not</param>
        /// <param name="body">A function (action) modeling the loop body</param>
        private static void WhileLoop(Func<bool> condition, Action body)
        {
            if (condition())
            {
                body();
                WhileLoop(condition, body); // recursion to iterate
            }
        }

        //Repeats body until condition is true, body is executed at leat one (1st body is executed then condition is tested)
        public static void RepeatUntilLoop(Func<bool> condition, Action body)
        {
            body();
            if (!condition())
            {
                RepeatUntilLoop(condition, body);
            }
        }

        public static void Exercise2()
        {
            int i = 0;
            Func<bool> condition = () => { return i > 9; };
            Action body = () =>
            {
                Console.WriteLine(i);
                i++;
            };
            RepeatUntilLoop(condition, body);

        }

        public static void Exercise3()
        {
            int[,] a = new int[3, 4] {
                { 0, 1, 2, 3 },
                { 4, 5, 6, 7},
                {8, 9, 10, 11},
            };

            int row = 0;
            int column = 0;
            //while (row < 3)
            //{
            //    while (column < 4)
            //    {
            //        Console.Write("{0} ", a[row, column]);
            //        column++;
            //    }
            //    Console.WriteLine();
            //    column = 0;
            //    row++;
            //}

            Func<bool> outerCond = () => row < 3;
            Func<bool> innerCond = () => column < 4;

            Action innerBody = () => {
                Console.Write("{0} ", a[row, column]);
                column++;
            };

            Action outerBody = () =>
            {
                WhileLoop(innerCond, innerBody);
                Console.WriteLine();
                column = 0;
                row++;
            };

            WhileLoop(outerCond, outerBody);
        }

        public static void ExtraIfElse()
        {
            Console.WriteLine(IfElse(2,(x)=>(x%2==0), (x)=>x*x,(x)=>x*3));
            Console.WriteLine(IfElse(3, (x) => (x % 2 == 0), (x) => x * x, (x) => x * 3));
        }
        
    }
}
