using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab4
{


    /// <summary>
    /// Class that implements a Fibonacci enumerator (iterator).
    /// </summary>
    public class PrimesEnumerator : IEnumerator<int> {
        /// <summary>
        /// Index is the position of the term in the sequence.
        /// currentPrime is the prime before this one
        /// </summary>
        int index, currentPrime;

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
            get { return currentPrime; }
        }

        /// <summary>
        /// The current term (polymorphic method)
        /// </summary>
        object IEnumerator.Current {
            get { return currentPrime; }
        }

        /// <summary>
        /// Increments the enumerator (iterator) going to the following term
        /// </summary>
        /// <returns>True if the increment was successful; false if the end was reached</returns>
        public bool MoveNext() {
            if (index >= this.elements)
                return false;
            if (index == 0)
            {
                index++;
                return true;
            }
            
            int temp = currentPrime;
            for(int i = currentPrime + 1; i < currentPrime * 2; i++)
            {
                if (IsPrime(i))
                {
                    currentPrime = i;
                    index++;
                    return true;
                }
            }
            
            return true;
        }

        public Boolean IsPrime(int number)
        {
            for (int i=2; i<number/2+1;i++)
            {
                if(number%i==0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Resets the enumerator (iterator), setting it to the begining of the sequence
        /// </summary>
        public void Reset() {
            index = 0;
            currentPrime=2;
        }

        /// <summary>
        /// This method is called when the object is destroyed.
        /// It is used to free its resources (nothing in this case).
        /// It must be implemented, though, because it is part of the IEnumerator.
        /// </summary>
        public void Dispose() {
        }

    }

} // namespace
