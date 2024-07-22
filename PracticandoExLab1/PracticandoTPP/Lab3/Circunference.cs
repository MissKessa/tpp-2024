using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Circunference
    {
        private Point2D center;
        private double radius;

        public Circunference(Point2D center, double radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public Circunference TangentWithCenter(Point2D p)
        {
            //if (p.Y == center.Y)
            //{
            //    double x = center.X + radius;
            //    Point2D tangent = new Point2D(x, center.Y);
            //}
            //else if (p.X == center.X)
            //{
            //    double y = center.Y + radius;
            //    Point2D tangent = new Point2D(center.X, y);
            //}
            double x = center.X + p.X-center.X+radius;
            double y = center.Y + p.Y - center.Y + radius;
            Point2D tangent = new Point2D(x,y);

            double radiusTangent=p.EuclideanDistance(tangent);
            return new Circunference(p, radiusTangent);
        }
    }
}
