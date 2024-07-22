using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Exam 
{
    //Modify, refactor, use suitable names
    static class MemoizedClass {
        private static IDictionary<int, int> values = new Dictionary<int, int>();
        internal static int Fibonacci(int n) {
            if (values.Keys.Contains(n))
                return values[n];
            int value =  n <= 2 ? 1 : Fibonacci(n - 2) + Fibonacci(n - 1);
            values.Add(n, value);
            return value;
        }
    }
}
