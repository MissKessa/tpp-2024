using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    public static class IntegerExtension //Creating methods for integers by having as parameter *this* int ...
    {
        /**
         * Returns the number reversed
         */
        public static int Reverse(this int number)
        {
            IList<int> list = new List<int>();
            int cocient = number;
            int i = 0;
            do
            {
                list.Add(cocient % 10);
                cocient= cocient / 10;
                i++;
            } while (cocient > 0);

            int reversed = 0;
            for (int j = 0; j<list.Count(); j++)
            {
                reversed += list[j] * (int)Math.Pow(10,list.Count()-j-1);
            }
            return reversed;
        }

        /**
         * 
         * Returns if the number is Prime
         * */
        public static Boolean IsPrime(this int number)
        {
            for (int i=2; i<number/2+1; i++) {
                if(number%i==0) return false;
            }
            return true;
        }

        /*
         * Calculates the greates common divisor: 
         */
        public static int GCD(this int a, int b)
        {
            if (b==0) return a;
            return GCD(b, a % b);
        }

        /*
         * Calculates the least common multiple
         * */
        public static int LCM(this int a, int b)
        {
            return Math.Abs(a * b)/a.GCD(b);
        }

        /**
         * Concatenates 2 numbers
         */
        public static int Concatenate(this int number, int numberLastPart)
        {
            Boolean numberNegative = number < 0;
            if (numberNegative) number *= -1;
            IList<int> listNumber = new List<int>();
            int cocient = number;
            int i = 0;
            do
            {
                listNumber.Add(cocient % 10);
                cocient = cocient / 10;
                i++;
            } while (cocient > 0);

            IEnumerable<int> l= listNumber.Reverse();

            IList<int> listNumberLastPart = new List<int>();
            if (numberLastPart<0) number *= -1;
            cocient = numberLastPart;
            i = 0;
            do
            {
                listNumberLastPart.Add(cocient % 10);
                cocient = cocient / 10;
                i++;
            } while (cocient > 0);

            IEnumerable<int> q = listNumberLastPart.Reverse();

            l = l.Concat(q);

            int concatenated = 0;
            for (int j = 0; j < l.Count(); j++)
            {
                concatenated += l.ElementAt(j) * (int)Math.Pow(10, l.Count() - j - 1);
            }
            if (numberNegative) concatenated *= -1;
            return concatenated;
        }
    }
}
