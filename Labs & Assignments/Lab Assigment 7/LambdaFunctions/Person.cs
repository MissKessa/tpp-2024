using System;
using System.Collections;

namespace PTP_HW_5
{
    public class Person
    {
        public String Name { get; set; }

        public String Surname { get; private set; }
        
        public String Id { get; private set; }

        public override String ToString()
        {
            return String.Format("{0} {1} with ID {2}", Name, Surname, Id);
        }

        

        public Person(String name, String surname, string id)
        {
            this.Name = name;
            this.Surname = surname;
            this.Id = id;
        }
    }
}
