using System;
using Intervals;
namespace ConsoleApp3
{
    internal class Program
    {
        private class Maximum
        {
            static IMedible Max(IMedible a, IMedible b) // code here the polymorphic method, returns IMedible, takes two Imedible as arguments
            {
                if (a.Size()>b.Size())
                {
                    return a;
                }
                return b;
            }
        }
        

        static void Main(string[] args)
        {
            // check all the methods and constructors for each type (Interval, Bar), use try/catch/finally
            Interval i1= new Interval();
            i1.ToString();
            try
            {
                Interval i2 = new Interval();
            }

        }
    }
}
