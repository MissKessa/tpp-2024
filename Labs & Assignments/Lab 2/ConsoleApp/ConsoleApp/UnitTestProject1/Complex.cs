using System;
using System.Runtime.Remoting.Proxies;

namespace ComplexNumbers.Test
{
    public class Complex
    {
        private double re; //real part
        private double im; //imaginary part

        public Complex(double v1, double v2)
        {
            this.re = v1;
            this.im = v2;
        }

        public double Module()
        {
            return Math.Sqrt(re*re+im*im);
        }

        internal Complex Conjugate()
        {
            return new Complex(re,-im);
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.re+b.re, a.im+b.im);
        }

        public double R
        {
            get
            {
                return re;
            }
            set
            {
                re = value;
            }
        }

        public double I
        {
            get
            {
                return im;
            }
            set
            {
                im = value;
            }
        }

        public static Complex operator *(Complex a, Complex b)
        {
            double real = a.R * b.R - a.I * b.I;
            double imaginary = a.R * b.R + a.I * b.I;
            Complex result = new Complex(real, imaginary);
            return result;
        }


    }
}