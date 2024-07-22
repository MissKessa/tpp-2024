using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticandoExamen2
{
    public class Exercise3
    {
        public static void Variance(int[] vector)
        {
            Action[] actions= new Action[4];
            double X2even = 0;
            double X2odd = 0;
            double Xeven = 0;
            double Xodd = 0;

            actions[0] = () => {
                for(int i=0; i<vector.Length; i+=2)
                {
                    X2even+= vector[i]*vector[i];
                }
            };

            actions[1] = () => {
                for (int i = 1; i < vector.Length; i += 2)
                {
                    X2odd += vector[i] * vector[i];
                }
            };

            actions[2] = () => {
                for (int i = 0; i < vector.Length; i += 2)
                {
                    Xeven += vector[i];
                }
            };

            actions[3] = () => {
                for (int i = 1; i < vector.Length; i += 2)
                {
                    Xodd += vector[i];
                }
            };

            Parallel.Invoke(actions);

            double X2 = X2even + X2odd;
            X2 /= vector.Length;
            double X = Xeven + Xodd;
            X /= vector.Length;
            X*=X;

            double result = X2 - X;

            Console.WriteLine(result);
        }
    }
}
