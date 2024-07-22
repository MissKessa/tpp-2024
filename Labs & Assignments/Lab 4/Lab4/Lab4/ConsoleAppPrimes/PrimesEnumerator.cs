using System;
using System.Collections;
using System.Collections.Generic;

namespace TPP.ObjectOrientation.Generics {


    /// <summary>
    /// Class that implements a Fibonacci enumerator (iterator).
    /// </summary>
    internal class PrimesEnumerator : IEnumerator<int> {
        /// <summary>
        /// Index is the position of the term in the sequence.
        /// FirstTerm and secondTerm store the two last terms.
        /// SecondTerm is the current term.
        /// </summary>
        int index, secondTerm;

        /// <summary>
        /// Maximum number of elements in this enumerator (iterator).
        /// </summary>
        int elements;

        public PrimesEnumerator(int elements) {
            this.elements = elements;
            Reset();
        }

        /// <summary>
        /// The current term (generic version)
        /// </summary>
        int IEnumerator<int>.Current {
            get { return secondTerm; }
        }

        /// <summary>
        /// The current term (polymorphic method)
        /// </summary>
        object IEnumerator.Current {
            get { return secondTerm; }
        }

        /// <summary>
        /// Increments the enumerator (iterator) going to the following term
        /// </summary>
        /// <returns>True if the increment was successful; false if the end was reached</returns>
        public bool MoveNext() {
            if (index >= this.elements)
                return false;
            //if (++index > 2) {
            //    int temp = secondTerm;
            //    secondTerm;
      
            //}
            while(true)
            {
                secondTerm++;
                if (IsPrime(secondTerm))
                {
                    index++;
                    break;
                }
            }
            return true;
        }

        /// <summary>
        /// Resets the enumerator (iterator), setting it to the begining of the sequence
        /// </summary>
        public void Reset() {
            index = 0;
            secondTerm = 1;
        }

        /// <summary>
        /// This method is called when the object is destroyed.
        /// It is used to free its resources (nothing in this case).
        /// It must be implemented, though, because it is part of the IEnumerator.
        /// </summary>
        public void Dispose() {
        }
        private Boolean IsPrime(int n)
        {
            for (int i = 2; i < n/2+1; i++) { if (n % i == 0) return false; }
            return true;
        }

    } 

} // namespace
