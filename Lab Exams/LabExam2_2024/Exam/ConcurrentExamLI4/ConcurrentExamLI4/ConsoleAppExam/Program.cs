using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using task.parallelism;
using TPP.Concurrency.Threads;

namespace ConsoleAppExam
{




    //Modify this class in order to make it thread safe
    //Thread.Sleep calls removal is forbidden
    //Only the addition of suitable synchronization mechanisms is allowed
    public class BallotBox
    {
        int[] ballots;
        bool[] inTheBox;
        ReaderWriterLockSlim CacheLock = new ReaderWriterLockSlim(); //mine

        public BallotBox(int[] values)
        {
            ballots = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
                ballots[i] = values[i];
            inTheBox = new bool[values.Length];
            for (int i = 0; i < values.Length; i++)
                inTheBox[i] = true;
        }
        public int Extract()
        {
            CacheLock.EnterUpgradeableReadLock();
            try
            {
                int index;
                Random random = new Random();
                //if all the ballots are not the box, return -1
                if (inTheBox.All(b => b == false))
                    return -1;
                Thread.Sleep(10);
                do
                {
                    index = random.Next(0, ballots.Length);
                } while (!inTheBox[index]);
                Thread.Sleep(10);

                CacheLock.EnterWriteLock();
                try
                {
                    inTheBox[index] = false;
                    return ballots[index];
                }
                finally
                {
                    CacheLock.ExitWriteLock();
                }
            }
            finally
            {
                CacheLock.ExitUpgradeableReadLock();
            }
        }
    } //END BALLOT

    internal class Program
    {
        public static int[] RandomArray(int length, int min, int max)
        {
            Random r = new Random();
            int[] result = new int[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = r.Next(min, max);
            }
            return result;
        }

        public static int[] RandomIntSet(int cardinal, int min, int max)
        {
            IList<int> result = new List<int>();
            Random r = new Random();
            for (int i = 0; i < cardinal; i++)
            {
                int candidate;
                do
                {
                    candidate = r.Next(min, max);
                } while (result.Contains(candidate));
                result.Add(candidate);
            }
            return result.ToArray();
        }
        //Needed for the original modulus code to compile
        public static short[] CreateRandomVector(int numberOfElements, short lowest, short greatest)
        {
            short[] vector = new short[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = (short)random.Next(lowest, greatest + 1);
            return vector;
        }

        public static void Show<T>(IEnumerable<T> c)
        {
            foreach (var e in c)
                Console.Write($"{e} ");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //Intersection testing
            var setA = RandomIntSet(20, 0, 30);
            var setB = RandomIntSet(15, 10, 40);
            Console.WriteLine("Intersection data");
            //shown in order just to easy manual intersection computation
            //ideally you shoud check it against the serial version
            Show(setA.OrderBy(x => x));
            Show(setB.OrderBy(x => x));
            Console.WriteLine("Intersection results");
            IEnumerable<int> intersection = Exercise1(setA, setB).OrderBy(x => x);
            //foreach(int element in intersection)
            //{
            //    Console.Write(element + " ");
            //}
            //Console.WriteLine();
            Show(intersection);
            Console.WriteLine();

            //BallotBox class testing
            //Any modification nullifies this exercise score
            Console.WriteLine("Ballotbox results");
            for (int i = 0; i < 10; i++) //NOT CHANGE!!
            { 
                var bbts = new BallotBox(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
                Parallel.For(0, 15, (i) =>
                {
                    Console.Write($"{bbts.Extract()} ");
                });
                Console.WriteLine();
            }

            Console.WriteLine();
            //Number of words with each number different characters
            String text = TextProcessing.ReadTextFile(@"..\..\..\..\clarin.txt");            
            string[] words = TextProcessing.DivideIntoWords(text);
            Console.WriteLine("Number of words with each number different characters results");
            Dictionary<int,int> letters= Exercise3(words);
            //foreach(var p in letters)
            //{
            //    Console.WriteLine($"Words with {p.Key} characters: {p.Value}");
            //}
            var keys=letters.Keys.OrderBy(x => x);
            foreach(var k in keys)
            {
                Console.WriteLine($"Words with {k} characters: {letters[k]}");
            }

            //Set Difference M/W testing
            //Use the same sets defined earlier in Main
            //Original modulus project code follows
            //modify it to show your results
            //show the results with 1 and 4 threads
            //needed for the original code to compile, remove if no longer needed
            Console.WriteLine();
            Console.WriteLine("MW results");
            // * Computation with one single thread
            Master master = new Master(setA, setB, 1);
            DateTime before = DateTime.Now;
            IEnumerable<int> result = master.ComputeDifference().OrderBy(x => x);
            DateTime after = DateTime.Now;
            Console.Write("The result obtained with one single thread is: ");
            //foreach (int element in result)
            //{
            //    Console.Write(element + " ");
            //}
            //Console.WriteLine();
            Show(result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);

            // * Computation with four threads
            master = new Master(setA, setB, 4);
            before = DateTime.Now;
            result= master.ComputeDifference().OrderBy(x => x);
            after = DateTime.Now;
            Console.Write("The result obtained with 4 threads is:         ");
            //foreach (int element in result)
            //{
            //    Console.Write(element + " ");
            //}
            //Console.WriteLine();
            Show(result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);

            ////Original modulus project code follows
            ////modify it to show your results
            ////show the results with 1 and 4 threads
            ////needed for the original code to compile, remove if no longer needed
            //short[] vector = CreateRandomVector(100000, -100, 100);
            //Console.WriteLine("MW results");
            //// * Computation with one single thread
            //Master master = new Master(vector, 1);
            //DateTime before = DateTime.Now;
            //double result = master.ComputeModulus();
            //DateTime after = DateTime.Now;
            //Console.WriteLine("The result obtained with one single thread is: {0:N2}.", result);
            //Console.WriteLine("Elapsed time: {0:N0} ticks.",
            //    (after - before).Ticks);

            //// * Computation with four threads
            //master = new Master(vector, 4);
            //before = DateTime.Now;
            //result = master.ComputeModulus();
            //after = DateTime.Now;
            //Console.WriteLine("The result obtained with four threads is: {0:N2}.", result);
            //Console.WriteLine("Elapsed time: {0:N0} ticks.",
            //    (after - before).Ticks);


        }

        private static List<int> Exercise1(int[]a, int[]b)
        {
            List<int> result = new List<int>();
            Parallel.For(0, a.Length,
                ()=>new List<int>(),
                (i, loop, subresult) => { 
                    if (b.Contains(a[i]))
                    {
                        subresult.Add(a[i]);
                    }
                    return subresult; 
                },
                (finalSubresult) => {
                    lock (result)
                    {
                        foreach (int element in finalSubresult)
                        {
                            result.Add(element);
                        }
                    }
                }
            );
            return result;
        }

        private static Dictionary<int,int> Exercise3(String[] words) //key=number of different characters, value=number of word with that different characters
        {
            Dictionary<int, int> d = new Dictionary<int, int>();

            Parallel.ForEach(words, 
                () => new Dictionary<int, int>(),
                (word, loop, subresult) =>
                {
                    int countDifferentLetters = 0;
                    List<char> letters = new List<char>();
                    foreach(char l in word)
                    {
                        if (!letters.Contains(l))
                        {
                            letters.Add(l);
                            countDifferentLetters++;
                        }
                    }
                    
                    if (subresult.ContainsKey(countDifferentLetters))
                    {
                        subresult[countDifferentLetters]++;
                    }
                    else
                    {
                        subresult.Add(countDifferentLetters, 1);
                    }
                    return subresult;
                },
                subFinalresult => {
                    lock (d)
                    {
                        foreach (var p in subFinalresult)
                        {
                            if (d.ContainsKey(p.Key))
                            {
                                d[p.Key] += p.Value;
                            }
                            else
                            {
                                d.Add(p.Key, p.Value);
                            }
                        }
                    }
                });
            return d;
        }
    }
}
