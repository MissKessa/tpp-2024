using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPP.Lab12.Primos
{
    //Algoritmo basado en la Criba de Eratóstenes
    public class PrimosMultihilo
    {
        private IList<int> primos = new List<int>();
        private HashSet<int> threadIds = new HashSet<int>();
        public int N { get; }

        public PrimosMultihilo() //object that uses internal list
        {
            N = 100000;
            //Todos los numeros son potencialmente primos
            for (int i = 2; i < N; i++)
                primos.Add(i); //add all nums
            this.EliminarNoPrimos(); //eliminate not prime nums
        }

        internal virtual void EliminarNoPrimos()
        {
            Thread[] hilos = new Thread[this.N - 2];
            //he said this are way to many threads
            //so runtime performance is not as good as expected
            //as such, we reduce the from this.N-2 to another num

            //You can also use Parallel.ForEach or parallel.For in everything
            //It is parallel TPL for everything but it is not perfect because
            //it does not make sense to, in the Add of the constructor, add a single
            //element in 600000 different threads.

            //Can you add elements to primos in parallel? Yes but you need to lock in 20
            //threads at the same time and it is really inefficient because it is a really small operation
            //and it'll be better to do a bigger operation for that

            //This is about analysing the code and see what makes sense and what does not

            //It makes a little bit more sense to do this in a parallel for because I do not one to create
            //thousands of threads and TPL considers the cpu characteristics to do an optimal number of
            //threads to do it as nice as possible

            //In the cribar method he missed the lock because he wanted us to identify this issue

            //His approach:
            //Adds many nums to a data structure and in parallel eliminates those who are not prime then
            //checks that the nums are all prime

            //We can follow both approaches -> do it our own way or identify his issues and fix it
            //it is very hard to identify the issues that produce a problem because it may work but it's
            //not ok (like not thread safe because of lack of synchronization methods)
            
            //MY THING:
            
            /*Parallel.ForEach(primos, (e) => { 
                Cribar(e);
            });*/

            /* PREVIOUS CODE OF THE EXERCISE
            
            for (int i = 2; i < this.N; i++)
                hilos[i - 2] = new Thread(() => this.Cribar(i));
            for (int i = 2; i < this.N; i++)
                hilos[i - 2].Start();
            //he said the join is missing

             */

            //the locks should be as narrow as possible

            //MY OTHER THING
            for (int i = 2; i < this.N; i++)
                hilos[i - 2] = new Thread(() => this.Cribar(i)); //if you lock primos here then only one thread at a time
            for (int i = 2; i < this.N; i++)
                hilos[i - 2].Start();
            //Falta el join
            //I think we could do it in a similar fashion to the Master-Worker project
            //but I want to do it with parallel but idk
        }

        internal void Cribar(int n)
        {
            /*PREVIOUS CODE HERE
             
            for (int i = n + n; i < N; i += n)
            {
                if (primos.Contains(i))
                {
                    primos.Remove(i);
                }
            }
             
             */

            //MY THING -> i did not do anything yet
            for (int i = n + n; i < N; i += n)
            {
                if (primos.Contains(i))
                {
                    primos.Remove(i);
                }
            }
        }

        public bool Primo(int position)
        {
            if ((position == 0) || (position == 1))
                return false;
            return primos.Contains(position);
        }
    }
}
