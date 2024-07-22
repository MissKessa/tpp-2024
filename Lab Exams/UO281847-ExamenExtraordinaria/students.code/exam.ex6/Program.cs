using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace exam.ex6
{
    class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            int[] array = GenerateRandomVector(50);
            Console.WriteLine("\nThe vector is: ");
            Show(array);

            Console.WriteLine("\nCalculating the positions");
            Master<int> master = new Master<int>(array, 4);
            var dictionary = master.ComputeDictionary();

            int lengthSummation = 0;
            foreach (var keyValue in dictionary)
            {
                Console.Write($"[{keyValue.Key}] : ");
                Show(keyValue.Value);
                lengthSummation += keyValue.Value.Count();
            }

            Console.WriteLine($"\nLa suma de las longitudes es: {lengthSummation}");
        }

        private static void Show(IEnumerable<int> collection)
        {
            Console.Write("{ ");
            int counter = 0; 
            foreach (var element in collection)
            {
                if (counter == collection.Count() -1)
                {
                    Console.Write($"{element}");
                } else
                {
                    Console.Write($"{element}, ");
                }
                counter++;
            }
            Console.Write(" }\n");
        }

        public static int[] GenerateRandomVector(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 50);
            }
            return array;
        }
    }
}
