using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;


namespace Lab11
{


    class Lab12
    {

        static void Main()
        {
            Exercise1.Execute();
            //Exercise2.Execute();
            //Exercise3.Execute();
            //Exercise4.Execute();
            //Exercise5.Execute();

            //Show(AwesomeHist(CreateRandomIntVector(10000, 0, 5)));
        }
        static IDictionary<int, int> AwesomeHist(IEnumerable<int> col)
        {
            //return col.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            return col.AsParallel().GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        }

        private static void ExampleOverloadedParallelFor()
        {
            int[] nums = Enumerable.Range(0, 1_000_000).ToArray();
            long total = 0;

            // Use type parameter to make subtotal a long, not an int
            Parallel.For<long>(
                0, 
                nums.Length, 
                () => 0, //how you intiialize the result foreach individual thread. You can do ()=> new List<int>()....
                (j, loop, subtotal) => //Lambda applied by each thread to each data. j is a control variable, subtotal is at what is initialized before (()=>0). So it first has value 0
                { //here I don't need synchronization,as they are local variables of each thread
                    subtotal += nums[j];
                    return subtotal;
                },
                subtotal => Interlocked.Add(ref total, subtotal)); //done at the end by all the threads (subtotal parameter is the result of the line before). You need to use synchronization emchanisms

            Console.WriteLine("The total is {0:N0}", total);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void ExampleOverloadedParallelForEach()
        {
            int[] nums = Enumerable.Range(0, 1000000).ToArray();
            long total = 0;

            // First type parameter is the type of the source elements
            // Second type parameter is the type of the thread-local variable (partition subtotal)
            Parallel.ForEach<int, long>(
                nums, // source collection
                () => 0, // method to initialize the local variable
                (j, loop, subtotal) => // method invoked by the loop on each iteration
                {
                    subtotal += j; //modify local variable
                    return subtotal; // value to be passed to next iteration
                },
                // Method to be executed when each partition has completed.
                // finalResult is the final value of subtotal for a particular partition.
                (finalResult) => Interlocked.Add(ref total, finalResult));

            Console.WriteLine("The total from Parallel.ForEach is {0:N0}", total);
        }


        private static void ExampleOverloadedAggregate()
        {
            // Create a data source for demonstration purposes.
            int[] source = new int[100000];
            Random rand = new Random();
            for (int x = 0; x < source.Length; x++)
            {
                // Should result in a mean of approximately 15.0.
                source[x] = rand.Next(10, 20);
            }

            // Standard deviation calculation requires that we first
            // calculate the mean average. Average is a predefined
            // aggregation operator, along with Max, Min and Count.
            double mean = source.AsParallel().Average(); //Creates LINQ parallel by adding list.AsParallel().nameLINQMethod()

            // We use the overload that is unique to ParallelEnumerable. The
            // third Func parameter combines the results from each thread.
            double standardDev = source.AsParallel().Aggregate(
                // initialize subtotal. Use decimal point to tell
                // the compiler this is a type double. Can also use: 0d.
                0.0,

                 // do this on each thread
                 (subtotal, item) => subtotal + Math.Pow((item - mean), 2),

                 // aggregate results after all threads are done.
                 (total, thisThread) => total + thisThread, //this is thread safe

                // perform standard deviation calc on the aggregated result.
                (finalSum) => Math.Sqrt((finalSum / (source.Length - 1))) //if you don't want to do anything here, you just reaplace it by (x)=>x
            );
            Console.WriteLine("Mean value is = {0}", mean);
            Console.WriteLine("Standard deviation is {0}", standardDev);
            Console.ReadLine();
        }

    }
}
