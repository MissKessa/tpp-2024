using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//change if needed:
//using ComplexNumbers;
using Lab2;
using System.Numerics;

namespace ComplexNumbers.Test
{
    [TestClass]
    public class TestComplejos
    {
        [TestMethod]
        public void ModuleTest()
        {
            Lab2.Complex a = new Lab2.Complex(1.0, 1.0);
            Assert.AreEqual(Math.Sqrt(2.0), a.Module()); //we can have rounding errors
            Assert.AreEqual(Math.Abs(Math.Sqrt(2.0) - a.Module()) < 0.0001, true);
        }
        [TestMethod]
        public void ConjugateTest()
        {
            Lab2.Complex a = new Lab2.Complex(1.0, 1.0),
                     valorEsperado = new Lab2.Complex(1.0, -1.0),
                     valorObtenido;
            valorObtenido = a.Conjugate();
            Assert.AreEqual(valorEsperado.Real, a.Conjugate().Real);
            Assert.AreEqual(valorEsperado.Imaginary, a.Conjugate().Imaginary);
        }
        [TestMethod]
        public void AdditionTest()
        {
            Lab2.Complex a = new Lab2.Complex(1.0, 1.0),
                     b = new Lab2.Complex(2.0, 3.0),
                     desiredValue = new Lab2.Complex(3.0, 4.0),
                     obtainedValue;
            obtainedValue = a + b;
            Assert.AreEqual(desiredValue.Real, obtainedValue.Real);
            Assert.AreEqual(desiredValue.Imaginary, obtainedValue.Imaginary);
        }
        //Add a test for * representing two complex numbers product
        [TestMethod]
        public void ProductTest()
        {
            Lab2.Complex a = new Lab2.Complex(1.0, 1.0),
                     b = new Lab2.Complex(2.0, 3.0),
                     desiredValue = new Lab2.Complex(-1.0, 5.0),
                     obtainedValue;
            obtainedValue = a * b;
            Assert.AreEqual(desiredValue.Real, obtainedValue.Real);
            Assert.AreEqual(desiredValue.Imaginary, obtainedValue.Imaginary);
        }
    }
}
