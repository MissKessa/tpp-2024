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
    public class Master {
        private BitcoinValueData[] vector;

        private int numberOfThreads;

        Index index;

        public Master(BitcoinValueData[] vector, int numberOfThreads) {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("The number of threads must be lower or equal to the number of elements in the vector.");
            this.vector = vector;
            this.numberOfThreads = numberOfThreads;
            index = new Index();
        }
        public long ComputeTimesAbove(double threshold) {
            Worker[] workers = new Worker[this.numberOfThreads];
            int itemsPerThread = this.vector.Length/numberOfThreads;
            for (int i = 0; i < this.numberOfThreads; i++)
            {
                //initialize the array of workers
                //call the constructor of the class Worker with the vector and the index as parameters
                workers[i] = new Worker(vector, index);
            }  
            Thread[] threads = new Thread[workers.Length];
            for(int i=0;i<workers.Length;i++) {
                //call the constructor of the class Thread with the method Compute as parameter
                //the parameter of the method Compute is the value of the threshold parameter
                //use a lambda expression
                //be careful with the captured variables

                //threads[i] = New Thread(()=> workers[i].Compute(threshold)); //index out of range,as the i is passed of the for. At the end of the for it's value is vector.Length
                double tCopy = threshold;
                int iCopy = i;
                threads[i] = new Thread(() => workers[iCopy].Compute(tCopy)); //So, we make copies of them so each thread has its own value
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

            long result = 0;
            //think about the need to accumulate partial results
            //do that if needed

            foreach (Worker worker in workers)
            { //Traverse the array of workers
                result += worker.Result; //Sum the results of each worker in the result of the master
            }

            return result;
        }

    }

}
