using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Assigment
{
    public class Set: Lab2_Assigment.List.List //List that cannot contain duplicated elements
    {
        public Set():base() { }
        public Set(Node node) : base(node) { }
        public Set(Object value) : base(value) { }

        public override Boolean AddValueAtPosition(Object value, int index)
        {
            if (Contains(value)) return false;
            base.AddValueAtPosition(value, index);
            return true;
        }

        public static Set operator +(Set s, Object element) //Adds element to the set
        {
            s.AddValue(element);
            return s;
        }

        public static Set operator -(Set s, Object element) //Removes element of the set
        {
            s.RemoveByValue(element);
            return s;
        }

        public Object this[int pos] 
        {
            get { return GetElement(pos); } //Gets element of the set according to the given position
        }

        public static Set operator |(Set s, Set t) //Unions of sets
        {
            Set q= new Set();
            for (int i = 0; i<s.NumberOfElements; i++)
            {
                q.AddValue(s[i]);
            }
            for (int i = 0; i < t.NumberOfElements; i++)
            {
                q.AddValue(t[i]);
            }
            return q;
        }

        public static Set operator &(Set s, Set t) //Intersection of sets
        {
            Set q = new Set();
            for (int i = 0; i < s.NumberOfElements; i++)
            {
                if (t.Contains(s[i]))
                {
                    q.AddValue(s[i]);
                }
            }
            return q;
        }

        public static Set operator -(Set s, Set t) //Difference of sets
        {
            Set q = new Set();
            for (int i = 0; i < s.NumberOfElements; i++)
            {
                if (!t.Contains(s[i]))
                {
                    q.AddValue(s[i]);
                }
            }
            return q;
        }

        public static Boolean operator ^(Set s, Object element) //Element is contained in set
        {
            return s.Contains(element);
        }
    }
}
