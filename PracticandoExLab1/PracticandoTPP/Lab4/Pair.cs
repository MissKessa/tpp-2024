using System;

namespace Lab4
{
    public class Pair<T> where T:IComparable<T>
    {
        private T attribute1;
        private T attribute2;

        public Pair(){
            attribute1 = default(T);
            attribute2 = default(T);
        }
        public int CompareTo(Pair<T> p)
        {
            int comparison1=attribute1.CompareTo(p.attribute1);
            if (comparison1 == 0)
            {
                int comparison2=attribute2.CompareTo(p.attribute2);
                return comparison2;
            }
            return comparison1;

        }

        public override string ToString()
        {
            return $"[{attribute1},{attribute2}]";
        }


    }
}
