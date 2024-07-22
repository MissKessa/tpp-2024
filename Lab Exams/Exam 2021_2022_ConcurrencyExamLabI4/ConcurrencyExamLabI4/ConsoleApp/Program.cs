using System;
using System.Collections.Generic;
using System.Linq;
using task.parallelism;

namespace ExamLI4
{
    internal class Program
    {
        //Make this thread safe
        //do not introduce unnecesary bottlenecks
        static class MemoizedPow
        {
            internal static IDictionary<(int, int), int> values = new Dictionary<(int, int), int>();
            internal static int MemoPow(int powBase, int powExp)
            {
                if (values.Keys.Contains((powBase, powExp)))
                {
                    return values[(powBase, powExp)];
                }
                int value = (int)Math.Pow(powBase, powExp);
                values.Add((powBase, powExp), value);
                return value;
            }
            internal static int GetNumberOfValues()
            {
                return values.Count;
            }
        }

        public static void Show<T>(IEnumerable<T> col)
        {
            foreach (var e in col)
                Console.Write($"{e} ");
            Console.WriteLine();
        }
        //this is a serial version, for testing purposes
        //it is not specially efficient
        static int LcmSerial(int a, int b)
        {
            if (a > b)
            {
                int temp = a;
                a = b;
                b = temp;
            }
            int lcm = a * b;
            for (int i = b; i < a * b; i++)
                if (i % a == 0 && i % b == 0)
                {
                    lcm = i;
                    break;
                }
            return lcm;
        }
        static void Main(string[] args)
        {

            //Exercise 2
            Random r = new Random();
            const int times = 20;
            List<(int, int, int)> results = new List<(int, int, int)>();
            //replace with a parallel For
            //make use of synchronization mechanisms if needed,
            //do not introduce unnecesary bottlenecks
            for (int i = 0; i < times; i++)
            {
                int basePow = r.Next(0, 4);
                int expPow = r.Next(0, 4);
                results.Add((basePow, expPow, MemoizedPow.MemoPow(basePow, expPow)));
                if (r.NextDouble() > 0.5)
                    Console.WriteLine(MemoizedPow.GetNumberOfValues());
            }
            Show(results);
            //Exercise 3
            Console.WriteLine("Exercise 3");
            String text = TextProcessing.ReadTextFile(@"..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);
            //just to make sure the text is read correctly
            Show(words.Skip(1000).Take(10));
            //Write here the call to the requested method using words as parameter

            //Exercises 4 and 5
            const int min = 10, max = 40;          
            Console.WriteLine("Exercises 4 and 5");
            for (int i = 0; i < times; i++)
            {
                int a = r.Next(min, max), b = r.Next(min, max);
                //for testing purposes use the serial version
                Console.WriteLine("a={0} b={1} lcm: {2}",
                    a, b, LcmSerial(a, b)
                    //add here the call to the requested methods
                    //in exercises 4 and 5
                    //with a and b as parameters

                    );
            }
        }
    }
}
