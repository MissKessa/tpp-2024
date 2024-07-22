using System;

namespace Lab2
{
    public static class Parameters
    {
        /*
         * Takes 4 elements: a and b passed by references 
         */
        public static void IncrementTwoDouble(ref double a, ref double b, double c, double d)
        {
            a += c;
            b += d;
        }

        /*
         * Returns an array of the given length of Point"D, where all the points except the 1st one are obtained by adding the previous point in the trajectory the indicated increments
         */
        public static Point2D[] GenerateTrajectory(int length=10, double startX=0, double startY=0, double deltaX = 1, double deltaY = 1)
        {
            Point2D[] trajectory = new Point2D[length];
            trajectory[0]=new Point2D(startX, startY);
            for (int i = 1; i < length; i++)
            {
                //trajectory[i] = new Point2D(startX+deltaX*i, startY + deltaY * i);
                IncrementTwoDouble(ref startX, ref startY, deltaX, deltaY);
                trajectory[i] = new Point2D(startX, startY);
            }
            return trajectory;
        }

        /*
         * Shows the trajectory. It takes an optional boolean parameter that indicates if only first quadrant points are shown (x>=0 && y>=0)
         */
        public static void ShowTrajectory(Point2D[] trajectory, Boolean showFirstQuadrant=true)
        {
            for (int i = 0; i < trajectory.Length; i++)
            {
                Point2D p= trajectory[i];
                if (showFirstQuadrant && (p.X>=0 && p.Y >= 0))
                {
                    Console.WriteLine(p);
                } else if (!showFirstQuadrant)
                {
                    Console.WriteLine(p);
                }
            }
        }

        public static void DistanceStartEnd(Point2D[] trajectory, out double coveredDistance, out Point2D startingPoint, out Point2D endingPoint)
        {
            coveredDistance = 0;
            //You are passing the reference:
            //startingPoint = trajectory[0];
            //endingPoint = trajectory[trajectory.Length-1];

            startingPoint = new Point2D(trajectory[0].X, trajectory[0].Y);
            endingPoint = new Point2D(trajectory[trajectory.Length - 1].X, trajectory[trajectory.Length - 1].Y);

            for (int i = 1;i < trajectory.Length;i++)
            {
                double d = trajectory[i].EuclideanDistance(trajectory[i - 1]);
                coveredDistance += d;
            }
        }

    }
}
