using System.Threading;

namespace TPP.Seminars.Concurrency.Seminar6
{
    /// <summary>
    /// Represents a resource shared by multiple threads
    /// </summary>
    public class Resource
    {

        public string Name { get; private set; }
        private object monitor = new object();

        public Resource(string name) {
            this.Name = name;
        }

        public void Process() {
            lock (monitor)
            {
                Thread.Sleep(100); // simulates processing...
            }
        }

    }
}
