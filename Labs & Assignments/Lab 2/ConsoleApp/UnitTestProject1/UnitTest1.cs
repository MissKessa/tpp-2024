using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//change if needed:
using ComplexNumbers;

namespace ComplexNumbers.Test
{
    [TestClass]
    public class TestComplejos
    {
        [TestMethod]
        public void ModuleTest()
        {
            Complex a = new Complex(1.0, 1.0);
            Assert.AreEqual(Math.Sqrt(2.0), a.Module()); //we can have rounding errors
            Assert.AreEqual(Math.Abs(Math.Sqrt(2.0) - a.Module()) < 0.0001, true);
        }
        [TestMethod]
        public void ConjugateTest()
        {
            Complex a = new Complex(1.0, 1.0),
                     valorEsperado = new Complex(1.0, -1.0),
                     valorObtenido;
            valorObtenido = a.Conjugate();
            Assert.AreEqual(valorEsperado.R, a.Conjugate().R);
            Assert.AreEqual(valorEsperado.I, a.Conjugate().I);
        }
        [TestMethod]
        public void AdditionTest()
        {
            Complex a = new Complex(1.0, 1.0),
                     b = new Complex(2.0, 3.0),
                     desiredValue = new Complex(3.0, 4.0),
                     obtainedValue;
            obtainedValue = a + b;
            Assert.AreEqual(desiredValue.R, obtainedValue.R);
            Assert.AreEqual(desiredValue.I, obtainedValue.I);
        }
        //Add a test for * representing two complex numbers product
        [TestMethod]
        public void ProductTest()
        {
            Complex a = new Complex(1.0, 1.0),
                     b = new Complex(2.0, 3.0),
                     desiredValue = new Complex(-1.0, 5.0),
                     obtainedValue;
            obtainedValue = a * b;
            Assert.AreEqual(desiredValue.R, obtainedValue.R);
            Assert.AreEqual(desiredValue.I, obtainedValue.I);
        }
    }
}
