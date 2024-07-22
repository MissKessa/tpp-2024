using System;
using System.Diagnostics;
namespace Intervals
{
    public interface IMedible
    {
        double? Size();
    }

    public class Interval:IMedible
    {
        double? left,right;

        public Interval()
        {
            left=null; 
            right=null;
        }

        //code the constructor from two nullable double
        public Interval(double? left, double? right)
        {
            // a single null or left greater than right are not correct
            // throw an exeception of the suitable type
            // add code here
            if ((left == null && right != null) || (left != null && right == null))
                throw new ArgumentException("Cannot have a single null");
            else if (left > right)
                throw new ArgumentException("Left cannot be greater than right");

            this.left = left;
            this.right = right;
        }

        public double? Left { 
            get { return left; } 
            set { left = value; Check(); }
        }
        public double? Right
        {
            get { return right; }
            set { right = value; Check(); }
        }



        // code Check. Later you will use this from Bar. Think about the access modifier
        // use Check within any method that could possible and wrongly change the state of the object
        // simulate a programming error that leads to a state that does not fullfil the invariant
        // for instance, assign null to left or right
        // use conditional compilation to remove that call from production code
        protected bool Check()
        {
            #if DEBUG
                Debug.Assert((Left != null && Right != null) || (Left == null && Right == null));
                Debug.Assert(Left <= right);
            #endif

            return true; //returns true if the interval meets the invariant
        }
        // code Size, rethink modifier if you find later a bug related with the polymorphic method 
        // whe called with two Bar
        public virtual double? Size()
        {
            Check();

            if (Left == Right)
                return null;
            return Right-Left;
        }
        // code ToString
        public override string ToString()
        {
            return "[" + Left + ", " + Right + "]";
        }
        // code Equals
        public override bool Equals(object obj)
        {
            //1) first alternative is check if obj is an interval, if so, cast to Interval and
            //compare the left and right sides
            //if it is not an interval, return false
            //2) assing obj to a tmp as an Interval, if the result is different than null, compare the attributes
            //if the result is null, return false
            Check();

            Interval interval = obj as Interval;
            if (interval != null)
            {
                interval.Check();
                if (Left == interval.Left && Right == interval.Right) return true;
            }

            return false;

        }
        public override int GetHashCode()
        {
            // read the linked article in the pdf, in this case, returning the hashcode of the textual representation will do
            Check();
            return ToString().GetHashCode();
        }
        public  Interval Intersection(Interval a)
        {
            if (a == null)
                throw new ArgumentException("The interval passed cannot be null");
            Check();
            a.Check();
            if (!(Left > a.Right)|| (Right< a.Left))
            {
                double newLeft = Math.Max((double)Left, (double) a.Left);
                double newRight= Math.Min((double)Right, (double)a.Right);

                return new Interval(newLeft, newRight);
            }
            
            return null;
        }

        public static Interval operator * (Interval a, Interval b)
        {
            if (a == null)
                throw new ArgumentException("The interval passed cannot be null");

            return a.Intersection(b);
        }
    }
}
