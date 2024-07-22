using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticandoExamen2
{
    public class Exercise4
    {
        public static void Histogram(int[]v1, int[] v2)
        {
            Action[] actions = new Action[2];
            Dictionary<int,int> d1= new Dictionary<int,int>();
            Dictionary<int,int> d2= new Dictionary<int,int>();
            actions[0] = () =>
            {
                for (int i = 0; i < v1.Length; i++)
                {
                    if (d1.ContainsKey(v1[i]))
                    {
                        d1[v1[i]]++;
                    }
                    else
                    {
                        d1.Add(v1[i], 1);
                    }
                }
            };
            actions[1] = () =>
            {
                for (int i = 0; i < v2.Length; i++)
                {
                    if (d2.ContainsKey(v2[i]))
                    {
                        d2[v2[i]]++;
                    }
                    else
                    {
                        d2.Add(v2[i], 1);
                    }
                }
            };

            Parallel.Invoke(actions);

            var k2= d2.Keys.ToList();
            Parallel.For(0, d2.Count, (i) =>
            {
                lock (d1)
                {
                    if (d1.ContainsKey(k2[i]))
                    {
                        d1[k2[i]] += d2[k2[i]];
                    }
                    else
                    {
                        d1.Add(k2[i], d2[k2[i]]);
                    }
                }
            });

            //result is d1
            foreach(var p in d1)
            {
                Console.WriteLine(p.Key+" "+p.Value);
            }
        }
    }
}
