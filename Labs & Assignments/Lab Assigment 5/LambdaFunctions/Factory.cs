using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace PTP_HW_5
{
    public class Factory
    {
        public static Person[] CreatePeople()
        {
            string[] names = { "James", "Mary", "John", "Patricia", "Mary", "James", "Michael", "Barbara", "James", "Elizabeth" };
            string[] surnames = { "Smith", "Jones", "Taylor", "Williams", "Brown", "Jones", "Brown", "Smith", "Taylor", "Williams" };
            string[] ids = { "9876384A", "103478387F", "23476293R", "4837649A", "67365498B", "98673645T", "56837645F", "87666354D", "9376384K", "3582356F" };

            Person[] people = new Person[names.Length];
            for (int i = 0; i < people.Length; i++)
                people[i] = new Person(names[i], surnames[i], ids[i]);
            return people;
        }
       
        
        public static Angle[] CreateAngles()
        {
            Angle[] angles = new Angle[361];
            for (int angle = 0; angle <= 360; angle++)
                angles[angle] = new Angle(angle / 180.0 * Math.PI);
            return angles;
        }

    }
}
