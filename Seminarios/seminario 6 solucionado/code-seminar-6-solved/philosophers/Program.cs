
namespace TPP.Seminars.Concurrency.Seminar6
{

    class Program
    {
        static void Main(string[] args)
        {
            const int thinkingMiliseconds = 0, EatingMiliseconds = 0;
            Fork[] fork = new Fork[5];
            for (int i = 0; i < fork.Length; i++)
                fork[i] = new Fork(i);

            new Philosopher(0, thinkingMiliseconds, EatingMiliseconds, 0, 1);
            new Philosopher(1, thinkingMiliseconds, EatingMiliseconds, 1, 2);
            new Philosopher(2, thinkingMiliseconds, EatingMiliseconds, 2, 3);
            new Philosopher(3, thinkingMiliseconds, EatingMiliseconds, 3, 4);
            new Philosopher(4, thinkingMiliseconds, EatingMiliseconds, 4, 0);
        }
    }
}
