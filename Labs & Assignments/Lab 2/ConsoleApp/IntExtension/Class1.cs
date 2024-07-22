using System;

namespace TPP.Lab02
{
    public static class IntExtension
    {
        public static int Reverse(this int x) {
            int r = 0;
            while (x > 0)
            {
                r=r*10 + x%10;
                x = x / 10;
            }
            return r;
        }

        public static Boolean IsPrime(this int x)
        {
            for (int i=2; i<x-1;i++)
            {
                if (x%i==0)
                    return false;
            }
            return true;
        }

        public static int GCD(this int x, int y)
        {
            if (y==0) return x;
            return GCD(y, y%x);
        }
    }
}
