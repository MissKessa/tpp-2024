using System;
using System.Collections.Generic;

namespace Lab1_Assigment
{
    internal class Program
    {

        //static void Main(string[] args)
        //{
        //    testDefaultConstructor();
        //    Console.WriteLine("--------------");
        //    testAddLastAndRemoveByValue();
        //    Console.WriteLine("--------------");
        //    testAddAtPosAndRemoveByPos();
        //    //Console.WriteLine("--------------");
        //    //testRemoveFirst();
        //}

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
             

            l.AddValue(2);
            Console.WriteLine(l.toString());
             

            l.AddValue(3);
            Console.WriteLine(l.toString());
             

            l.AddValue(1);
            Console.WriteLine(l.toString());
             

            l.RemoveFirst();
            Console.WriteLine(l.toString());
             

            l.RemoveFirst();
            Console.WriteLine(l.toString());
             

            l.RemoveFirst();
            Console.WriteLine(l.toString());
             

            l.RemoveFirst();
            Console.WriteLine(l.toString());
             

        }

        static void testAddLastAndRemoveByValue()
        {
            List l = new List(1);

            Console.WriteLine(l.toString());
             

            l.AddValue(2);
            Console.WriteLine(l.toString());
             

            l.AddValue(3);
            Console.WriteLine(l.toString());

            l.AddValue(1);
            Console.WriteLine(l.toString());
            

            l.RemoveByValue(1);
            Console.WriteLine(l.toString());

            l.RemoveByValue(3);
            Console.WriteLine(l.toString());


            l.RemoveByValue(1);
            Console.WriteLine(l.toString());
           
            l.RemoveByValue(2);
            Console.WriteLine(l.toString());
            
        }

        static void testAddAtPosAndRemoveByPos()
        {
            List l = new List(1);

            Console.WriteLine(l.toString());
             

            l.AddValueAtPosition(2, 0);
            Console.WriteLine(l.toString());
             

            l.AddValueAtPosition(3, 0);
            Console.WriteLine(l.toString());
             

            l.AddValueAtPosition(1, 1);
            Console.WriteLine(l.toString());
             

            l.AddValueAtPosition(3, 2);
            Console.WriteLine(l.toString());
             

            l.AddValueAtPosition(3, 5);
            Console.WriteLine(l.toString());
             

            l.AddValueAtPosition(3, 7);
            Console.WriteLine(l.toString());
             

            l.RemoveByPosition(0);
            Console.WriteLine(l.toString());
             

            l.RemoveByPosition(1);
            Console.WriteLine(l.toString());
             

            l.RemoveByPosition(3);
            Console.WriteLine(l.toString());
             
        }
    }
}

