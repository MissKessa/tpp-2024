using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Stack //It's a LIFO
    {
        private List l = new List();
        private uint maxNumberOfElements;

        public Stack(uint maxNumberOfElements)
        {
            if (maxNumberOfElements < 0) throw new ArgumentException();
            this.maxNumberOfElements = maxNumberOfElements;
        }


        public void Push(Object value)
        {
            Invariant();
            StatePreCondition();
            if (value == null) throw new ArgumentException();
            int elements = l.NumberOfElements;
            if (!IsFull)
            {
                l.AddValue(value);
            }

            if(elements+1!=l.NumberOfElements) {}
            Invariant();
        }

        public void Pop()
        {
            Invariant();
            StatePreCondition();
            l.RemoveByPosition(l.NumberOfElements-1);
            Invariant();
        }

        public bool IsEmpty
        {
            get { return l.NumberOfElements == 0; }
        }

        public bool IsFull
        {
            get { return l.NumberOfElements == maxNumberOfElements; }
        }

        public Boolean Invariant()
        {
            if(maxNumberOfElements<0) return false;
            if (l == null) return false;
            if (l.NumberOfElements > maxNumberOfElements) return false;
            return true;
        }

        public void StatePreCondition()
        {
            if (!Invariant())
                throw new InvalidOperationException();
        }


    }
}
