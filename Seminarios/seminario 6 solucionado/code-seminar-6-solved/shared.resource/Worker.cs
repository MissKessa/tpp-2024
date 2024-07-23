
namespace TPP.Seminars.Concurrency.Seminar6
{

    /// <summary>
    /// Encapsulates a worker thread
    /// </summary>
    public class Worker {

        public Resource Resource1 { get; private set; }
        public Resource Resource2 { get; private set; }


        public Worker(Resource resource1, Resource resource2) {
            this.Resource1 = resource1;
            this.Resource2 = resource2;
        }

        /// <summary>
        /// This method will be cocurrently executed
        /// </summary>
        public void Execute() {
              Resource1.Process();
              Resource2.Process();
        }


    }
}
