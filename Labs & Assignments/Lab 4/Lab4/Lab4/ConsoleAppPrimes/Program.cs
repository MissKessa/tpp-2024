using System;
using System.Collections.Generic;
using System.IO;

namespace TPP.ObjectOrientation.Generics {

    class Program {

        static public void ShowWithForEach<T>(IEnumerable<T> enumerable,TextWriter output) {
            output.Write("[ ");
            foreach (T item in enumerable) //most of the times you can use this, but if not yo can use the while (below)
                output.Write("{0} ",item);
            output.WriteLine("]");
        }

        static public void ShowWithEnumerator<T>(IEnumerable<T> enumerable, TextWriter output) {
            IEnumerator<T> iterador = enumerable.GetEnumerator(); // or var = enumerable.GetEnumerator();
            output.Write("[ ");
            while (iterador.MoveNext()) //MoveNext returns true if there are more elements in the IEnumerable
                output.Write("{0} ", iterador.Current); //Returns the current value of the IEnumerable
            output.WriteLine("]");
        }

        static public void Main() {
            string[] array = { "How", "are", "you", "doing", "?" };
            ShowWithForEach(array, Console.Out);
            ShowWithEnumerator(array, Console.Out);

            Primes fibonacci = new Primes(10);
            ShowWithForEach(fibonacci, Console.Out);
            ShowWithEnumerator(fibonacci, Console.Out);
        }
    }
}
