using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    /*Choose from Parallel.For, Parallel.ForEach the correct one to
parallelize the vectorial addition of two int vectors.
     * 
     * */
    internal class Exercise5
    {
        public static void Execute()
        {
            int[] v1 = Utils.CreateRandomIntVector(10, 2, 10000).OrderBy(x => x).ToArray();
            int[] v2 = Utils.CreateRandomIntVector(10, 2, 10000).OrderBy(x => x).ToArray();
            int[]  f= AdditionParallelFor(v1, v2);
            //int[] fe=AdditionParallelForEach(v1, v2);

            Utils.Show(f, ' ', '\n');

            //Utils.Show(fe, ' ', '\n');
            //for (int i=0; i<fe.Length; i++)
            //{
            //    if (fe[i] != f[i])
            //    {
            //        Console.Out.WriteLine("NOT EQUAL");
            //        break;
            //    }
            //}
        }

        private static int[] AdditionParallelFor(int[]v1, int[]v2)
        {
            int[] result= new int[v1.Length];
            Parallel.For(0,v1.Length, (i) =>
            {
                lock(result)
                {
                    result[i] = v1[i] +v2[i];
                }
            });
            return result;
        }

        //private static int[] AdditionParallelForEach(int[] v1, int[] v2)
        //{
        //    //List<int> result = new List<int>();
        //    //Parallel.ForEach(v1.Zip(v2), (pair) =>
        //    //{
        //    //    lock (result)
        //    //    {
        //    //        result.Add(pair.First + pair.Second);
        //    //    }
        //    //});
        //    int[] result = new int[v1.Length];
        //    Parallel.ForEach<int, int>(result,
        //        () => 0,
        //        (i, loop, subtotal) =>
        //        {
        //            result[i] = v1[i] + v2[i];
        //            subtotal = result[i];
        //            return subtotal;
        //        },
        //        (finalResult) => finalResult++
        //    ) ;
        //    return result;
        //}
    }
}
