using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace TPP.Lab04
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p">It's the point that will be contained by the perpendicular line</param>
        /// <returns>returns a Line perpendicular that contains the Point2d parameter</returns>
        public Line perpendicular(Point2D p)
        {
            double m = -1 / this.m;
            double n = p.Y + m * p.X;
            return new Line(m, n);
        }

        /// <summary>
        
        /// </summary>
        /// <param name="l">It's another line</param>
        /// <returns>the point of the intersection as transparent</returns>
        public Point2D intersection(Line l)
        {

            double y = (n / m - l.N / l.M) / (1 / m - 1 / l.M);
            double x = (y - l.N) / l.M;
            return new Point2D(x, y, Color.Transparent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p">The point we want the distance with this line</param>
        /// <returns>The distance between a point and this line</returns>
        public double distance(Point2D p)
        {
            Line perp =perpendicular(p);
            Point2D inters= intersection(perp);
            return p.Distance(inters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The represention of the line with the format: y=mx+n</returns>
        public override string ToString()
        {
            return $"y={m}x+{n}";
        }
    }
    

}
