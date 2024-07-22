using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace exam.ex5
{
    static class Program
    {
        private static int init;

        static void Main(string[] args)
        {
            int[,] a = new int[3, 4] { { 0, 1, 2, 3 }, { 4, 5, 6, 7 }, { 8, 9, 10, 11 } };            
            ForLoop((value) => value = 0, (value) => value < 5, (value) => value++, (value) => Console.Out.Write(value), 5);
        }

        public static void ForLoop<T>(Action<int> initialization, Predicate<int> condition, Action<int> update, Action<T> body, T param)
        {
            initialization(init);
            if (condition(init))
            {
                update(init);
                body(param);
                ForLoop((value) => value = init, condition, update, body, param);
            }
        }
    }
}
