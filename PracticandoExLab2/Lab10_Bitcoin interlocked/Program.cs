using System;
using Lab09;
namespace TPP.Laboratory.Concurrency.Lab09 {
    
    public class VectorModulusProgram {

        static void Main(string[] args) {
            //add using Lab09
            //make Utils public
            //place vector modulus .cs files into Lab09 folder as a workarround for data folder path
            //show to the students the fields of BitCoinValueData, .Value is double
            //assign to vector the bitcoin value data
            var vector = Utils.GetBitcoinData();

            double threshold = 7000;
            CountInterLocked master = new CountInterLocked(vector, 1);
            DateTime before = DateTime.Now;
            double result = master.ComputeTimesAbove(threshold);
            DateTime after = DateTime.Now;
            //remove the format
            Console.WriteLine("Result with one thread: {0}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks );

            master = new CountInterLocked(vector, 4);
            before = DateTime.Now;
            result = master.ComputeTimesAbove(threshold);
            after = DateTime.Now;
            Console.WriteLine("Result with 4 threads: {0}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);
        }

    }

}
