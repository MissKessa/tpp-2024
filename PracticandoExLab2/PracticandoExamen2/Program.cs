using System;

namespace PracticandoExamen2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TPP.Laboratory.Concurrency.Lab09.VectorModulusProgram.Exercise1();
            //int[] vector = TPP.Laboratory.Concurrency.Lab09.VectorModulusProgram.CreateRandomVectorInt(100000, -10, 10);
            //Exercise3.Variance(vector);
            int[] vector = TPP.Laboratory.Concurrency.Lab09.VectorModulusProgram.CreateRandomVectorInt(100000, -10, 10);
            int[] vector2 = TPP.Laboratory.Concurrency.Lab09.VectorModulusProgram.CreateRandomVectorInt(100000, -10, 10);
            Exercise4.Histogram(vector, vector2);
        }
    }
}
