using Lab09;
using System;
using System.Threading;

namespace TPP.Laboratory.Concurrency.Lab09 {

    public class Index
    {
        int index;
        public Index()
        {
            index = 0;
        }
        public int TheIndex
        {
            get { return index; }
            set { index = value; }
        }
    }
    public class CountInterLocked {
        private BitcoinValueData[] vector;

        private int numberOfThreads;
        //add an attribute of type Index
        private Index index;
        

        long result;

        public CountInterLocked(BitcoinValueData[] vector, int numberOfThreads) {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("The number of threads must be lower or equal to the number of elements in the vector.");
            this.vector = vector;
            this.numberOfThreads = numberOfThreads;
            result = 0;
            //initialize the attribute of type Index
            index=new Index();
        }
        public long ComputeTimesAbove(double threshold) {

            Thread[] threads = new Thread[numberOfThreads];
            for(int i=0;i<threads.Length;i++) {
                //call the constructor of the class Thread with the method Compute as parameter
                //the parameter of the method Compute is the value of the threshold parameter
                //use a lambda expression
                //it's safe to work with lmbda expressions because there is a threashold parameter for all the threads, and it's constant
                threads[i] = new Thread(
                    () => { Compute(threshold); }
                 );

                threads[i].Name = "Worker Vector Modulus " + (i+1); 
                threads[i].Priority = ThreadPriority.BelowNormal; 
                threads[i].Start();  
            }
            //think about the need to wait for the threads to finish
            //do that if needed
            foreach (var t in threads) 
            {
                t.Join();
            }

            //think about the need to accumulate partial results
            //do that if needed

            return result;
        }

        internal void Compute(double threshold)
        {
            //mind the indentation
            //define variable/s if needed
            int i;
            //loop
            while (true)
            {
                //lock the index
                lock (index) {
                    //copy the value of TheIndex attribute
                    i = index.TheIndex;
                    //increment the value of TheIndex attribute
                    index.TheIndex = i + 1;
                    //end lock
                }
                //if the index is out of range, break the loop
                if (i>=vector.Length)
                {
                    break;
                }
                //if the value of the vector in the position workerIndex is greater than threshold, increment result
                if (vector[i].Value > threshold)
                {
                    Interlocked.Increment(ref result); //Interlocked because is a shared resource that is not safe from threads
                }

            }
            //end loop
        }

    }

}
