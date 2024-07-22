using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace exam.ex7
{
    static class Program
    {
        static void Main(string[] args)
        {
            int[] enteros = { 1, 1, 2, 3, 5, 4, 2 };            
            foreach (var item in enteros.Subsequences())
            {
                Console.Write("(");
                foreach (var element in item)
                {
                    Console.Write($"{element} ");
                }
                Console.Write(")");
            }
            Console.WriteLine();
            string[] caracteres = { "a", "b", "b", "f", "f", "b", "c", "m", "c", "b", "a", "a", "z"};
            foreach (var item in caracteres.Subsequences())
            {
                Console.Write("(");
                foreach (var element in item)
                {
                    Console.Write($"{element} ");
                }
                Console.Write(")");
            }
            Console.WriteLine();
        }

        static IEnumerable<IEnumerable<T>> Subsequences<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            var list = new List<T>();
            var iterator = collection.GetEnumerator();
            iterator.MoveNext();
            T nextItem = iterator.Current;            
            foreach (var item in collection)
            {
                if (iterator.MoveNext())
                {
                    nextItem = iterator.Current;
                }
                if (nextItem.CompareTo(item) >= 0)
                {
                    list.Add(item);
                }
                else if (nextItem.CompareTo(item) < 0)
                {
                    yield return list;
                    list = new List<T>();
                }
            }
        }
    }
}
