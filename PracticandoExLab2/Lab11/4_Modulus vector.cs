using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab11
{
    /*
     * Compute the modulus of a int array using Parallel.For or
Parallel.ForEach. Beware of the arithmetical operations, are they atomic?. If not, use
the suitable class and method that provide basic atomic arithmetical operations. The
straightforward parallelization of the serial algorithm it is not the most efficient approach,
why?
     * */
    public class Exercise4
    {
        public static void Execute()
        {
            int[] v = Utils.CreateRandomIntVector(10, 2, 10000).OrderBy(x => x).ToArray();
            Console.WriteLine(ModulusParallelFor(v));
            Console.WriteLine(ModulusParallelForEach(v));
            Console.WriteLine(ModulusInvoke(v));
            Console.WriteLine(ModulusPLINQ(v));
            Console.WriteLine(ModulusParallelForOverride(v));
            Console.WriteLine(ModulusParallelForEachOverride(v));
        }

        public static double ModulusParallelFor(int[] v)
        {
            int result = 0;

            Parallel.For(0, v.Length, (i) =>
            {
                int pow = v[i] * v[i];
                Interlocked.Add(ref result, pow);
            });
            return Math.Sqrt(result);
        }

        public static double ModulusParallelForEach(int[] v)
        {
            int result = 0;

            Parallel.ForEach(v, (element) =>
            {
                int pow = element * element;
                Interlocked.Add(ref result, pow);
            });
            return Math.Sqrt(result);
        }

        public static double ModulusInvoke(int[] v)
        {
            int result1 = 0;
            int result2 = 0;

            Parallel.Invoke(
                ()=> 
                Parallel.For(0, v.Length / 2, (i) =>
                {
                    int pow = v[i] * v[i];
                    Interlocked.Add(ref result1, pow);
                }),
                ()=>
                Parallel.For(v.Length / 2, v.Length, (i) =>
                {
                    int pow = v[i] * v[i];
                    Interlocked.Add(ref result2, pow);
                })
            );
            
            return Math.Sqrt(result1+result2);
        }

        public static double ModulusParallelForOverride(int[] v)
        {
            int result = 0;

            Parallel.For(0, v.Length, 
                ()=>0,
                (i,loop,subresult) =>
                {
                    int pow = v[i] * v[i];
                    subresult += pow;
                    return subresult;
                }, (finalSubresult)=> { 
                    result+= finalSubresult;
                });
            return Math.Sqrt(result);
        }

        public static double ModulusParallelForEachOverride(int[] v)
        {
            int result = 0;

            Parallel.ForEach(v, 
                ()=>0,
                (element,loop,subtotal) => {
                    int pow = element * element;
                    subtotal += pow;
                    return subtotal;
                },
                (finalSubresult) =>
                {
                    result += finalSubresult;
                });
            return Math.Sqrt(result);
        }

        public static double ModulusPLINQ(int[] v)
        {
            return Math.Sqrt(v.AsParallel().Select(x => x * x).Aggregate(0,(x,acc)=>acc+=x));
        }
    }
}
