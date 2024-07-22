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
            Console.WriteLine(l2.toString());
            l2.printAllElements();
        }

        static void testRemoveFirst()
        {
            List l = new List(1);

            Console.WriteLine(l.toString());
            l.printAllElements();

            l.add(2);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.add(3);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.add(1);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.removeFirst();
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.removeFirst();
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.removeFirst();
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.removeFirst();
            Console.WriteLine(l.toString());
            l.printAllElements();

        }

        static void testAddLastAndRemoveByValue()
        {
            List l = new List(1);

            Console.WriteLine(l.toString());
            l.printAllElements();

            l.add(2);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.add(3);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.add(1);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.remove(1);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.remove(3);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.remove(1);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.remove(2);
            Console.WriteLine(l.toString());
            l.printAllElements();
        }

        static void testAddAtPosAndRemoveByPos()
        {
            List l = new List(1);

            Console.WriteLine(l.toString());
            l.printAllElements();

            l.add(2,0);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.add(3, 0);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.add(1,1);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.add(3, 2);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.add(3, 5);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.add(3, 7);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.removeByPosition(0);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.removeByPosition(1);
            Console.WriteLine(l.toString());
            l.printAllElements();

            l.removeByPosition(3);
            Console.WriteLine(l.toString());
            l.printAllElements();
        }
    }
}
