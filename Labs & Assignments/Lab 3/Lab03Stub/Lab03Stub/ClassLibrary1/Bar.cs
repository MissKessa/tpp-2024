using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervals
{
    public class Bar:Interval
    {
        // additional attribute
        double heigth;
        // use of base
        public Bar():base() { 
            //add code here
            
        }
        // use base for the other constructor
        public Bar(double? left,double ? right, double heigth) //use base here
        {
            // add code here
        }
        // use base here too 
        protected new bool Check()
        {
            //modify this
            return true;
        }
        // use base here too
        public override string ToString()
        {
            //modify this
            return "";
        }
        // use base here too
        public override bool Equals(object obj)
        {
        //modify this
        return false;    
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        // use base here, rethink the modifier if you find a bug
        // related with the polymorphic method
        public  double? Size()
        { 
            //add code here
            return null;
        }
    }
}
