using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab6
{
    public static class Curried
    {
        //EXAMPLES:
        private static Func<int, int> CurriedAdd(int a) //Partial application: CurriedAdd(3)(1)
        {
            return b => a + b;
        }

        private static Predicate<int> GreaterThan(int a) //Predicate<int> isNegative = GreaterThan(0);
        {
            return b => a > b;
        }

        public static bool ContainsDivisor(IEnumerable<int> nums, int n)
        {
            foreach(var e in nums)
            {
                if (n % e == 0) return true;
            }
            return false;
        }

        static int MultiplyThree(int a, int b, int c) //MultiplyThree(2,3,4)
        {
            return a * b * c;
        }

        static Func<int,int> CurriedMultiplyThree(int a, int b) //MultiplyThree(2,3)(4)
        {
            return c=> a * b * c;
        }

        static Func<int, Func<int,int>> CurriedCurriedMultiplyThree(int a, int b) //MultiplyThree(2)(3)(4)
        {
            return b=>c => a * b * c;
        }

        //Curried version: Returns a predicate that tells if the parameter is divisible by at leats one of the int in the Ienumerable
        public static Predicate<int> ContainsDivisor(IEnumerable<int> e) 
        {
            return (x) =>
            {
                foreach (var item in e)
                {
                    if (x % item == 0) return true;
                }
                return false;
            };
        }

        public static void Exercise1()
        {
            IEnumerable<int> l = new List<int>() { 2, 3, 5 };
            Predicate<int> f = ContainsDivisor(l);
            Console.WriteLine(f(10)); //True, divisible by 2 and by 5
            Console.WriteLine(f(11)); //False, not divisible by 2, 3 or 5
        }
    }
    
}
