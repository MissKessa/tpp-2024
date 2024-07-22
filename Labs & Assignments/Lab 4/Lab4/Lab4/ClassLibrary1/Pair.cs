using System;

namespace ClassLibrary1
{
    public class Pair<T>: IComparable<Pair<T>> where T:IComparable<T>
    {
        public T first, second;
        public Pair() { first = default(T); second = default(T);     } //Set the variables to their default value
        public Pair(T first, T second) { this.first = first; this.second = second; }

        public int CompareTo(Pair<T> other)
        {
            int comparison = first.CompareTo(other.first);
            if (comparison == 0)
            {
                return second.CompareTo(other.second);
            }
            return comparison;
        }
        public override string ToString()
        {
            return $"[{first},{second}]";
        }
    }
}
