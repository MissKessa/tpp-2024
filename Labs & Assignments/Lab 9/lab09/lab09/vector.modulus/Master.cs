using System;
using System.Threading;

namespace TPP.Laboratory.Concurrency.Lab09 {

    public class Master {

        private short[] vector;

        private int numberOfThreads;

        public Master(short[] vector, int numberOfThreads) {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("The number of threads must be lower or equal to the number of elements in the vector.");
            this.vector = vector;
            this.numberOfThreads = numberOfThreads;
        }

        public double ComputeModulus() {
            Worker[] workers = new Worker[this.numberOfThreads]; //Create an array of workers
            int itemsPerThread = this.vector.Length/numberOfThreads; //Compute the amount of the datea each worker is going to process
            for(int i=0; i < this.numberOfThreads; i++) //Initialize each worker
                workers[i] = new Worker(this.vector, //The data
                    i*itemsPerThread, //Beginning of the section of data
                    (i<this.numberOfThreads-1) ? (i+1)*itemsPerThread-1: this.vector.Length-1 // last one. The end of the section of the data
                    );

            Thread[] threads = new Thread[workers.Length]; //Create an array of threads (in this case we use an array because we are going to check how the program works with 1 thread....1000 threads)
            for(int i=0;i<workers.Length;i++) { //Initialize each thread
                threads[i] = new Thread(workers[i].Compute); //Each thread will execute the compute of the corresponding worker
                threads[i].Name = "Worker Vector Modulus " + (i+1); //Gives name to the thread
                threads[i].Priority = ThreadPriority.BelowNormal; //Gives a priority to the thread
                threads[i].Start();  //Starts the thread
            }
            foreach (var t in threads) //Traverse the arrays of threads, and waits until each thread has finish. If not, it doens't continue, it waits
            {
                t.Join();
            }
            long result = 0; //Initialize the result of the master
            foreach (Worker worker in workers) { //Traverse the array of workers
                result += worker.Result; //Sum the results of each worker in the result of the master
            }
            return Math.Sqrt(result); //Then it computes the square root of the result of the master
        }

    }

}
