
using Lab09;
using System.Threading;

namespace TPP.Laboratory.Concurrency.Lab09 {

    internal class Worker {

        private BitcoinValueData[] vector;
        private Index index;

        private long result;
        //add an attribut of type Index
        
        internal long Result {
            get { return this.result; }
        }

        //add a constructor that additionally receives an Index
        internal Worker(BitcoinValueData[] vector,  Index index)
        {
            this.vector = vector;
            //assign the received index to the attribute
            this.index = index;
        }

        internal void Compute(double threshold) {
            this.result = 0;
            //define additional variable/s if needed

            //forever loop
            int i;
            while (true)
            {
                //lock the index
                lock (index)
                {
                    //copy the value of TheIndex attribute
                    i = index.TheIndex;
                    //increment the value of TheIndex attribute
                    index.TheIndex = i + 1;

                }//end lock
                //if the value of the index is greater than the length of the vector, break the loop
                //if the index is out of range, break the loop
                if (i >= vector.Length)
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
