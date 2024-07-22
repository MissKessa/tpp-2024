using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab11
{
    //Count times each value appears
    internal class Exercise1
    {
        public static void Execute()
        {
            short[] v = Utils.CreateRandomShortVector(10, 2, 10000).OrderBy(x => x).ToArray();
            Dictionary<short, int> f = CountParallelFor(v);
            Dictionary<short, int> fe = CountParallelForEach(v);
            Dictionary<short, int> i = CountParallelInvoke(v);
            Dictionary<short, int> fo = CountParallelForOverloaded(v);
            Dictionary<short, int> p2 = CountParallelArrayDictionaries(v,2);
            Dictionary<short, int> p10 = CountParallelArrayDictionaries(v, 10);
            Dictionary<short, int> d2 = CountParallelInvokeArrayDictionaries(v, 2);
            Dictionary<short, int> d10 = CountParallelInvokeArrayDictionaries(v, 10);
            Console.WriteLine(Utils.CompareDicts(f, fe));
            Console.WriteLine(Utils.CompareDicts(f, i));
            Console.WriteLine(Utils.CompareDicts(f, fo));
            Console.WriteLine(Utils.CompareDicts(f, p2));
            Console.WriteLine(Utils.CompareDicts(f, p10));
            Console.WriteLine(Utils.CompareDicts(f, d2));
            Console.WriteLine(Utils.CompareDicts(f, d10));
        }

        public static Dictionary<short,int> CountParallelFor(short[] v)
        {
            Dictionary<short, int> d = new Dictionary<short, int>();
            Parallel.For(0, v.Length, (i) =>
            {
                lock (d)
                {
                    if (d.ContainsKey(v[i]))
                    {
                        d[v[i]]++;
                    } else
                    {
                        d.Add(v[i], 1);
                    }
                }
            });
            return d;
        }

        public static Dictionary<short, int> CountParallelForEach(short[] v)
        {
            Dictionary<short, int> d = new Dictionary<short, int>();
            IList<int> threadIds = new List<int>();
            Parallel.ForEach(v, (element) =>
            {
                lock (d)
                {
                    if (d.ContainsKey(element))
                    {
                        d[element]++;
                    }
                    else
                    {
                        d.Add(element, 1);
                    }
                    //redondo addition to see the different threads
                    if (!threadIds.Contains(Thread.CurrentThread.ManagedThreadId))
                    {
                        Console.WriteLine("Thread ID = " +
                        Thread.CurrentThread.ManagedThreadId);
                        threadIds.Add(Thread.CurrentThread.ManagedThreadId);
                    }
                }
            });
            return d;
        }

        public static Dictionary<short, int> CountParallelInvoke(short[] v)
        {
            Dictionary<short, int> odd = new Dictionary<short, int>();
            Dictionary<short, int> even = new Dictionary<short, int>();
            Parallel.Invoke(() => { 
                for(int i=0; i<v.Length; i += 2)
                {
                    if (even.ContainsKey(v[i]))
                    {
                        even[v[i]]++;
                    }
                    else
                    {
                        even.Add(v[i], 1);
                    }
                }
            }, () => {
                for (int i = 1; i < v.Length; i += 2)
                {
                    if (odd.ContainsKey(v[i]))
                    {
                        odd[v[i]]++;
                    }
                    else
                    {
                        odd.Add(v[i], 1);
                    }
                }
            });

            IDictionary<short, int> d = Utils.AddHistogram(odd,even);
            return (Dictionary<short, int>)d;
        }

        public static Dictionary<short, int> CountParallelForOverloaded(short[] v)
        {
            IDictionary<short, int> result = new Dictionary<short, int>();
            Parallel.For(0,v.Length,
                ()=>new Dictionary<short, int>(),
                (i,loop,subresult)=> {
                    if (subresult.ContainsKey(v[i])) {
                        subresult[v[i]]++;
                    }
                    else {
                        subresult.Add(v[i], 1);
                    }
                    return subresult;
                },
                (finalSubresult)=> { lock (result) { result = Utils.AddHistogram(result, finalSubresult); } }
            );
            return (Dictionary<short, int>)result;
        }

        public static Dictionary<short, int> CountParallelArrayDictionaries(short[]v, int n)
        {
            //Dictionary<short, int>[] ds = new Dictionary<short, int>[n];
            //for(int i=0; i < n; i++)
            //{
            //    ds[i]=new Dictionary<short, int>();
            //}
            IDictionary<short, int> result = new Dictionary<short, int>();

            Parallel.For(0,n,
                ()=> new Dictionary<short, int>(),
                (i,loop, subresult) => { 
                    for(int j = i; j < v.Length; j += n)
                    {
                        if (subresult.ContainsKey(v[j]))
                        {
                            subresult[v[j]]++;
                        }
                        else
                        {
                            subresult.Add(v[j], 1);
                        }
                    }
                    return subresult; },
                (finalSubresult) => { result = Utils.AddHistogram(result, finalSubresult); }
            );

            return (Dictionary<short, int>)result;
        }

        public static Dictionary<short, int> CountParallelInvokeArrayDictionaries(short[] v,int n)
        {
            Dictionary<short, int>[] ds = new Dictionary<short, int>[n];
            Action[] actionsInvoke = new Action[n];
            for (int i=0; i<n; i++)
            {
                int index = i;
                ds[i] = new Dictionary<short, int>();
                actionsInvoke[i] = ()=>
                {
                    for (int j = index; j < v.Length; j += n)
                    {
                        if (ds[index].ContainsKey(v[j]))
                        {
                            ds[index][v[j]]++;
                        }
                        else
                        {
                            ds[index].Add(v[j], 1);
                        }
                    }
                };
            }

            Parallel.Invoke(actionsInvoke);
            IDictionary<short, int> d = new Dictionary<short, int>();
            for (int i=0; i<n; i++)
            {
                d = Utils.AddHistogram(d, ds[i]);
            }
            
            return (Dictionary<short, int>)d;
        }
    }
}
