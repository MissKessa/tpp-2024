using System;
using System.Collections.Generic;
using System.Numerics;
using LinkedList;
namespace Set
{
    /// <summary>
    /// It's a LinkedList that doesn't allow repeated elements
    /// </summary>
    public class Set : List
    {
        /// <summary>
        /// Default constructor of the Set.
        /// </summary>
        public Set() :base() { }

        /// <summary>
        /// Constructor of the Set. It sets the value of the root as the given one
        /// </summary>
        /// <param name="value">It's the value for the root</param>
        public Set(Object value) : base(value) { }

        /// <summary>
        /// Adds a new node, with the value passed as parameter, to the given index
        /// </summary>
        /// <param name="value">It's the value for the new node to be added</param>
        /// <param name="index">It's the index for the new node</param>
        /// <returns>true if the node has been added (it's not already in the set)</returns>
        public override Boolean Add(Object value, int index)
        {
            if(!base.Contains(value)) return base.Add(value, index);
            return false;
        }

        /// <summary>
        /// Adds the element to the set
        /// </summary>
        /// <param name="s">It's the set where the element is going to be added</param>
        /// <param name="value">It's the value of the element to be added</param>
        /// <returns>The set</returns>
        public static Set operator +(Set s, Object value)
        {
            s.Add(value);
            return s;
        }

        /// <summary>
        /// Removes the element from the set
        /// </summary>
        /// <param name="s">It's the set where the element is going to be deleted</param>
        /// <param name="value">It's the value of the element to be deleted</param>
        /// <returns>The set</returns>
        public static Set operator -(Set s, Object value)
        {
            s.Remove(value);
            return s;
        }

        /// <summary
        /// </summary>
        /// <param name="index">It's the index of the element</param>
        /// <returns>the element in the set at the index passed</returns>
        public Object this[int index]
        {
            get
            {
                return GetElement(index);
            }
       
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s">First set</param>
        /// <param name="w">Second set</param>
        /// <returns>The union of the sets</returns>
        public static Set operator |(Set s, Set w)
        {
            return s.Union(w);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w">The other set</param>
        /// <returns>The union of this set and the one passed (all the elements of both)</returns>
        private Set Union(Set w)
        {
            Set union = new();
            for (int i = 0; i < NumberOfElements; i++)
            {
                union.Add(GetElement(i));
            }
            for (int i = 0; i < w.NumberOfElements; i++)
            {
                union.Add(w.GetElement(i));
            }
            return union;
        }
        //// <summary>
        /// 
        /// </summary>
        /// <param name="s">First set</param>
        /// <param name="w">Second set</param>
        /// <returns>The intersection of the sets</returns>
        public static Set operator &(Set s, Set w)
        {
            return s.Intersection(w);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w">The other set</param>
        /// <returns>The intersection of this set and the one passed (all the elements in common)</returns>
        private Set Intersection(Set w)
        {
            Set union = new();
            for (int i=0; i<w.NumberOfElements; i++) {
                Object value = w.GetElement(i);
                if (Contains(value))
                {
                    union.Add(value);
                }
            }
            return union;
        }

        //// <summary>
        /// 
        /// </summary>
        /// <param name="s">First set</param>
        /// <param name="w">Second set</param>
        /// <returns>The difference of the sets</returns>
        public static Set operator -(Set s, Set w)
        {
            return s.Difference(w);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w">The other set</param>
        /// <returns>The difference of this set and the one passed (all the elements in this set that are not in the one passed)</returns>
        private Set Difference(Set w)
        {
            Set difference = new();
            for (int i = 0; i < NumberOfElements; i++)
            {
                Object value = GetElement(i);
                if (!w.Contains(value))
                {
                    difference.Add(value);
                }
            }
            return difference;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s">It's the set where the element is going to be searched</param>
        /// <param name="value">It's the value of the element to be searched</param>
        /// <returns>If the element is in the set</returns>
        public static Boolean operator ^(Set s, Object value)
        {
            return s.Contains(value);
        }


    }
}
