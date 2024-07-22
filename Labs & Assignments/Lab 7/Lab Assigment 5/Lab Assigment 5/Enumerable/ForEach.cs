using System;
using System.Collections.Generic;
using System.Linq;

namespace TPP.Functional.HigherOrder {

    /// <summary>
    /// Extension methods for the Enumerable type
    /// </summary>
    public static class EnumerableExtensionMethods {

        /// <summary>
        /// Extension method to apply an action to the items in a collection
        /// </summary>
        /// <typeparam name="T">The type of the elements in the collection</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action">The action to be performed with every element in the collection</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action) {
            foreach (T item in collection)
                action(item);
        }

        /// <summary>
        /// Extension method to apply two actions to the items in a collection
        /// </summary>
        /// <typeparam name="T">The type of the elements in the collection</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action1">The first action to be performed with every element in the collection</param>
        /// <param name="action2">The second action to be performed with every element in the collection</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action1, Action<T> action2) {
            foreach (T item in collection) {
                action1(item);
                action2(item);
            }
        }

        public static void Show<T>(this IEnumerable<T> collection, String message="", String after=" ", String end="\n")
        {
            Console.Write(message);
            
            collection.ForEach(x => {
                Console.Write(x); Console.Write(after); //Console.WriteLine($"{x}{after}");
                });
            Console.Write(end);
        }

        public static void ForEachOdd<T>(this IEnumerable<T> collection, Action<T> action)
        {
            for (int i = 1; i < collection.Count(); i+=2)
            {
                    action(collection.ElementAt(i));
            }
        }

        public static void ForEachNth<T>(this IEnumerable<T> collection, Action<T> action, int n)
        {
            for (int i = 0; i < collection.Count(); i ++)
            {
                if(i%n==0)
                    action(collection.ElementAt(i));
            }
        }

        public static void ForEachNth<T>(this IEnumerable<T> collection, Action<T> action, Predicate<T> pred)
        {
            for (int i = 0; i < collection.Count(); i++)
            {
                if (pred(collection.ElementAt(i)))
                    action(collection.ElementAt(i));
            }
        }

        public static bool MyContains<T>(this IEnumerable<T> collection, T obj)
        {
            for (int i = 0; i < collection.Count(); i++)
            {
                if (collection.ElementAt(i).Equals(obj))
                    return true;
            }
            return false;
        }

        public static IDictionary<T,int> CountElementsContained<T>(this IEnumerable<T> collection) { 
            IDictionary<T, int> result = new Dictionary<T, int>();
            for (int i=0; i<collection.Count(); i++)
            {
                result[collection.ElementAt(i)] = 0;
                Action<T> Counting = (T elem) => {
                    //if (collection.ElementAt(i).Equals(elem))
                    if (collection.MyContains(elem))
                    {
                        result[elem] += 1;
                    }
                };

                collection.ForEach(Counting);
            }
            return result;
        }

        public static void EliminateRepeated<T>(this IEnumerable<T> collection)
        {
            IDictionary<T, int> counting= collection.CountElementsContained();
            


            var positiveOddNumbers = integers.Where(integer => integer % 2 != 0 && integer > 0);
            Console.Write("\nPositive odd numbers: [");
            positiveOddNumbers.ForEach(Console.Write, integer => Console.Write(", "));
            Console.WriteLine("]");

            // * People 18 and beyond
            var beyond18 = people.Where(person => person.Age >= 18);
            Console.WriteLine("\nPeople 18 and beyond:");
            beyond18.ForEach(Console.WriteLine);
        }
    }

}
