using System;
using LinkedList;

namespace TPP.ObjectOrientation.Overload
{
    /// <summary>
    /// Person class that has its name, surname and age and ID
    /// </summary>
    public class Person : IComparable
    {
        /// <summary>
        /// Name of the person
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Surname of the person
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Age of the person
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// IDNumber of the person
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// It creates a person with the passed parameters
        /// </summary>
        /// <param name="age">It's the age of the person. It's default value is 0</param>
        /// <param name="name">It's the name of the person. It's default value is A</param>
        /// <param name="surname">It's the surname of the person. It's default value is B</param>
        /// <param name="id">It's the id of the person. It's default value is 1</param>
        public Person(int age=0, String name="A", String surname="B", String id="1")
        {
            Age = age;
            FirstName = name;
            Surname = surname;
            IDNumber = id;
        }

       
        public int CompareTo(Object other)
        {
            if(other is Person)
            {
                Person p = (Person)other;
                return IDNumber.CompareTo(p.IDNumber);
            }
            throw new ArgumentException("You cannot compare a Person with another type");
        }

        
        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                return IDNumber.Equals(((Person) obj).IDNumber);
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A string with the format: FirstName Surname, age: , id:</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}, age:{2}, id:{3}", this.FirstName, this.Surname, this.Age,
                  this.IDNumber);
        }

        public override int GetHashCode()
        {
            return Age/IDNumber.Length;
        }
    }
}

