using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace Lab5
{
    public static class FunctionalProgramming
    {
        public static void Exercise1()
        {
            Func<double, double> asinh = delegate (double x) { return Math.Log(x + Math.Sqrt(x *x + 1)); };
            Func<double, double> asinh2 = (double x) => { return Math.Log(x + Math.Sqrt(x * x + 1)); };
            Func<double, double> asinh3 = (x) => { return Math.Log(x + Math.Sqrt(x * x + 1)); };
            Func<double, double> asinh4 = (x) => (Math.Log(x + Math.Sqrt(x * x + 1)));
            Func<double, double> asinh5 = (x) => Math.Log(x + Math.Sqrt(x * x + 1));
        }

        public static void ApplyAction<T> (IEnumerable<T> e, Action<T> a) //Applies the action to each element of e
        {
            foreach(var item in e)
            {
                a(item);
            }
        }
        public static void Exercise2()
        {
            IEnumerable<int> l = new List<int>() { 1,2,3,4,5};
            Action<int> a = (x) => Console.Write($"{x} ");
            ApplyAction<int>(l, a);
        }

        public static int Count<T>(IEnumerable<T> v, Predicate<T> p) //returns an int with the number of elements that verify the predicate
        {
            int counter = 0;
            foreach (var item in v)
            {
                if(p(item)) counter++;
            }
            return counter;
        }

        public static int CountApplyAction<T>(IEnumerable<T> v, Predicate<T> p) //count using applyaction
        {
            int counter = 0;
            Action<T> a= (x) =>{ if (p(x)) { counter++; } } ;

            ApplyAction<T>(v, a);
            return counter;
        }

        public static void Exercise3()
        {
            IEnumerable<int> l = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine(Count<int>(l, (x) => x % 2 == 0)); //writing the predicate in the parameters list

            Predicate<int> primes = delegate (int x) {
                if (x == 1 || x == 0) return false;
                for(int i=2; i < x/2 + 1; i++)
                {
                    if (x % i == 0) return false;
                }
                return true;
            };

            Console.WriteLine(Count<int>(l, primes));
            Console.WriteLine(CountApplyAction<int>(l, primes));
        }

        public static int FindFirst<T>(IEnumerable<T> v, Predicate<T> p) //returns the position of the first element that satisfies p. Returns -1 if not found
        {
            int pos = 0;
            foreach (var item in v)
            {
                if (p(item)) return pos;
                pos++;
            }
            return -1;
        }

        public static int FindFirstApplyAction<T>(IEnumerable<T> v, Predicate<T> p) //With ApplyAction
        {
            int pos = -1;
            int i = 0;
            bool found = false;
            Action<T> action = (x) => { if (!found) { if (p(x)) { pos = i; found = true; } } i++; };

            ApplyAction<T>(v, action);
            return pos;
        }

        public static void Exercise4()
        {
            IEnumerable<int> l = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine(FindFirst<int>(l, (x) => x % 2 == 0)); //writing the predicate in the parameters list

            Predicate<int> primes = delegate (int x) {
                if (x == 1 || x == 0) return false;
                for (int i = 2; i < x / 2 + 1; i++)
                {
                    if (x % i == 0) return false;
                }
                return true;
            };

            Console.WriteLine(FindFirst<int>(l, primes));
            Console.WriteLine(FindFirstApplyAction<int>(l, primes));
        }

        

        public static Func<double, double> ComposeDouble(Func<double, double> f, Func<double, double> g)
        { //returns g(f(x))

            return (double x) => { return g(f(x)); };
        }

        public static void Exercise5()
        {
            Func<double, double> g_f = ComposeDouble((x) => { return x * x; }, (x) => { return Math.Log2(x); });
            Console.WriteLine(g_f(2));
            Console.WriteLine(g_f(4));
        }

        public static Func<T1,T3> ComposeG<T1,T2,T3>(Func<T1, T2> f, Func<T2, T3> g) //returns g(f(x))
        {
            return (T1 x) => { return g(f(x)); };
        }

        public static void Exercise6()
        {
            Func<int,int> Increment = (int x) => { return x+1; }; //increments an int
            Func<char,int> ToInt = (char x) => { return (int)x; }; //casts char to int
            Func<int, char> ToChar = (int x) => { return (char)x; };//casts int to char

            //char->int->increment->char
            Func<char, int> NextInt = ComposeG<char, int, int>(ToInt, Increment);
            Func<char, char> NextChar = ComposeG<char, int, char>(NextInt, ToChar);

            Console.WriteLine(NextChar('a'));
        }

        public static bool Exists(IEnumerable<int>v, Predicate<int> p) //returns true if at least there's one element that satisifies 
        {
            foreach (int x in v)
            {
                if (p(x)) return true;
            }
            return false;
        }

        public static void Exercise7()
        {
            IList<int> v = new List<int>() { 2 };

            for (int i = 3; i < 10; i++)
            {
                Predicate<int> p = (x) => { return i % x == 0; };
                if (!Exists(v, p))
                {
                    v.Add(i);
                }
            }

            foreach(int x in v)
            {
                Console.Write($"{x} ");
            }
        }
    }
}
