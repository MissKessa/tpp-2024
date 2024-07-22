using System;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace TPP.Lab04
{
    //In the class library define the enum Color with the values Transparent, Balck and Red

    /// <summary>
    /// An enumeration that represents colors
    /// </summary>
    public enum Color {
        Transparent,Black,Red
    }

    /// <summary>
    /// A class that represents bidimensional points
    /// </summary>
    public class Point2D
    {
        //double x { get; set; } //Automatically creates getter and setter. This syntax doesn't allow you to addlogic in getter and setter
        /// <summary>
        /// The coordinates
        /// </summary>
        double x, y; //attributes
       
        /// <summary>
        /// Color of the point
        /// </summary>
        Color c;

        //Constructors: default constructor,
        /// <summary>
        /// Default constructor
        /// </summary>
        public Point2D() { }

        //Constructor from two double (creates a Transparent point)
        /// <summary>
        /// Two double constructor
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        public Point2D(double x, double y) {
            this.x = x;
            this.y = y;
            c=Color.Transparent;
        }

        //and finally from two double and a Color.
        public Point2D(double x, double y, Color color) {
            this.x = x;
            this.y = y;
            c = color;
        }

        //Destructor.
        ~Point2D() { 
            Console.WriteLine($"Point2D destructor {this.x} {this.y}"); //this is no longer displayed,as the destructor is not deterministic
        }
       
        public double X //capitalize name of the attribute for comprehensive syntax of the getters and setters
        {
            get { 
                //you can add code here
                return x; 
            }
            set { 
                x = value; 
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public Color C
        {
            get
            {
                return c;
            }
            set
            {
                c = value;
            }
        }

        public double Azimuth //new property that returns the angle between x and y
        {
            get
            {
                return Math.Atan2( y, x );
            }
        }
        //• Methods: 1. Euclidean distance between two points.
        /// <summary>
        /// Computes the euclidean distance from the caller to the parameter
        /// </summary>
        /// <param name="p">the "to" point</param>
        /// <returns>The distance as a double</returns>
        public double Distance (Point2D p)
        {
#if DEBUG //manipule source code without compiling it. You need using System.Diagnostics;
            Trace.WriteLine($"Trace conditional compilation {this} to {p}"); //in Release mode this code will not be compiled. SO you cna use it, but when you release it, this line will be removed from the released code
#endif
            Trace.WriteLine($"Trace unconditional compilation {this} to {p}");
            Trace.WriteLine($"Debug message {this} to {p}");
            return Math.Sqrt((x - p.x) * (x - p.x) + (y - p.y) * (y - p.y));
        }
        //2. ToString, a Point2d with x = 1.0, y= 2.0, c= Red is shown as (1.0;2.0):Red
        public override string ToString()
        {
            return $"({x};{y}):{c}"; //String interpolation: what is between {} is considered an expression and will be evaluated
        }

    }
}
