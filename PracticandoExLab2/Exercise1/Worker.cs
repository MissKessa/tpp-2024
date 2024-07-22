
namespace TPP.Laboratory.Concurrency.Lab09 {

    internal class Worker {

        private short[] vector; //Data
        private short[] vector2; //Data

        private int fromIndex, toIndex; //Beginning and end of the section of data

        private long result; //result of this worker

        internal long Result {
            get { return this.result; }
        }

        internal Worker(short[] vector, short[] vector2, int fromIndex, int toIndex) {
            this.vector = vector;
            this.vector2 = vector2;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
        }

        internal void Compute() {
            this.result = 0; //Initialize each result
            for (int i = this.fromIndex; i <= this.toIndex; i++)
            {//Acummulate in the result, the sum of the square of each component of the data
                int difference = this.vector[i] - this.vector2[i];
                this.result += difference*difference;
            }
        }

    }

}
