using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Functional.Delegates {

    class Program {

        /// <summary>
        /// Delegate that receives two integers and returns another integer
        /// </summary>
        private delegate int BinaryOperation(int a, int b);

        private static int Add(int a, int b)
        { //Same type as BinaryOperation (receive 2 ints, returns int)
            return a + b;
        }

        private static int Sub(int a, int b)
        { //Same type as BinaryOperation (receive 2 ints, returns int)
            return a - b;
        }

        /// <summary>
        /// Higher-order function that receives a function and applies (invokes) it
        /// twice to the second argument
        /// </summary>
        private static int DoubleApplication(Func<int,int> function, int integer)
        { // Func<int,int> function is not same type as DoubleApplication ( function receives one int and returns one int). if it was Func<int, int, itn>, it would be
            return function(function(integer));
        }

        private static int Twice(int integer) {
            return integer + integer;
        }

        private static bool IsEven(int a) {
            return a % 2 == 0;
        }

        private static void ShowInRed(string str) {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ForegroundColor = color;
        }

        private static bool PersonAge18OrBeyond(Person person) {
            return person.Age >= 18;
        }

        static void Main() {
            const int a = 2, b = 1;

            // * A delegate variable using a user defined type 
            BinaryOperation operation = Program.Add;
            Console.WriteLine("Addition: {0}", operation(a, b));
            operation = Program.Sub;
            Console.WriteLine("Subtraction: {0}", operation(a, b));

            // * A delegate variable using a predefined type 
            Func<int, int, int> function = Program.Add; //we can do it because add receives 2 ints and returns an int
            Console.WriteLine("Addition: {0}", function(a, b));
            function = Program.Sub;
            Console.WriteLine("Subtaction: {0}", function(a, b));

            // * The DoubleApplication higher-order function is called,
            //   passing another Twice (Func<int,int>) funcion as a parameter
            Console.WriteLine("Double application of twice: {0}", DoubleApplication(Twice, 3)); //DoubleApp takes a func<int, int> and an int. Twice receives an int, and returns an int

            // * Two more variables of predefined delegate types
            Predicate<int> isEven = Program.IsEven; //Assign to a predicate is even. Here we type the parameters onl, because Predicate as returns a Boolean always
            Action<string> show; //Action returns void always
            if (isEven(a))
                show = Program.ShowInRed;
            else
                show = Console.WriteLine;
            show("Hello world!");

            // * A BCL higher-order method (FindAll) is called, 
            //   passing a predicate delegate as a parameter
            Person[] people = PersonPrintout.CreatePeopleRandomly();
            Person[] beyond18 = Array.FindAll(people, Program.PersonAge18OrBeyond);
            beyond18.ForEach(Console.WriteLine);
        }


    }

}
