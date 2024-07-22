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
            Master master = new Master(vector, 1);
            DateTime before = DateTime.Now;
            double result = master.ComputeTimesAbove(threshold);
            DateTime after = DateTime.Now;
            //remove the format
            Console.WriteLine("Result with one thread: {0}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks );

            master = new Master(vector, 4);
            before = DateTime.Now;
            result = master.ComputeTimesAbove(threshold);
            after = DateTime.Now;
            Console.WriteLine("Result with 4 threads: {0}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);
        }

        //delete this, it is unused

        //public static short[] CreateRandomVector(int numberOfElements, short lowest, short greatest) {
        //    short[] vector = new short[numberOfElements];
        //    Random random = new Random();
        //    for (int i = 0; i < numberOfElements; i++)
        //        vector[i] = (short)random.Next(lowest, greatest + 1);
        //    return vector;
        //}

    }

}
