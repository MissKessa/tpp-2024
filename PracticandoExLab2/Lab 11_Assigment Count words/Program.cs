using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace task.parallelism
{
    class Program
    {
        public static void sequential_task_processing()
        {
            String text = TextProcessing.ReadTextFile(@"..\..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);

            // Processing
            DateTime before = DateTime.Now;
            int punctuationMarks = TextProcessing.NumberOfPunctuationMarks(text);
            var longestWords = TextProcessing.LongestWords(words);
            var shortestWords = TextProcessing.ShortestWords(words);
            int greatestOccurrence, lowestOccurrence;
            var wordsAppearMoreTimes = TextProcessing.WordsAppearMoreTimes(words, out greatestOccurrence);
            var wordsAppearFewerTimes = TextProcessing.WordsAppearFewerTimes(words, out lowestOccurrence);
            DateTime after = DateTime.Now;

            TextProcessing.ShowResults(punctuationMarks, shortestWords, longestWords, wordsAppearFewerTimes, lowestOccurrence,
                wordsAppearMoreTimes, greatestOccurrence);

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);

            Console.WriteLine();
            Console.WriteLine();
        }


        public static void parallel_task_processing()
        {
            String text = TextProcessing.ReadTextFile(@"..\..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);

            // Processing
            DateTime before = DateTime.Now;
            string[] longestWords = null, shortestWords = null, wordsAppearMoreTimes = null, wordsAppearFewerTimes = null;
            int greatestOccurrence = 0, lowestOccurrence = 0, punctuationMarks = 0;
            Parallel.Invoke(
                () => punctuationMarks = TextProcessing.NumberOfPunctuationMarks(text),
                () => longestWords = TextProcessing.LongestWords(words),
                () => shortestWords = TextProcessing.ShortestWords(words),
                () => wordsAppearMoreTimes = TextProcessing.WordsAppearMoreTimes(words, out greatestOccurrence),
                () => wordsAppearFewerTimes = TextProcessing.WordsAppearFewerTimes(words, out lowestOccurrence)
                 );
            DateTime after = DateTime.Now;

            TextProcessing.ShowResults(punctuationMarks, shortestWords, longestWords, wordsAppearFewerTimes, lowestOccurrence,
                wordsAppearMoreTimes, greatestOccurrence);

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);

            Console.WriteLine();
            Console.WriteLine();
        }

        public static IDictionary<String, int> sequentialCounting()
        {
            String text = TextProcessing.ReadTextFile(@"..\..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);

            // Processing
            DateTime before = DateTime.Now;

            IDictionary<String, int> all = new Dictionary<String, int>();

            for (int i = 0; i < words.Length; i ++)
            {
                if (all.ContainsKey(words[i]))
                {
                    all[words[i]]++;
                }
                else
                {
                    all.Add(words[i], 1);
                }
            }

            DateTime after = DateTime.Now;

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);

            Console.WriteLine();
            Console.WriteLine();
            return all;
        }

        public static IDictionary<String, int> parallelCounting()
        {
            String text = TextProcessing.ReadTextFile(@"..\..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);

            // Processing
            DateTime before = DateTime.Now;

            IDictionary<String, int> all = new Dictionary<String, int>();
            IDictionary<String, int> even = new Dictionary<String, int>();
            IDictionary<String, int> odd = new Dictionary<String, int>();

            Parallel.Invoke(()=>
            {
                for (int i = 0; i < words.Length; i += 2) {
                    if (even.ContainsKey(words[i])) {
                        even[words[i]]++;
                    }
                    else {
                        even.Add(words[i], 1);
                    }
                }
            },
            ()=> {
                for (int i = 1; i < words.Length; i += 2) {
                    if (odd.ContainsKey(words[i])) {
                        odd[words[i]]++;
                    }
                    else {
                        odd.Add(words[i], 1);
                    }
                }
            }
            );

            foreach(var p in odd)
            {
                if (even.ContainsKey(p.Key))
                {
                    even[p.Key]+=p.Value;
                }
                else
                {
                    even.Add(p.Key, p.Value);
                }
            }
            all = even;

            DateTime after = DateTime.Now;

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);

            Console.WriteLine();
            Console.WriteLine();
            return all;
        }

        public static IDictionary<String, int> parallelCounting2() //like sequential or worst as we lock always
        {
            String text = TextProcessing.ReadTextFile(@"..\..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);

            // Processing
            DateTime before = DateTime.Now;

            IDictionary<String, int> all = new Dictionary<String, int>();
            Parallel.For(0, words.Length, (i) =>
            {
                lock (all)
                {
                    if (all.ContainsKey(words[i]))
                    {
                        all[words[i]]++;
                    }
                    else
                    {
                        all.Add(words[i], 1);
                    }
                }
            });

            DateTime after = DateTime.Now;

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);

            Console.WriteLine();
            Console.WriteLine();
            return all;
        }

        public static IDictionary<String, int> parallelCounting3() //like sequential or worst as we lock always
        {
            String text = TextProcessing.ReadTextFile(@"..\..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);

            // Processing
            DateTime before = DateTime.Now;

            IDictionary<String, int> all = new Dictionary<String, int>();

            Parallel.ForEach(words, (word) =>
            {
                lock (all)
                {
                    if (all.ContainsKey(word))
                    {
                        all[word]++;
                    }
                    else
                    {
                        all.Add(word, 1);
                    }
                }
            });

            DateTime after = DateTime.Now;

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);

            Console.WriteLine();
            Console.WriteLine();
            return all;
        }

        public static IDictionary<String, int> parallelCounting4() //overloadedParallelFor
        {
            String text = TextProcessing.ReadTextFile(@"..\..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);

            // Processing
            DateTime before = DateTime.Now;

            IDictionary<String, int> all = new Dictionary<String, int>();

            Parallel.For(0, words.Length, () => new Dictionary<String, int>(),
                (i, loop, subresult) =>
                {
                    if (subresult.ContainsKey(words[i]))
                    {
                        subresult[words[i]]++;
                    }
                    else
                    {
                        subresult.Add(words[i], 1);
                    }
                    return subresult;
                },
                subFinalresult => {
                    lock (all)
                    {
                        foreach (var p in subFinalresult)
                        {
                            if (all.ContainsKey(p.Key))
                            {
                                all[p.Key] += p.Value;
                            }
                            else
                            {
                                all.Add(p.Key, p.Value);
                            }
                        }
                    }
                });

            DateTime after = DateTime.Now;

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);

            Console.WriteLine();
            Console.WriteLine();
            return all;
        }

        public static IDictionary<String, int> parallelCounting5() //overloadedParallelForEach
        {
            String text = TextProcessing.ReadTextFile(@"..\..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);

            // Processing
            DateTime before = DateTime.Now;

            IDictionary<String, int> all = new Dictionary<String, int>();

            Parallel.ForEach(words, () => new Dictionary<String, int>(),
                (w, loop, subresult) =>
                {
                    if (subresult.ContainsKey(w))
                    {
                        subresult[w]++;
                    }
                    else
                    {
                        subresult.Add(w, 1);
                    }
                    return subresult;
                },
                subFinalresult => {
                    lock (all)
                    {
                        foreach (var p in subFinalresult)
                        {
                            if (all.ContainsKey(p.Key))
                            {
                                all[p.Key] += p.Value;
                            }
                            else
                            {
                                all.Add(p.Key, p.Value);
                            }
                        }
                    }
                });

            DateTime after = DateTime.Now;

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);

            Console.WriteLine();
            Console.WriteLine();
            return all;
        }

        public static IDictionary<String, int> parallelCounting6() 
        {
            String text = TextProcessing.ReadTextFile(@"..\..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);

            // Processing
            DateTime before = DateTime.Now;

            List<IDictionary<String, int>> subresults= new List<IDictionary<String, int>>();
            IDictionary<String, int> all = new Dictionary<String, int>();
            Parallel.For(0, 4, (i) =>
            {
                int k = i;
                int parts = words.Length / 4;
                int begin = 0 + parts * k;
                int end = k == 4 ? words.Length : parts * (k + 1);

                IDictionary<String, int> subres = new Dictionary<String, int>();
                for (int j=begin; j < end; j++)
                {
                    if (subres.ContainsKey(words[j]))
                    {
                        subres[words[j]]++;
                    }
                    else
                    {
                        subres.Add(words[j], 1);
                    }
                }
                subresults.Add(subres);
            });

            all = subresults[0];
            for (int i = 1; i < subresults.Count; i++)
            {
                foreach (var p in subresults[i])
                {
                    if (all.ContainsKey(p.Key))
                    {
                        all[p.Key] += p.Value;
                    }
                    else
                    {
                        all.Add(p.Key, p.Value);
                    }
                }
            }
            

            DateTime after = DateTime.Now;

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);

            Console.WriteLine();
            Console.WriteLine();
            return all;
        }
        public static IDictionary<String, int> LINQCounting()
        {
            String text = TextProcessing.ReadTextFile(@"..\..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);

            // Processing
            DateTime before = DateTime.Now;

            IDictionary<String, int> all = words.GroupBy(x=>x).ToDictionary(x => x.Key, x => x.Count());

            DateTime after = DateTime.Now;

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);

            Console.WriteLine();
            Console.WriteLine();
            return all;
        }

        public static IDictionary<String, int> ParallelLINQCounting()
        {
            String text = TextProcessing.ReadTextFile(@"..\..\..\..\clarin.txt");
            string[] words = TextProcessing.DivideIntoWords(text);

            // Processing
            DateTime before = DateTime.Now;

            IDictionary<String, int> all = words.AsParallel().GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            DateTime after = DateTime.Now;

            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", (after - before).Ticks / TimeSpan.TicksPerMillisecond);

            Console.WriteLine();
            Console.WriteLine();
            return all;
        }

        static void Main(string[] args)
        {
            //sequential_task_processing();
            //parallel_task_processing();

            /*
                Elapsed time: 34,00 milliseconds
                Elapsed time: 34,00 milliseconds.
                Elapsed time: 64,00 milliseconds
                Elapsed time: 58,00 milliseconds
                Elapsed time: 14,00 milliseconds
                Elapsed time: 13,00 milliseconds
                Elapsed time: 44,00 milliseconds
                Elapsed time: 63,00 milliseconds.
             */
            IDictionary<String, int> s =sequentialCounting();
            IDictionary<String, int> p = parallelCounting();
            IDictionary<String, int> p2 = parallelCounting2();
            IDictionary<String, int> p3 = parallelCounting3();
            IDictionary<String, int> p4 = parallelCounting4();
            IDictionary<String, int> p5 = parallelCounting4();
            IDictionary<String, int> lq = LINQCounting();
            IDictionary<String, int> lq2 = ParallelLINQCounting();
            IDictionary<String, int> p6 = parallelCounting6();

            Console.WriteLine(EqualDictionaries(s, p));
            Console.WriteLine(EqualDictionaries(s, p2));
            Console.WriteLine(EqualDictionaries(s, p3));
            Console.WriteLine(EqualDictionaries(s, p4));
            Console.WriteLine(EqualDictionaries(s, p5));
            Console.WriteLine(EqualDictionaries(s, lq));
            Console.WriteLine(EqualDictionaries(s, lq2));
            Console.WriteLine(EqualDictionaries(s, p6));

            Console.ReadLine();
        }

        static Boolean EqualDictionaries(IDictionary<String, int> a, IDictionary<String, int> b)
        {
            if (a.Count != b.Count) { return false; }

            foreach(var p in a)
            {
                if (!b.ContainsKey(p.Key)) { return false; }
                if (b[p.Key] != p.Value) { return false; }
            }
            return true;
        }
    }

}
