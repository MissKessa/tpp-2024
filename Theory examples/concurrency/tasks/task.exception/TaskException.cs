using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task.exception
{
    class TaskException
    {
        static void CaptureException()
        {
            var task = Task.Run(() => { throw new Exception("hola mundo"); });
            try
            {
                task.Wait();
            }
            catch (AggregateException e)
            {
                //Console.WriteLine("Task throwed the following exception: " + e);
                Console.WriteLine("Hubo un error");
            }
            return;
        }

        static void ReThrowException()
        {
            try
            {
                var task = Task.Run(() => { throw new ArgumentNullException(); });
                task.Wait();
            }
            catch (AggregateException e)
            {
                Exception[] list = new Exception[] { e };
                throw new AggregateException("Exception rethrown as AggregateException", list);
            }
            return;
        }
        static void Main(string[] args)
        {
            //CaptureException();

            //try
            //{
            //    ReThrowException();
            //}
            //catch (AggregateException e)
            //{
            //    Console.WriteLine("Task throwed the following exception: " + e);
            //}
            ReThrowException();
            return;
        }

        static void NoCatchedException()
        {
            var task = Task.Run(() => { throw new ArgumentNullException(); });
            task.Wait();
          
            return;
        }
    }
}
