using System;
using System.IO;
using System.Numerics;


namespace Lab09
{

    class Program
    {
        /*
         * This program processes Bitcoin value information obtained from the
         * url https://api.kraken.com/0/public/OHLC?pair=xbteur&interval=5.
         */
        static void Main(string[] args)
        {
            const int maxNumberOfThreads = 50;
            var data = Utils.GetBitcoinData();
            ShowLine(Console.Out, "Number of threads", "Ticks", "Result");
            for (int numberOfThreads = 1; numberOfThreads <= maxNumberOfThreads; numberOfThreads++)
            {
                long ticks = 0;
                DateTime before = DateTime.Now;
                DateTime after = DateTime.Now;
                double result = 0;
                for (int i = 0; i < 2; i++)
                {
                    //Better if we execute this 30 times, and do the average for each
                    Master master = new Master(data, 7000, numberOfThreads);
                    before = DateTime.Now;
                    result = master.ComputeBitcoinValueOver();
                    after = DateTime.Now;
                    ticks+= (after - before).Ticks;

                    //Explicity call the garbage collector, to make the time measured more precise:
                    GC.Collect(); // Garbage collection
                    GC.WaitForFullGCComplete();
                }
                ticks = ticks / 2;
                ShowLine(Console.Out, numberOfThreads,ticks , result);
            }
        }

        private const string CSV_SEPARATOR = ";";

        static void ShowLine(TextWriter stream, string numberOfThreadsTitle, string ticksTitle, string resultTitle)
        {
            stream.WriteLine("{0}{3}{1}{3}{2}{3}", numberOfThreadsTitle, ticksTitle, resultTitle, CSV_SEPARATOR);
        }

        static void ShowLine(TextWriter stream, int numberOfThreads, long ticks, double result)
        {
            stream.WriteLine("{0}{3}{1:N0}{3}{2:N2}{3}", numberOfThreads, ticks, result, CSV_SEPARATOR);
        }

        private static void testEqualResults()
        {
            var data = Utils.GetBitcoinData(); //Assigns the data (BitcoinValueData array)
            //foreach (var d in data)
            //    Console.WriteLine(d);

            Master master = new Master(data, 7000, 1); //With one thread
            DateTime before = DateTime.Now;
            int result = master.ComputeBitcoinValueOver();
            DateTime after = DateTime.Now;
            Console.WriteLine("Result with one thread: {0:N2}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);

            master = new Master(data, 7000, 4); //With 4 threads
            before = DateTime.Now;
            result = master.ComputeBitcoinValueOver();
            after = DateTime.Now;
            Console.WriteLine("Result with 4 threads: {0:N2}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);
        }
    }
}
