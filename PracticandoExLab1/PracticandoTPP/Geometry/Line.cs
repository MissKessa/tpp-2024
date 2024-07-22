using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Line //y=m*x+n
    {
        private double m; //slope
        private double n; //intercept with Y axis

        public double M { get { return m; } set { this.m = value; } }
        public double N { get { return n; } set { this.n = value; } }

        public Line() : this(0,0){ }
        public Line(double m, double n)
        {
            this.m = m;
            this.n = n;
        }

        ~Line()
        {
            Console.WriteLine("I'm beiing destroyed");
        }

        //Returns perpendicular line that contains the given point
        public Line PerpendicularLine(Point2D p)
        {
            double m= -1/this.m;
            double n = p.Y + (1 / this.m) * p.X;

            return new Line(m, n);
        }

        //Intersection between 2 lines (a point)
        public Point2D LineIntersection(Line l)
        {
            double y=(N/M -l.N/l.M)/(1/m-1/l.M);
            double x = (y - l.N) / l.M;

            return new Point2D(x, y);
        }

        //Shortest distance between the point and the line
        public double ShortestDistance(Point2D p)
        {
            Line l = PerpendicularLine(p);
            Point2D intersection = LineIntersection(l);

            return p.EuclideanDistance(intersection);
        }

        /// <summary>
        /// This is an XML comment
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"y={M}x+{N}";
        }
    }
}
