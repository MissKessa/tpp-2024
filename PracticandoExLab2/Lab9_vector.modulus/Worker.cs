
namespace TPP.Laboratory.Concurrency.Lab09 {

    internal class Worker {

        private short[] vector; //Data

        private int fromIndex, toIndex; //Beginning and end of the section of data

        private long result; //result of this worker

        internal long Result {
            get { return this.result; }
        }

        internal Worker(short[] vector, int fromIndex, int toIndex) {
            this.vector = vector;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
        }

        internal void Compute() {
            this.result = 0; //Initialize each result
            for(int i= this.fromIndex; i<=this.toIndex; i++) //Acummulate in the result, the sum of the square of each component of the data
                this.result += this.vector[i] * this.vector[i];
        }

    }

}
