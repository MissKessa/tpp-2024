
using System.Collections.Generic;
using System.Linq;

namespace TPP.Concurrency.Threads {

    /// <summary>
    /// Computes the addition of the square values of part of a vector
    /// </summary>
    internal class Worker {

        /// <summary>
        /// The vector whose modulus is going to be computed.
        /// </summary>
        private int[] A;
        private int[] B;
        private List<int> difference;

        /// <summary>
        /// Indices of the vector indicating the elements to be used in the computation.
        /// Both fromIndex and toIndex are included in the process.
        /// </summary>
        private int fromIndex, toIndex;

        /// <summary>
        /// The result of the computation
        /// </summary>
        private long result;

        internal long Result {
            get { return this.result; }
        }

        internal Worker(int[] A, int[]B, List<int> difference, int fromIndex, int toIndex) {
            this.A = A;
            this.B = B;
            this.difference= difference;   
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
        }

        /// <summary>
        /// Method that computes the addition of the squares
        /// </summary>
        internal void Compute() {
            for (int i = this.fromIndex; i <= this.toIndex; i++)
            {
                if (!B.Contains(A[i]))
                {
                    lock(difference)
                    {
                        difference.Add(A[i]);
                    }
                }
            }
        }

    }

}
