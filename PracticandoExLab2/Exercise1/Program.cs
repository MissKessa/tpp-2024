using System;

namespace TPP.Laboratory.Concurrency.Lab09 {
    
    public class VectorModulusProgram {

        public static void Exercise1() {
            short[] vector = CreateRandomVector(100000, -10, 10);
            short[] vector2 = CreateRandomVector(100000, -10, 10);

            Master master = new Master(vector,vector2, 1); //With one thread
            DateTime before = DateTime.Now;
            double result = master.ComputeModulus();
            DateTime after = DateTime.Now;
            Console.WriteLine("Result with one thread: {0:N2}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks );

            master = new Master(vector,vector2, 4); //With 4 threads
            before = DateTime.Now;
            result = master.ComputeModulus();
            after = DateTime.Now;
            Console.WriteLine("Result with 4 threads: {0:N2}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);

            master = new Master(vector, vector2, 1);
            before = DateTime.Now;
            result = master.ComputeDistanceF();
            after = DateTime.Now;
            Console.WriteLine("Result with PLINQ+TLP: {0:N2}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);

            master = new Master(vector, vector2, 1);
            before = DateTime.Now;
            result = master.ComputeDistanceF2();
            after = DateTime.Now;
            Console.WriteLine("Result with PLINQ+TLP Version 2: {0:N2}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);
        }

        public static short[] CreateRandomVector(int numberOfElements, short lowest, short greatest) {
            short[] vector = new short[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = (short)random.Next(lowest, greatest + 1);
            return vector;
        }

        public static int[] CreateRandomVectorInt(int numberOfElements, int lowest, int greatest)
        {
            int[] vector = new int[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = (int)random.Next(lowest, greatest + 1);
            return vector;
        }

    }

}
