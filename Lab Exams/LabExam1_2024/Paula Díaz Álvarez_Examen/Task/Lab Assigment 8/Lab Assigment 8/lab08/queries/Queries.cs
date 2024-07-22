using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab08
{

    class Query
    {
        private Model model = new Model();

        static void Main(string[] args)
        {
            Query query = new Query();

            query.Query1();
            query.Query2();
            query.Query3();
            query.Query4();
            query.Query5();
            query.Query6();
            
            query.Homework1();
            query.Homework2();
            query.Homework3();
            query.Homework4();
            query.Homework5();

            query.Extra1();
            query.Extra2();
            query.Extra3();
            query.Extra4();
            query.Extra5();

            Console.ReadLine();
        }

        // Check out:
        //  http://msdn.microsoft.com/en-us/library/9eekhta0.aspx
        //  https://msdn.microsoft.com/es-es/library/bb397933.aspx


        private void Query1()
        {
            // Show the phone calls that lasted more than 15 seconds
            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 1 *** *** ***");
            Console.WriteLine();

            // Query syntax
            var q1 =
                from pc in model.PhoneCalls
                where pc.Seconds > 15
                select pc;

            foreach (var item in q1)
                Console.WriteLine(item);


            // Method syntax
            Console.WriteLine();

            var q1_m = model.PhoneCalls.Where(pc => pc.Seconds > 15);

            foreach (var item in q1_m)
                Console.WriteLine(item);
        }
		
		private void Query2()
        {
            // Show the name and surname of the employees older than 50 that work in Cantabria

            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 2 *** *** ***");
            Console.WriteLine();

            var q2 = model.Employees.Where(em => em.Age > 50 && em.Province.Equals("Cantabria")).Select(e=> new {TheName=e.Name, TheSurname = e.Surname }); //With select the return type now is new {String, String] not a list of employees

            foreach (var item in q2)
            {
                //Console.WriteLine($"{item.Name} {item.Surname}"); //Do it when not using Select
                Console.WriteLine(item);
            }

        }
		
		private void Query3()
        {
            // Show the names of the departments with more than one employee

            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 3 *** *** ***");
            Console.WriteLine();

            var q3 = model.Departments.Where(d => d.Employees.Count() > 1);

            foreach (var item in q3)
                Console.WriteLine($"{item.Name}");

        }
        
        private void Query4()
        {
            // Show the phone calls of each employee ordered by employee name. 
            // Each line should show the name of the employee and the phone call duration in seconds.

            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 4 *** *** ***");
            Console.WriteLine();

            var q4 = model.Employees.Join(model.PhoneCalls, e => e.TelephoneNumber, p => p.SourceNumber, (e, p) => new { e.Name, p.Seconds }).OrderBy(ep => ep.Name);
            //var q4 = model.Employees.Join(model.PhoneCalls, e => e.TelephoneNumber, p => p.SourceNumber, (e, p) => new { e, p }).OrderBy(ep=>ep.e.Name);

            foreach (var item in q4)
            {
                Console.WriteLine(item);
            }
        }
		
		private void Query5()
        {
            // Show, grouped by province, the name of the employees 
			
			Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 5 *** *** ***");
            Console.WriteLine();

            var q5 = model.Employees.GroupBy(e => e.Province);
            foreach(var prov in q5)
            {
                Console.WriteLine(prov.Key);
                foreach (var item in prov) Console.WriteLine("\t"+item.Name);
            }
			
		}
		
		private void Query6()
        {
            // Show the phone calls done by employees in each department (grouped by departement)

            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 6 *** *** ***");
            Console.WriteLine();

            var q6= model.Employees.Join(model.PhoneCalls, e => e.TelephoneNumber, p => p.SourceNumber, (e, p) => new { e, p.Seconds }).GroupBy(ep=> ep.e.Department);
            foreach (var item in q6)
            {
                Console.WriteLine(item.Key.Name);
                foreach (var ep in item) Console.WriteLine($"\t{ep.Seconds}, {ep.e.Name}");
            }

        }



        /************ Homework **********************************/

        private void Homework1()
        {
            // Show, ordered by age, the names of the employees in the Computer Science department, 
            // who have an office in the Faculty of Science, 
            // and who have done phone calls longer than one minute
            Console.WriteLine();
            Console.WriteLine("*** *** *** HOMEWORK 1 *** *** ***");
            Console.WriteLine();

            var h1 = model.Employees.Where(e=> e.Department.Name.Equals("Computer Science") && e.Office.Building.Equals("Faculty of Science")).Join(
                model.PhoneCalls, e => e.TelephoneNumber, p => p.SourceNumber, (e, p) => new { e, p }).Where(ep=>ep.p.Seconds>60).OrderBy(ep => ep.e.Age);

            foreach (var item in h1)
            {
                Console.WriteLine(item.e.Name);
            }
        }

        private void Homework2()
        {
            // Show the summation, in seconds, of the phone calls done by the employees of the Computer Science department
            Console.WriteLine();
            Console.WriteLine("*** *** *** HOMEWORK 2 *** *** ***");
            Console.WriteLine();

            var h2 = model.Employees.Where(e => e.Department.Name.Equals("Computer Science")).Join(
                model.PhoneCalls, e => e.TelephoneNumber, p => p.SourceNumber, (e, p) => new { e, p });

            int sum = 0;
            foreach(var item in h2)
            {
                sum += item.p.Seconds;
            }

            Console.WriteLine(sum);
        }

        private void Homework3()
        {
            // Show the phone calls done by each department, ordered by department names. 
            // Each line must show “Department = <Name>, Duration = <Seconds>”

            Console.WriteLine();
            Console.WriteLine("*** *** *** HOMEWORK 3 *** *** ***");
            Console.WriteLine();

            var h3 = model.Employees.Join(model.PhoneCalls, e => e.TelephoneNumber, p => p.SourceNumber, (e, p) => new { Department = e.Department.Name, Duration = p.Seconds }).OrderBy(ep=>ep.Department);
            foreach (var item in h3)
            {
                Console.WriteLine(item);
            }
        }

        private void Homework4()
        {
            // Show the departments with the youngest employee, 
            // together with the name of the youngest employee and his/her age 
            // (more than one youngest employee may exist)

            Console.WriteLine();
            Console.WriteLine("*** *** *** HOMEWORK 4 *** *** ***");
            Console.WriteLine();

            var minAge = model.Employees.Min(e => e.Age);
            var h4 = model.Employees.Where(e=>e.Age==minAge);
            foreach (var item in h4)
            {
                Console.WriteLine($"Department={item.Department.Name}, Employee={item.Name}, Age={item.Age}");
            }

        }

        private void Homework5()
        {
            // Show the greatest summation of phone call durations, in seconds, 
            // of the employees in the same department, together with the name of the department 
            // (it can be assumed that there is only one department fulfilling that condition)
            Console.WriteLine();
            Console.WriteLine("*** *** *** HOMEWORK 5 *** *** ***");
            Console.WriteLine();

            var departmentsAndSeconds = model.PhoneCalls.Join(model.Employees, p => p.SourceNumber, e => e.TelephoneNumber, (p, e) => new { Department = e.Department.Name, Duration = p.Seconds }).GroupBy(ep => ep.Department);
            IDictionary<String, int> sumSeconds=new Dictionary<String, int>();
            foreach(var item in departmentsAndSeconds)
            {
                int sum = 0;
                foreach(var time in item)
                {
                    sum += time.Duration;
                }
                sumSeconds.Add(item.Key, sum);
            }

            var maxSeconds=sumSeconds.Max(ep => ep.Value);
            var departmentWithMaxSeconds = sumSeconds.Where(ep => ep.Value == maxSeconds);

            foreach(var item in departmentWithMaxSeconds)
            {
                Console.WriteLine($"{item.Key}, {item.Value}");
            }
        }

        // More exercises
        private void Extra1()
        {
            // Show the name and surname of the employees from the Mathematics department that have an
            //office in Polytechnical and age greater than 30
            Console.WriteLine();
            Console.WriteLine("*** *** *** EXTRA 1 *** *** ***");
            Console.WriteLine();

            var p = model.Employees.Where((e) => e.Age > 30 && e.Department.Name.Equals("Mathematics")).Select((e) => new {The_Name=e.Name, The_Surname=e.Surname});
            foreach(var item in p)
            {
                Console.WriteLine(item);
            }
        }

        private void Extra2()
        {
            // Show the list of Employees' number phones order from Greater to Less duration. 
            //Also show the total duration of all the calls
            Console.WriteLine();
            Console.WriteLine("*** *** *** EXTRA 2 *** *** ***");
            Console.WriteLine();

            var p = model.PhoneCalls.Join(model.Employees,(p)=>p.SourceNumber, (e)=> e.TelephoneNumber, (p,e) => new { Duration = p.Seconds,PhoneNumber =e.TelephoneNumber}).OrderByDescending((ep)=>ep.Duration);
            int seed = 0;
            int total = p.Aggregate(seed, (seed, ep) => (seed+=ep.Duration));
            Console.WriteLine($"Total: {total}");
            foreach (var item in p)
            {
                Console.WriteLine(item);
            }
        }

        private void Extra3()
        {
            // Obtain all the employees that are not in the department of Computer Science
            //Then print with an string all the phone numbers cocatenated with ';'
            Console.WriteLine();
            Console.WriteLine("*** *** *** EXTRA 3 *** *** ***");
            Console.WriteLine();

            var p = model.Employees.Where((e) => !e.Department.Name.Equals("Computer Science"));
            String seed = "";
            String result = p.Aggregate(seed, (seed, e) => seed += e.TelephoneNumber + ";");
            Console.WriteLine(result);
        }

        private void Extra4()
        {
            // Obtain the list of phone calls that were made by a number that is not from any employee.
            //Return also the duration of the phone call
            Console.WriteLine();
            Console.WriteLine("*** *** *** EXTRA 4 *** *** ***");
            Console.WriteLine();

            var phoneNumberIsOfEmployee = model.PhoneCalls.Join(model.Employees, (p) => p.SourceNumber, (e) => e.TelephoneNumber, (p,e)=>p);
            var phoneNumbersNotOfEmployee = model.PhoneCalls.Where((p)=>!phoneNumberIsOfEmployee.Contains(p)).Select((p)=>new { Number = p.SourceNumber, Duration = p.Seconds });

            foreach(var item in phoneNumbersNotOfEmployee)
            {
                Console.WriteLine(item);
            }
        }

        private void Extra5()
        {
            // Obtain the longest phone call (not Max allowed)
            Console.WriteLine();
            Console.WriteLine("*** *** *** EXTRA 5 *** *** ***");
            Console.WriteLine();

            int maxDuration = 0;
            var longestDuration =model.PhoneCalls.Aggregate(maxDuration, (maxDuration, p) =>
            {
                if (p.Seconds > maxDuration)
                {
                    maxDuration = p.Seconds;
                }
                return maxDuration;
            });
            
            var longestCalls = model.PhoneCalls.Where((p) => p.Seconds == longestDuration).Select((p) => new{Source=p.SourceNumber, Destin=p.DestinationNumber, Duration=p.Seconds});
            foreach(var item in longestCalls)
            {
                Console.WriteLine(item);
            }


        }






    }

}
