using System;
using System.Threading;
using System.Text;

namespace TPP.Laboratory.Concurrency.Lab09 {

    class ThreadDemo {

        static void Main(string[] args) { //there is no synchronization, so the output will be random
            //threads(1);
            //threads(2);
            //threads(3);
        }

        static void threads1()
        {
            /*
         * 
         -Thread 1, ThreadID 1.
-Thread 1, ThreadID 1.
-Thread 1, ThreadID 1.
        */
            int numberOfThreads = Convert.ToInt32(0);
            MessageThread[] obj = new MessageThread[numberOfThreads];
            for (int i = 0; i < numberOfThreads; i++)
                new Thread(new MessageThread().Run).Start();
            new MessageThread().Run();
        }

        static void threads2()
        {
            /*
         * 
         -Thread 1, ThreadID 4.
--Thread 2, ThreadID 1.
-Thread 1, ThreadID 4.
--Thread 2, ThreadID 1.
-Thread 1, ThreadID 4.
--Thread 2, ThreadID 1.
--Thread 2, ThreadID 1.
-Thread 1, ThreadID 4.
--Thread 2, ThreadID 1.
-Thread 1, ThreadID 4
        */
            int numberOfThreads = Convert.ToInt32(1);
            MessageThread[] obj = new MessageThread[numberOfThreads];
            for (int i = 0; i < numberOfThreads; i++)
                new Thread(new MessageThread().Run).Start();
            new MessageThread().Run();
        }

        static void threads3()
        {
            /*
         * -Thread 1, ThreadID 4.
--Thread 2, ThreadID 5.
---Thread 3, ThreadID 1.
-Thread 1, ThreadID 4.
---Thread 3, ThreadID 1.
--Thread 2, ThreadID 5.
-Thread 1, ThreadID 4.
--Thread 2, ThreadID 5.
---Thread 3, ThreadID 1.
---Thread 3, ThreadID 1.*/
            int numberOfThreads = Convert.ToInt32(2);
            MessageThread[] obj = new MessageThread[numberOfThreads];
            for (int i = 0; i < numberOfThreads; i++)
                new Thread(new MessageThread().Run).Start();
            new MessageThread().Run();
        }


        
    }
}
