using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TPP.Laboratory.Functional.Lab08;
using LinkedList;
using System.Runtime.CompilerServices;
using System.Collections;

namespace ConsoleAppExamLI3
{
    internal static class Exam
    {
        private static Model model=new Model();
 
        static void Main(string[] args)
        {
            //1)
            //show 20 numbers between 0 and 10 using the method defined in the closure
            Console.WriteLine("Closure output");
            Func<int> gen = GenerateRandom(0, 10);
            for (int i = 0;i<20;i++)
            {
                Console.Write($"{gen()} ");
            }
            Console.WriteLine();
            //2)
            //CashInCoins
            Console.WriteLine("CashInCoins output");
            CashInCoins defaultConstructor=new CashInCoins();
            Console.WriteLine("Default constructor: "+defaultConstructor.ToString());

            //define a CashInCoins object c1 with this coins { 2, 1, 0, 0, 1, 1, 1, 0 } using the suitable constructor
            IEnumerable<int> coins = new System.Collections.Generic.List<int>() { 2, 1, 0, 0, 1, 1, 1, 0 };
            CashInCoins c1= new CashInCoins(coins);
            Console.WriteLine(c1.ToString());

            //assign to c1 a CashInCoins object c1 with 5 € and 17 Cents using the suitable constructor
            c1 = new CashInCoins(5,17);
            Console.WriteLine(c1.ToString());

            //Define c2 CashInCoins object c2 with this coins{ 1, 4, 0, 0, 0, 1, 1, 1 }
            coins = new System.Collections.Generic.List<int>() { 1, 4, 0, 0, 0, 1, 1, 1 };
            CashInCoins c2 = new CashInCoins(coins);

            //Display c1 and c2
            Console.WriteLine(c1.ToString());
            Console.WriteLine(c2.ToString());

            //Display c1 and c2 Amount
            Console.WriteLine(c1.Amount);
            Console.WriteLine(c2.Amount);

            //Obtain a new CashInCoins object c3 with the same value in € and Cents as c2 with the minimum number of coins
            CashInCoins c3 = c2.MinimumCoins();

            //Display c3 and c3 Amount
            Console.WriteLine(c3.ToString());
            Console.WriteLine(c3.Amount);

            //Obtain a new CashInCoins object c4 with the Merge of c1 and c2
            CashInCoins c4 = c1.Merge(c2);

            //Display c4
            Console.WriteLine(c4.ToString());

            //3)
            //Show the linq queries results
            Console.WriteLine("LINQ output");

            //3.a)

            //3.b)

            //var h1 = model.Employees.Select((e) => new { Province=e.Province, Office=e.Office }).GroupBy((e)=>e.Province);
            ////IEnumerable<<IGrouping<string, new{string,Office}>
            //IDictionary<String, int> dic= new Dictionary<String, int>();
            //Func<IDictionary<String, int>, IGrouping<String,int>, IDictionary<String, int>> f = (d,province)=>
            //{
            //    d.Add(province.Key,province.Count());
            //    return d;
            //};
            //var h2 = h1.Aggregate(dic, f);

            

            //foreach (var item in h1)
            //{
            //    Console.WriteLine(item.Key);
            //    int count = item.Count();
            //    Console.WriteLine(count);
            //    foreach(var i in item)
            //    {

            //    }
            //}

            //4) Show the symmetric difference for  { 1, 2, 3, 4, 5 } and { 4, 5,6,7 }
            Console.WriteLine("Symmetric difference output");
            LinkedList.List<int> a = new LinkedList.List<int>() { 1, 2, 3, 4, 5 };
            LinkedList.List<int> b = new LinkedList.List<int>() { 4, 5, 6, 7 };
            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());

            Console.WriteLine(a.SymmetricDifference(b));

            //do the same with {‘a’, ’b’, ’c’, ’d’}, {‘b’, ’c’, ’d’, ’e’}.
            LinkedList.List<char> c = new LinkedList.List<char>() {'a', 'b', 'c', 'd'};
            LinkedList.List<char> d = new LinkedList.List<char>() { 'b', 'c', 'd','e'};
            Console.WriteLine(c.ToString());
            Console.WriteLine(d.ToString());

            Console.WriteLine(c.SymmetricDifference(d));

        }

        private static Func<int> GenerateRandom(int min, int max)
        {
            Random rnd=new Random();
            int Min = min;
            
            return () =>
            {
                int number = rnd.Next(Min, max);
                Min = number;
                if (number == max - 1)
                    Min = min;
                return number;
            };
        }

        private static LinkedList.List<T> SymmetricDifference<T>(this LinkedList.List<T> l, LinkedList.List<T> g)
        {
            LinkedList.List<T> notInG = l.Filter((x)=>!g.Contains(x));
            LinkedList.List<T> notInL = g.Filter((x) => !l.Contains(x));

            IEnumerator<T> iterator = notInL.GetEnumerator();
            while (iterator.MoveNext())
            {
                notInG.Add(iterator.Current);
            }
            LinkedList.List<T> result =notInG;
            return result;
        }

        public class CashInCoins
        {
            LinkedList.List<int> faceValue = new LinkedList.List<int>(); //in cents: 200, 100, 50, 20,10,5,2,1
            private void InitializeFaceValue()
            {
                faceValue.Add(200); faceValue.Add(100); faceValue.Add(50); faceValue.Add(20); faceValue.Add(10); faceValue.Add(5); faceValue.Add(2); faceValue.Add(1);
            }
            LinkedList.List<int> numberOfCoins = new LinkedList.List<int>();

            public CashInCoins() //Default constructor, assigns zero to the number of coins fo each value
            {
                InitializeFaceValue();
                for (int i = 0; i< faceValue.NumberOfElements; i++)
                {
                    numberOfCoins.Add(0);
                }
            }

            public CashInCoins(IEnumerable<int> number)
            {
                InitializeFaceValue();
                if (number == null)
                    throw new ArgumentException("Null number of coins");
                if(number.Count()!= faceValue.NumberOfElements)
                {
                    throw new ArgumentException("Invalid size number of coins");
                }

                for (int i = 0; i < faceValue.NumberOfElements; i++)
                {
                    if (number.ElementAt(i) < 0)
                    {
                        throw new ArgumentException("Negative number of coins");
                    }
                    numberOfCoins.Add(number.ElementAt(i));
                }
            }


            public CashInCoins(int numberEuros, int numberCents)
            {
                InitializeFaceValue();
                if(numberEuros < 0|| numberCents < 0) throw new ArgumentException("Negative number of euros or cents");

                numberOfCoins.Add(numberEuros / 2);
                numberOfCoins.Add(numberEuros % 2);

                for (int i=0+2; i < 6+2; i++)
                {
                    numberOfCoins.Add(numberCents/ faceValue.ElementAt(i));
                    numberCents = numberCents % faceValue.ElementAt(i);
                }

            }

            public override string ToString()
            {
                String result = "";
                foreach (int number in numberOfCoins)
                { 
                        result += "(" + number + ")" + ","; 
                }
                return result;
            }

            public double Amount
            {
                get { 
                    double result = 0;
                    result+=2*numberOfCoins.ElementAt(0);
                    result += numberOfCoins.ElementAt(1);

                    for (int i = 0 + 2; i < numberOfCoins.NumberOfElements; i++)
                    {
                        double total = faceValue.ElementAt(i) * numberOfCoins.ElementAt(i);
                        result += total/100;
                    }
                    return Math.Round(result,2);
                }
            }

            public CashInCoins MinimumCoins()
            {
                int euros = (int)Math.Round(Amount, 0);
                double left= Amount - euros;
                int cents = (int)(left * 100);
                return new CashInCoins(euros,cents);
            }

            public CashInCoins Merge(CashInCoins c)
            {
                System.Collections.Generic.IList<int> result = new System.Collections.Generic.List<int>();
                foreach(var pair in numberOfCoins.Zip(c.numberOfCoins)) {
                    result.Add(pair.First + pair.Second);
                }
                return new CashInCoins(result);
            }
        }
    }
}
