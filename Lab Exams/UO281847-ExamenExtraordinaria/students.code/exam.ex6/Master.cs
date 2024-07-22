using System;
using System.Collections.Generic;
using System.Threading;

namespace exam.ex6
{
    internal class Master<T>
    {
        private T[] array;
        private int numberOfThreads;

        public Master(T[] array, int v)
        {
            this.array = array;
            this.numberOfThreads = v;
        }

        public Dictionary<T, IEnumerable<int>> ComputeDictionary()
        {
            Worker<T>[] workers = new Worker<T>[numberOfThreads];
            int elementsPerThread = array.Length / numberOfThreads;
            for (int i=0; i<workers.Length; i++)
            {
                workers[i] = new Worker<T>(array,
                                        i * elementsPerThread,
                                        (i < numberOfThreads - 1) ? (i+1)*elementsPerThread-1 : this.array.Length - 1);
            }

            Thread[] threads = new Thread[workers.Length];
            for (int i=0; i< threads.Length; i++)
            {
                threads[i] = new Thread(workers[i].ComputeDict);
                threads[i].Name = $"Worker Thread {i}";
                threads[i].Priority = ThreadPriority.Normal;
                threads[i].Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            var dictionary = new Dictionary<T, IEnumerable<int>>();
            foreach(Worker<T> worker in workers)
            {
                foreach (var key in worker.Dict.Keys) {
                    if (dictionary.ContainsKey(key))
                    {
                        dictionary[key] = worker.Dict[key];
                    }
                    else
                    {
                        dictionary.Add(key, worker.Dict[key]);
                    }                    
                }
            }
            return dictionary;
        }
    }
}