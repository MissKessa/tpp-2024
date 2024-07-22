using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    internal class Exercise2
    {
        public static void Execute()
        {
            short[] v = Utils.CreateRandomShortVector(10, 2, 10000).OrderBy(x => x).ToArray();
            double x;
            //x = VarLinq(v); //0.261s
            //x = VarPLinq(v); //0.251s
            //x = VarInvoke(v); //0.282s
            x = VarInvokeParallel(v); //0.266s
            Console.WriteLine(x);
        }
        static double VarLinq(IEnumerable<short> vector) //E((X−E(X))**2)
        {
            var sumElements = vector.Aggregate(0.0, (acc, el) => acc + el);
            var mean = sumElements / vector.Count(); //E(X)

            var sumXEX2 = vector.Aggregate(0.0, (acc, el) => acc + Math.Pow((el - mean), 2.0)); //Math.Pow(X−E(X), 2.0))
            return sumXEX2 / vector.Count(); 
        }

        static double VarPLinq(IEnumerable<short> vector)
        {
            var sumElements = vector.AsParallel().Aggregate(0.0, (acc, el) => acc + el);
            var mean = sumElements / vector.Count(); //E(X)

            var sumXEX2 = vector.AsParallel().Aggregate(0.0, (acc, el) => acc + Math.Pow((el - mean), 2.0)); //Math.Pow(X−E(X), 2.0))
            return sumXEX2 / vector.Count();
        }

        static double Mean(IEnumerable<short> vector)
        {
            return vector.Aggregate(0.0, (acc, el) => acc + el) / (double)
            vector.Count();
        }
        static double MeanX2(IEnumerable<short> vector)
        {
            return vector.Aggregate(0.0, (acc, el) => acc + el * el) /
            (double)vector.Count();
        }

        static double VarInvoke(IEnumerable<short> vector) //E(X**2)−(E(X))**2
        {
            double result1 = 0;
            double result2 = 0;
            Parallel.Invoke(
                ()=> result1 = MeanX2(vector), //E(X**2)
                () => result2 = Math.Pow(Mean(vector),2.0) //(E(X))**2
                );;
            return result1- result2;
        }

        static double MeanParallel(IEnumerable<short> vector)
        {
            return vector.AsParallel().Aggregate(0.0, (acc, el) => acc + el) / (double)
            vector.Count();
        }
        static double MeanX2Parallel(IEnumerable<short> vector)
        {
            return vector.AsParallel().Aggregate(0.0, (acc, el) => acc + el * el) /
            (double)vector.Count();
        }

        static double VarInvokeParallel(IEnumerable<short> vector) //E(X**2)−(E(X))**2
        {
            double result1 = 0;
            double result2 = 0;
            Parallel.Invoke(
                () => result1 = MeanX2Parallel(vector), //E(X**2)
                () => result2 = Math.Pow(MeanParallel(vector), 2.0) //(E(X))**2
                ); ;
            return result1 - result2;
        }
    }
}
