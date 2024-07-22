using System;
using System.Diagnostics;
using LinkedList;

namespace Stack
{
    
    /// <summary>
    /// It represents a polymorphic Stack capable of storing any object
    /// </summary>
    public class Stack
    {
        /// <summary>
        /// Maximum number of elements
        /// </summary>
        uint maxNumberOfElements;

        /// <summary>
        /// List containing all the elements in the stack
        /// </summary>
        List list = new List();

        private Boolean InVariant()
        {
#if DEBUG
            Contract.Invariant(list != null);
            Contract.Invariant(maxNumberOfElements>0);
            Contract.Invariant(maxNumberOfElements >= List.NumberOfElements);
#endif 
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A string representing the Stack</returns>
        override
        public String ToString()
        {
            return List.ToString(); 
        }

        /// <summary>
        /// Property for the maxNumberOfElements attribute
        /// </summary>
        public uint MaxNumberOfElements
        {
            get { return maxNumberOfElements; }
            set { 
                InVariant(); 
                Contract.RequiresArgument(value > 0, "The maxNumberOfElements must be greater than 0"); 
                maxNumberOfElements = value; 
                InVariant(); }
        }

        /// <summary>
        /// Property for the List attribute
        /// </summary>
        public List List
        {
            get { return list; }
            set { 
                InVariant(); 
                Contract.RequiresArgument(value!=null, "The maxNumberOfElements must be greater than 0");
                Contract.RequiresArgument(value.NumberOfElements<= maxNumberOfElements, "The number of elements must be less than or equal to the maximum");
                list = value; 
                InVariant(); }
        }

        /// <summary>
        /// Constructor for the stack
        /// </summary>
        /// <param name="maxNumberOfElements">Maximum number of elements for the stack. It must be greater than 0</param>
        public Stack(uint maxNumberOfElements)
        { 
            Contract.RequiresArgument(maxNumberOfElements > 0, "The maxNumberOfElements must be greater than 0");

            this.maxNumberOfElements = maxNumberOfElements;
        }

        /// <summary>
        /// Add the object to the last position
        /// </summary>
        /// <param name="o">Object to be added. It must be not null</param>
        public void Push(Object o)
        {
            InVariant();
            Contract.RequiresArgument(o != null, "The object pushed cannot be null");
            Contract.RequiresState(!IsFull, "The list must be not full");
            int numberElements = List.NumberOfElements;

            list.Add(o);

            Contract.Ensures(List.NumberOfElements == numberElements + 1);

            InVariant();
        }

        /// <summary>
        /// Removes the last element in the list
        /// </summary>
        /// <returns>The removed object</returns>
        public Object Pop() {
            InVariant();
            int numberElements = List.NumberOfElements;

            Contract.RequiresState(!IsEmpty, "The list must be not empty");
            
            Object removed = List.RemoveByPosition(numberElements - 1);

            Contract.Ensures(List.NumberOfElements == numberElements - 1);
            InVariant();
            return removed;
        }

        /// <summary>
        /// Returns if the stack is empty
        /// </summary>
        public Boolean IsEmpty
        {
            get { return List.NumberOfElements == 0; }
        }

        /// <summary>
        /// Returns if the stack is full
        /// </summary>
        public Boolean IsFull
        {
            get { return List.NumberOfElements == maxNumberOfElements; }
        }
    }
}
