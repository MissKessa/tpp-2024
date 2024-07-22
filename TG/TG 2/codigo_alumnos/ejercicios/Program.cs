using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TPP.Lab12.Modelo;
using TPP.Lab12.Primos;

namespace TPP.Lab12
{
	class Program
	{
		static void Main(string[] args)
		{
            //Ejercicio1(); //I put this commented
            //Ejercicio2(); //and this one too
            Ejercicio3();
        }


		protected static void Ejercicio1()
		{


        }

		protected static void Ejercicio2()
		{
            //Consulta 1
            //Consulta 2
        }

        protected static void Ejercicio3()
		{
            //https://en.wikipedia.org/wiki/List_of_prime_numbers#The_first_1000_prime_numbers
            //Console.WriteLine("Exercise 3"); //-> añadido mío
            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            PrimosMultihilo p = new PrimosMultihilo();
            chrono.Stop();
            Console.WriteLine("Tiempo total: {0} milisegundos.", chrono.ElapsedMilliseconds);

            IList<int> primos = new List<int>();
            int current = 0;
            for (int i = 0; i < 100; i++)
            {
                while (!p.Primo(current))
                    current++;
                primos.Add(current);
                current++;
            }
            foreach(var i in primos)
                Console.Write("{0}\t", i);
            Console.WriteLine();
        }
	}
}

