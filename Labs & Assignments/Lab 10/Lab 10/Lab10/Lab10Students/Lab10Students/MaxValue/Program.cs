using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace MaxValueApp
{
    internal class Program
    {
        public static int[] CreateRandomVector(int numberOfElements, int lowest, int greatest)
        {
            int[] vector = new int[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = random.Next(lowest, greatest + 1);
            return vector;
        }
        static void Main(string[] args)
        {
            int m = 100000, times=10;
            int[] a= CreateRandomVector(m, 0, m); //Create a random vector with 100000 elements
            Random random= new Random();
                      
            for (int i = 0; i < times; i++)
            {
                MaxValue x = new MaxValue(0); //define a new object
                Parallel.For(0, m, //It's a parallel for loop: from thread 0 to m-1 threads. The order of execution isn't guarantee at all
                    (i) =>
                    {
                        x.Value = a[i]; //this is executed with the value of i, and different threads. You need synchronization mechanisms
                    });
                Console.WriteLine($"{a.Max()}, {x.Value}"); //They must be equal
            }
        }
    }
}
