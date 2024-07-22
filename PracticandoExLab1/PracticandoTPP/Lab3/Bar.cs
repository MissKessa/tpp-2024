using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Bar : Interval
    {
        public double Height { get; set; }

        public Bar():base() { Height = 0; }
        public Bar(double height, double?start, double? end):base(start, end)
        {
            if(height<0) throw new ArgumentException();
            Height = height;
        }

        private new Boolean Check() //Invariant
        {
#if DEBUG
                base.Check();
                Debug.Assert(Height >= 0);
#endif

            return true;
        }

        private new void StatePreConditions()
        {
            if(!Check()) throw new InvalidOperationException();
        }

        public override string ToString()
        {
            return base.ToString()+$"-h={Height}";
        }
        public override bool Equals(object obj)
        {
            Bar bar = obj as Bar;
            if (bar== null) return false;  
            return base.Equals(obj)&& bar.Height==Height;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode()^Height.GetHashCode();
        }

        public override double? Size()
        {
            StatePreConditions();
            double? size = base.Size();
            if (size == null) return null;
            return size * Height;
        }

        public static Bar operator*(Bar a, Bar b)
        {
            Interval interval = (Interval)a * (Interval)b;
            double Height=a.Height<b.Height?a.Height:b.Height;
            return new Bar(Height, interval.Start,interval.End);
        }
    }
}
