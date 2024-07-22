using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Point2D
    {

        private double x,y;//Coordinates
        private Color c;
        public enum Color
        {
            Transparent, Black, Red
        }

        public Point2D() : this(0, 0)
        {

        }
        public Point2D(double x, double y) //creates transparent point
        {
            this.x= x;
            this.y= y;
            c = Color.Transparent;
        }

        public Point2D(double x, double y, Color c):this(x,y) //constructor that derives from another
        {
            this.c = c;
        }

        ~Point2D() //destructor
        {
            Console.WriteLine("I am being destroyed");
        }

        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public double Y
        {
            get { return this.y; }
            set { this.y= value; }
        }
        public Color C
        {
            get { return this.c; }
            set { this.c= value; }
        }

        public double Azimuth //new property that returns the angle between x and y
        {
            get
            {
                return Math.Atan2(y, x);
            }
        }

        public double EuclideanDistance(Point2D p)
        {
#if DEBUG //manipule source code without compiling it. You need using System.Diagnostics;
            Trace.WriteLine($"Trace conditional compilation {this} to {p}"); //in Release mode this code will not be compiled. SO you cna use it, but when you release it, this line will be removed from the released code
#endif
            Trace.WriteLine($"Trace unconditional compilation {this} to {p}");
            Trace.WriteLine($"Debug message {this} to {p}");

            return Math.Sqrt(((p.X - X) * (p.X - X))+ ((p.Y - Y) * (p.Y - Y)));
        }
        /// <summary>
        /// XML comment tostring
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return $"({x},{y}):{C}";
        }
    }
}
