using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervals
{
    public class Bar:Interval
    {
        // additional attribute
        double height;

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                Check();
            }
        }
        
        public Bar():base() {
            height = 0;
        }
        
        public Bar(double? left,double ? right, double height):base(left,right) 
        {
            if (this.height < 0)
                throw new ArgumentException("The height cannot be negative");
            this.height = height;
        }
        
        protected new bool Check()
        {
            #if DEBUG
                base.Check();
                Debug.Assert(Height >= 0);
            #endif
            
            return true;
        }
       
        public override string ToString()
        {
            Check();
            return base.ToString()+", height:"+Height;
        }
        
        public override bool Equals(object obj)
        {
            Check();
            
            Bar bar = obj as Bar;
            if (bar != null)
            {
                bar.Check();
                return base.Equals(obj) && Height== bar.Height;

            }

            return false;    
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        // use base here, rethink the modifier if you find a bug
        // related with the polymorphic method
        public override double? Size()
        {
            Check();
            return base.Size()*height;
        }
        public Bar Intersection(Bar a)
        { 
            Interval interval = base.Intersection(a);

            if (interval == null) { return null; }
            Check();
            a.Check();

            double newHeight = Math.Min(Height, a.Height);


            return new Bar(left: interval.Left, right: interval.Right, height: newHeight);
        }

        public static Bar operator *(Bar a, Bar b)
        {
            if (a == null)
                throw new ArgumentException("The bar passed cannot be null");

            return a.Intersection(b);
        }
    }

    
}
