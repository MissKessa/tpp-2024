using System;
using System.Threading;

namespace TPP.Seminars.Concurrency.Seminar6
{

    /// <summary>
    /// Each dining philosopher
    /// </summary>
    class Philosopher
    {
        /// <summary>
        /// Philosopher ID
        /// </summary>
        private int number;

        /// <summary>
        /// Elapsed thinking milliseconds
        /// </summary>
        private int thinkingMillis;

        /// <summary>
        /// Elapsed eating milliseconds
        /// </summary>
        private int eatingMillis;

        /// <summary>
        /// Right and left fork IDs
        /// </summary>
        private int leftFork, rightFork;

        private static Forks forks = new Forks();

        public Philosopher(int philosopherNumber, int thinkingMillis, int eatingMillis, int leftFork, int rightFork) {
            this.number = philosopherNumber;
            this.thinkingMillis = thinkingMillis; this.eatingMillis = eatingMillis;
            this.leftFork = leftFork;
            this.rightFork = rightFork;

            new Thread(new ThreadStart(EatAndThink)).Start();
        }

        private void EatAndThink() {
            for (;;)
            {
                if (forks.GetForks(leftFork, rightFork))
                {
                    Console.WriteLine("The {0} philosopher is eating...", this.number);
                    Thread.Sleep(eatingMillis);
                    forks.ReleaseForks(leftFork, rightFork);
                }

                Console.WriteLine("The {0} philosopher is thinking...", this.number);
                Thread.Sleep(thinkingMillis);
            }

        }
    }
}
