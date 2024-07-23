namespace TPP.Seminars.Concurrency.Seminar6
{
    class Forks
    {
        /// <summary>
        /// Indicates if are busy (by default false, not used)
        /// </summary>
        private bool[] forks = new bool[5];

        /// <summary>
        /// Ask for a fork
        /// </summary>
        /// <param name="left">ID of the left-hand fork</param>
        /// <param name="right">ID of the right-hand fork</param>
        /// <returns>If the pair of forks is available or not</returns>
        public bool GetForks(int left, int right)
        {
            lock (this.forks)
            {
                if (!forks[left] && !forks[right])
                {
                    forks[left] = forks[right] = true;
                    return true;
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// Returns the forks
        /// </summary>
        /// <param name="left">ID of the left-hand fork</param>
        /// <param name="right">ID of the right-hand fork</param>
        public void ReleaseForks(int left, int right)
        {
            lock (this.forks)
            {
                forks[left] = forks[right] = false;
            }
        }
    }
}