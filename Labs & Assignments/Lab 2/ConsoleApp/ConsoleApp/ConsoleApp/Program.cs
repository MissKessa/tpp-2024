using System;
using TPP.Lab02;
using static ConsoleApp.Point2D;

namespace ConsoleApp
{
    internal class Program
    {
        //IncrementTwoDouble.Takes four double parameters, first and second by reference.
        //Modifies these two parameters adding third and fourth parameters value
        //respectively, returns void. For instance, this call: IncrementTwoDouble(ref x, ref y,1.5,2.0) adds 1.5 to x and 2.0 to y
        public static void IncrementTwoDouble(ref double x, ref double y, double a, double b)
        {
            x += a;
            y += b;
        }

        static void Main(string[] args)
        {
            Point2D[] t;
            t = GenerateTrajectory(length: 5, startX: -.5, startY: 2, deltaX:.5, deltaY: .5);
            ShowTrajectory(t);
            double d;
            Point2D s, e;
            DistanceStartEnd(t, out d, out s, out e);
            Console.WriteLine($"{d} {s} {e}");
            e.X = 666;
            ShowTrajectory(t);
            Console.WriteLine(123.Reverse());


            Console.WriteLine(13.IsPrime());
            Console.WriteLine(14.IsPrime());

            Console.WriteLine(24.GCD(36));
        }


        //GenerateTrajectory. Takes a length parameter (int, default value 10), start coordinates x and y(double, default value both 0.0), x and y increment(double,
        //default value both 1.0). Returns a trajectory, stored in a Point2d array with the number of elements length, where all the points except the first one are
        //obtained adding to the previous point in the trajectory the indicated increments using previously defined function IncrementTwoDouble.See arrays project in solution encapsulation

        public static Point2D[] GenerateTrajectory(int length=10, double startX=0.0, double startY=0.0, double deltaX=1.0, double deltaY=1.0)
            
        {
            Point2D[]trajectory= new Point2D[length];
            trajectory[0] = new Point2D(startX, startY, Color.Black);

            for(int i=1; i<length; i++)
            {
                IncrementTwoDouble(ref startX, ref startY, deltaX, deltaY);
                trajectory[i] = new Point2D(startX, startY, Color.Black);
            }
            return trajectory;
        }


        //ShowTrajectory, takes an array representing a trajectory as described previously and an optional boolean, true if only first quadrant points are to be shown(x>=0 and
        //y>=0) false otherwise.Outputs trajectory points textual representation to cons
        public static void ShowTrajectory(Point2D[] trajectory, bool firstQuad = false)
        {
            for (int i=0; i<trajectory.Length; i++)
            {
                if (!firstQuad || (trajectory[i].X>=0 && trajectory[i].Y>=0))
                    System.Console.WriteLine(trajectory[i]);
            }
            System.Console.WriteLine();
        }

        //DistanceStartEnd, takes a Point2d array and, as output references, three parameters: trajectory covered distance(the summation of the distances between each point
        //and the following one), starting and ending points. ¿What happens with the trajectory array values if returned starting and ending points properties are modified
        //after function call? Output the trajectory to check it
        public static void DistanceStartEnd(Point2D[] trajectory, out double distance, out Point2D start, out Point2D end)
        {
            //start = trajectory[0];
            //end = trajectory[trajectory.Length-1];
            
            start= new Point2D(trajectory[0].X, trajectory[0].Y, Color.Black);
            end = new Point2D(trajectory[trajectory.Length-1].X, trajectory[trajectory.Length - 1].Y, Color.Black);
            distance = 0.0;

            for (int i = 0; i < trajectory.Length - 1; i++)
            {
                distance += trajectory[i].EuclideanDistance(trajectory[i + 1]);
            }
            
        }
    }
}
