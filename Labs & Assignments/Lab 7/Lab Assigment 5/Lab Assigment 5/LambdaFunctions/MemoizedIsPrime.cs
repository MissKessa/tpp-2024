using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP.Functional.Continuations
{
    public class MemoizedIsPrime
    {
        /// <summary>
        /// Memoized values
        /// </summary>
        private static IDictionary<int, bool> values = new Dictionary<int, bool>();

        /// <summary>
        /// Memoized recursive IsPrime function
        /// </summary>
        //public static int IsPrime(int n)
        //{
        //    if (values.Keys.Contains(n))
        //        // * If it is the cache (in the dictionary), we return its value
        //        return values[n];
        //    // * Otherwise, we save it before returning it
        //    int prevPrime = IsPrime(n - 1);
        //    int prime = prevPrime;
        //    for (int i = prevPrime+1; i< prevPrime*2; i++)
        //    {
        //        bool isprime = true;
        //        for(int j=0; j<values.Count;j++)
        //        {
        //            if (i % values[j] == 0)
        //            {
        //                isprime = false;
        //                break;
        //            }
        //        }
        //        if (isprime) {
        //            prime = i;
        //            break; ;
        //        }
        //    }
        //    values.Add(n, prime);
        //    return prime;
        //}
        private static bool PrivateIsPrime(int n)
        {
            if (n<2) return false;  
            for (int i=2; i*i<=n; i++)
            {
                if (n%i==0) return false;
            }
            return true;
        }

        public static bool IsPrime(int n)
        {
            if (values.Keys.Contains(n))
                return values[n];

            bool value= PrivateIsPrime(n);
            values.Add(n, value);
            return value;
        }

        public static Func<bool> IsPrimeMemoizedClousure()
        {
            int prime = 0;
            return () =>
            {
                bool value = IsPrime(prime);
                prime++;
                return value;
            };
        }
            
    }
}
