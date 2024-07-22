using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Exam
{
    class Query
    {
        //WhileLoop closure, do not modify this
        static void WhileLoop(Func<bool> condition, Action body)
        {
            if (condition())
            {
                body();
                WhileLoop(condition, body);
            }
        }
        //IfElse closure, do not modify this
        static void IfElse(Func<bool> condition, Action ifBody, Action elseBody)
        {
            if (condition())
                ifBody();
            else
                elseBody();
        }
        //GCD Euclid's method to be refactored using the WhileLoop closure
        static int Gcd(int a, int b)
        {
            //replace with WhileLoop closure
            while (a != b)
                //replace with IfElse closure
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            return a;
        }

        //Funcion to be versioned using currying 
        static double ComposeDouble(Func<double, double> f, Func<double, double> g, double a)
        {
            return g(f(a));
        }

        private Model model = new Model();

        static void Main(string[] args)
        {

            //Exercise 1 call/s

            //Exercise 2 call/s            
            //Modify this, add the requested calls
            Console.WriteLine(MemoizedClass.Fibonacci(4));
            
            //Exercise 3 call/s

            //Exercies 4 call/s
             
            //Exercise 5 call/s
            Query query = new Query();
            query.QueryExercise5();
        }


        private void QueryExercise5()
        {
            
            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY Exercise 5 *** *** ***");
            //Implement Exercise 5 here

            Console.WriteLine();
        }
    }

}