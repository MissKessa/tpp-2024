using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab7
{
    public static class FunctionalProgramming7
    {
        //Outputs to console each element.
        public static void Show<T>(IEnumerable<T> e, String messageBefore="", String separator=" ", String end = "\n")
        {
            Console.WriteLine(messageBefore); 
            foreach(T item in e)
            {
                Console.Write(item);
                Console.Write(separator);
            }
            Console.Write(end);
        }

        public static void ForEach<T>(IEnumerable<T> e, Action<T> a) //applies an action to the all elements
        {
            for (int i = 0; i < e.Count(); i ++)
            {
                a(e.ElementAt(i));
            }
        }

        public static void ForEachOdd<T>(IEnumerable<T> e, Action<T> a) //applies an action to the odd positions
        {
            for(int i=1; i < e.Count(); i+=2)
            {
                a(e.ElementAt(i));
            }
        }

        public static void ForEachNth<T>(IEnumerable<T> e, Action<T> a, int pos) //applies an action to the positions multiples of n
        {
            for (int i = 0; i < e.Count(); i +=pos)
            {
                a(e.ElementAt(i));
            }
        }

        public static void ForEachPred<T>(IEnumerable<T> e, Action<T> a, Predicate<T> p) //applies an action to the elements that satisfy the predicate
        {
            foreach (T item in e)
            {
                if (p(item)) a(item);
            }
        }

        public static bool MyContains<T>(this IEnumerable<T> e, T element) //returns true if the caller constains the parameter
        {
            foreach(T item in e)
            {
                if (item.Equals(element)) return true;
            }
            return false;
        }

        public static bool MyContainsFunctional<T>(this IEnumerable<T> e, T element) //returns true if the caller constains the parameter
        {
            bool result = false;
            ForEach(e,(x) =>
            {
                if (x.Equals(element))
                {
                    result = true;
                    return; //To stop
                }
            });
            return result;
        }

        public static IDictionary<T, int> Count<T>(IEnumerable<T> e) //counts how many times each value is repeated in a collection
        {
            IDictionary<T, int> counter= new Dictionary<T, int>();
            Action<T> a = (item) => {
                if (e.MyContains(item)) {
                    if (!counter.Keys.Contains(item))
                    {
                        counter.Add(item, 0);
                    }
                    counter[item]++;
                }
            };
            ForEach(e, a);
            return counter;
        }

        private static void WhileLoop(Func<bool> condition, Action body)
        {
            if (condition())
            {
                body();
                WhileLoop(condition, body); // recursion to iterate
            }
        }

        public static void ForEachFunctional<T>(IEnumerable<T> e, Action<T> a) //applies an action to the all elements
        {
            IEnumerator enumerator = e.GetEnumerator();

            //while (enumerator.MoveNext())
            //{
            //    T item= (T)enumerator.Current;
            //    a(item);
            //}

            WhileLoop(() => enumerator.MoveNext(), () => {
                T item = (T)enumerator.Current;
                a(item);
            });

        }

        public static void Exercise1_1()
        {
            IEnumerable<int> e= new List<int>() { 1, 2, 3, 4, 5 };
            Show(e);
        }

        public static void Exercise1_2()
        {
            IEnumerable<int> e = new List<int>() { 1, 2, 3, 4, 5 };
            ForEachOdd(e, (x) => { Console.Write($"{x} "); });
        }

        public static void Exercise1_3()
        {
            IEnumerable<int> e = new List<int>() { 1, 2, 3, 4, 5 };
            ForEachNth(e, (x) => { Console.Write($"{x} "); }, 3);
        }

        public static void Exercise1_4()
        {
            IEnumerable<int> e = new List<int>() { 1, 2, 3, 4, 5 };
            ForEachPred(e, (x) => { Console.Write($"{x} "); }, (x)=>x%2==0);
        }

        public static void Exercise1_5()
        {
            IEnumerable<int> e = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine(e.MyContains(1));
            Console.WriteLine(e.MyContains(2));
            Console.WriteLine(e.MyContains(6));
        }

        public static void Exercise1_6()
        {
            IEnumerable<int> e = new List<int>() { 1, 1, 2, 3, 4, 4 };
            var counter = Count(e);
            foreach(var item in counter)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }

        public static void Exercise1_7()
        {
            IEnumerable<int> e = new List<int>() { 1, 2, 3, 4, 5 };
            ForEachFunctional(e, (x) => { Console.Write($"{x} "); });
        }
    }
}
