using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.ObjectOrientation.Encapsulation {

    /// <summary>
    /// Struct demo
    /// </summary>
    class Program {

        static void Increment(PointClass pointObject, int x, int y) {
            pointObject.X += x;
            pointObject.Y += y;
        }

        static void Increment(PointStruct pointStruct, int x, int y) {
            pointStruct.X += x;
            pointStruct.Y += y;
        }

        static void Main() {
            const int x = 10, y = 20;
            PointClass pointObject = new PointClass(x, y);
            PointStruct pointStruct = new PointStruct { X = x, Y = y };

            Console.WriteLine(pointObject); //Point object in (10,20).
            Console.WriteLine(pointStruct); //Point struct in (10,20).

            Increment(pointObject, 10, 10); //Point object in (20,30).
            Increment(pointStruct, 10, 10); //Point struct in (10,20).

            Console.WriteLine(pointObject);
            // * The struct has not been modified because it is placed in the stack, and hence the parameter is copy of the argument!
            Console.WriteLine(pointStruct);
        }


    }


}
