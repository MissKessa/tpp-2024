
namespace Lab09
{

    internal class Worker {

        private BitcoinValueData[] data; //Data

        private int fromIndex, toIndex; //Beginning and end of the section of data

        private int result; //result of this worker

        private double minEuros;

        internal int Result {
            get { return this.result; }
        }

        internal Worker(BitcoinValueData[] vector, int fromIndex, int toIndex, double minEuros) {
            this.data = vector;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
            this.minEuros = minEuros;
        }

        internal void Compute() {
            this.result = 0; //Initialize each result
            for(int i= this.fromIndex; i<=this.toIndex; i++) //Acummulate in the result, the sum of the square of each component of the data
                if (data[i].Value>minEuros)
                    this.result += 1;
        }

    }

}
