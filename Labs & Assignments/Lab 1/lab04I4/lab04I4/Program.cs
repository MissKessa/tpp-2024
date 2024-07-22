using System;
using System.Runtime.CompilerServices;

namespace TPP.Lab04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point2D a = new Point2D(1, 2, Color.Black),
                    b = new Point2D(1, 1, Color.Transparent),
                    c = new Point2D {C=Color.Red, Y=0, X=1 }; //allows us to create an object with any order of parameters

            Line l = new Line(1, 2);
            Console.WriteLine($"Distance from {a} to {b} is {a.Distance(b)}");
        }
    }
}
