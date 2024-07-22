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
        List list = new List();

        /// <summary>
        /// Checks the class invariants
        /// </summary>
        /// <returns>true if everything is OK</returns>
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
        /// <returns>A String representing the stack (list)</returns>
        override
        public String ToString()
        {
            return List.ToString(); 
        }

        /// <summary>
        /// Property of the maximum number of elements that the list can have
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
        /// Property of the list containing all the elements of the stack
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
        /// Constructor that sets the maximum number of elements of the stack
        /// </summary>
        /// <param name="maxNumberOfElements">It's the maximum number of elements. It must be greater than 0</param>
        public Stack(uint maxNumberOfElements)
        { 
            Contract.RequiresArgument(maxNumberOfElements > 0, "The maxNumberOfElements must be greater than 0");

            this.maxNumberOfElements = maxNumberOfElements;
        }

        /// <summary>
        /// It adds the given element at the end of the list
        /// </summary>
        /// <param name="o">It's the object to be added</param>
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
        /// It removes the last element in the list
        /// </summary>
        /// <returns>the object removed</returns>
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
        /// Property that returns if the stack is empty
        /// </summary>
        public Boolean IsEmpty
        {
            get { return List.NumberOfElements == 0; }
        }

        /// <summary>
        /// Property that returns if the stack is full
        /// </summary>
        public Boolean IsFull
        {
            get { return List.NumberOfElements == maxNumberOfElements; }
        }
    }
}
