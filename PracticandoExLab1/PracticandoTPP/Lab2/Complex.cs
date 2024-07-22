using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Complex
    {
        public double Real {get;set;} //Real part of a complex number
        public double Imaginary {get;set; } //Real part of a complex number

        public Complex(double re, double im) 
        {
            Real = re;
            Imaginary=im;
        }

        public double Module() //Calculates the module of this complex number
        {
            return Math.Sqrt(Real*Real + Imaginary*Imaginary);
        }

        public Complex Conjugate() //Calculates the conjugate of this complex number
        {
            return new Complex(Real, -Imaginary);
        }

        public static Complex operator +(Complex a, Complex b) //Adds two complex numbers: a+b
        {
            return new Complex(a.Real+b.Real,a.Imaginary+b.Imaginary);
        }

        public static Complex operator *(Complex a, Complex b) //Multiplies two complex numbers: a*b
        {
            double re = a.Real * b.Real - a.Imaginary * b.Imaginary;
            double im = a.Real * b.Imaginary + a.Imaginary * b.Real;
            return new Complex(re,im);
        }
    }
}
