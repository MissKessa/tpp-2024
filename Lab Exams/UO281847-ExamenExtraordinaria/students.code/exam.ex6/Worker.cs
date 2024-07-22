using System.Collections.Generic;

namespace exam.ex6
{
    internal class Worker<T>
    {
        private T[] array;

        private int from;

        private int to;

        public Dictionary<T, IEnumerable<int>> Dict;

        public Worker(T[] array, int v1, int v2)
        {
            this.array = array;
            this.from = v1;
            this.to = v2;
        }

        public void ComputeDict()
        {
            var positions = new List<int>();
            var dictionary = new Dictionary<T, IEnumerable<int>>();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i].Equals(array[j]))
                    {
                        positions.Add(j);
                    }                    
                }
                if (!dictionary.ContainsKey(array[i]))
                {
                    dictionary.Add(array[i], positions);
                }                 
                positions = new List<int>();
            }
            Dict = dictionary;
        }
    }
}