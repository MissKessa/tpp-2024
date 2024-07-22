using System;
using System.ComponentModel;

namespace Lab3
{
    public class Interval :IMedible
    {
        public void StatePreConditions()
        {
            if (!Check()) throw new InvalidOperationException();
        }
        public double? Start { 
            get{ StatePreConditions();  return Start; }  
            set { StatePreConditions(); Start = value; StatePreConditions(); } }
        public double? End { 
            get { StatePreConditions(); return End; }
            set { StatePreConditions(); End = value; StatePreConditions(); } }

        public Interval()
        {
            Start = null;
            End=null;
        }

        public Interval(double? start, double? end)
        {
            if (start > end) throw new ArgumentException();
            if(start==null && end!=null) throw new ArgumentException();
            if (start != null && end == null) throw new ArgumentException();
            Start = start;
            End = end;
        }

        protected virtual Boolean Check() //Invariants
        {
            if (Start == null && End == null) return true;
            if(Start>End) return false;
            if(Start==null || End==null) return false;

            return true;
        }

        public virtual double? Size()
        {
            StatePreConditions();
            if (Start==null && End==null) return null;
            return End-Start; 
        }

        public override string ToString()
        {
            return $"[{Start}, {End}]";
        }

        public override bool Equals(object obj)
        {
            Interval interval = obj as Interval;
            if(interval == null) return false;
            return interval.Start.Equals(Start) && interval.End.Equals(End);
        }

        public override int GetHashCode()
        {
            return Start.GetHashCode() ^ End.GetHashCode();
        }

        public static Interval operator *(Interval a, Interval b) //Intersection of the 2 intervals
        {
            if (a == null || b==null) return null;
            if (a.Start == null || b.Start == null ) return null;
            if(b.Start>a.End) return null;
            if(a.Start> b.End) return null;

            double? Start = a.Start>b.Start ? a.Start : b.Start;
            double? End= a.End<b.End? a.End : b.End;

            return new Interval(Start, End);

        }

    }
}
