using System;
using System.Collections.Generic;

namespace Lab_1_Assignment
{
    internal class Program
    {

        static void Main(string[] args)
        {
            testDefaultConstructor();
            Console.WriteLine("--------------");
            testAddLastAndRemoveByValue();
            Console.WriteLine("--------------");
            testAddAtPosAndRemoveByPos();
            Console.WriteLine("--------------");
            testRemoveFirst();
        }

        static void testDefaultConstructor()
        {
            List l2 = new List();
            Console.WriteLine(l2.ToString());
            l2.PrintAllElements();
        }

        static void testRemoveFirst()
        {
            List l = new List(1);

            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Add(2);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Add(3);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Add(1);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.RemoveFirst();
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.RemoveFirst();
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.RemoveFirst();
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.RemoveFirst();
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

        }

        static void testAddLastAndRemoveByValue()
        {
            List l = new List(1);

            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Add(2);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Add(3);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Add(1);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Remove(1);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Remove(3);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Remove(1);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Remove(2);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();
        }

        static void testAddAtPosAndRemoveByPos()
        {
            List l = new List(1);

            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Add(2,0);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Add(3, 0);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Add(1,1);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Add(3, 2);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Add(3, 5);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.Add(3, 7);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.RemoveByPosition(0);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.RemoveByPosition(1);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();

            l.RemoveByPosition(3);
            Console.WriteLine(l.ToString());
            l.PrintAllElements();
        }
    }
}
