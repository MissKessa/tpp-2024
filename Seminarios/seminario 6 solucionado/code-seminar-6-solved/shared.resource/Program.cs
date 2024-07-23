using System.Threading;

namespace TPP.Seminars.Concurrency.Seminar6
{

    class Program
    {


        public static void Main() {
            Resource resource1 = new Resource("Resource 1"),
                    resource2 = new Resource("Resource 2");
            Worker worker1 = new Worker(resource1, resource2),
                 worker2 = new Worker(resource2, resource1);
            new Thread(worker1.Execute).Start();
            new Thread(worker2.Execute).Start();
        }

    }
}
