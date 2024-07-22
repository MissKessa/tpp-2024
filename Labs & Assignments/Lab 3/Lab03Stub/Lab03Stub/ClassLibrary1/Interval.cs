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

        //code the default constructor
        public Interval()
        {
            // add code here

        }

        //code the constructor from two nullable double
        public Interval(double? left, double? right)
        {
            // a single null or left greater than right are not correct
            // throw an exeception of the suitable type
            // add code here
        }
        //code the get and set

        // code Check. Later you will use this from Bar. Think about the access modifier
        // use Check within any method that could possible and wrongly change the state of the object
        // simulate a programming error that leads to a state that does not fullfil the invariant
        // for instance, assign null to left or right
        // use conditional compilation to remove that call from production code
        protected bool Check()
        {
            //returns true if the interval meets the invariant
            //modify this
            return true;
        }
        // code Size, rethink modifier if you find later a bug related with the polymorphic method 
        // whe called with two Bar
        public double? Size()
        {
            //modify this
            return 0;
        }
        // code ToString
        public override string ToString()
        {
            //modify this
            return "";
        }
        // code Equals
        public override bool Equals(object obj)
        {
            //1) first alternative is check if obj is an interval, if so, cast to Interval and
            //compare the left and right sides
            //if it is not an interval, return false
            //2) assing obj to a tmp as an Interval, if the result is different than null, compare the attributes
            //if the result is null, return false

            // modify this
            return false;

        }
        public override int GetHashCode()
        {
            // read the linked article in the pdf, in this case, returning
            // the hashcode of the textual representation will do
            return ToString().GetHashCode();
        }
        public Interval Intersection(Interval a)
        {
            //think about the relative positions of the intervals and
            //return a new Interval with the result
            //or you could think twice and get a simpler approach
            
            return new Interval();
        }
    }
}
