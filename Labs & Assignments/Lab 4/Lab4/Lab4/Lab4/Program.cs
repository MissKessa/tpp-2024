using ClassLibrary1;
using System;
using System.Collections;
using System.Collections.Generic;
using TPP.ObjectOrientation.Generics;

namespace Lab4
{
    internal class Program
    {
        static int[] RandomIntArray(int n, int min=0, int max=10)
        {
            int[] array = new int[n];
            Random random=new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(min,max+1);
            }
            return array;
        }

        static Pair<Int32>[] RandomIntPairArray(int n, int min = 0, int max = 10)
        {
            Pair<Int32>[] array = new Pair<Int32>[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                int first = random.Next(min, max + 1);
                int second= random.Next(min, max + 1); 
                array[i] = new Pair<Int32>(first, second);
            }
            return array;
        }

        static Pair<Char>[] RandomCharPairArray(int n)
        {
            Pair<Char>[] array = new Pair<Char>[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                char first = (char)random.Next(65, 91);
                char second = (char)random.Next(65, 91); 
                array[i] = new Pair<Char>(first, second);
            }
            return array;
        }

        static char[] RandomCharArray(int n)
        {
            char[] array = new char[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = (char)random.Next(65,91);
            }
            return array;
        }

        static void Show<T>(IEnumerable<T> collection)
        {
            foreach (T item in collection)
                Console.WriteLine($"{item}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var intarray = RandomIntArray(10);
            var chararray = RandomCharArray(10);
            var intPairArray = RandomIntPairArray(10);
            //Show(intarray);
            //Algorithms.Sort(intarray);
            //Show(intarray);

            Show(intPairArray);
            Algorithms.Sort(intPairArray);
            Show(intPairArray);
            Console.WriteLine($"Max={Algorithms.Max(intPairArray)}"); 
            
        }
    }
}
