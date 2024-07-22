using System;

namespace Line
{
    public class Line
    {

        /// <summary>
        /// m is the slope and n the intercept
        /// </summary>
        double m, n;

        public double M
        {
            get
            {
                return m;
            }
            set
            {
                m = value;
            }
        }

        public double N
        {
            get
            {
                return n;
            }
            set
            {
                n = value;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Line() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        public Line(double m, double n)
        {
            this.m = m;
            this.n = n;
        }

        public Line perpendicular(Point2D p)
        {
            return new Line();
        }
    }
}
