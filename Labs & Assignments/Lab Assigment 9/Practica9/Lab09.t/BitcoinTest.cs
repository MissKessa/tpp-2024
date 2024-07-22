using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab09;

namespace Lab09
{
    [TestClass]
    public class BitcoinTest
    {

        /// <summary>
        /// The vector used to test the implementation
        /// </summary>
        private BitcoinValueData[] data;
        private int result = 2826;

        [TestInitialize]
        public void Initialize()
        {
            this.data = Utils.GetBitcoinData();
        }

        [TestMethod]
        public void SingleThreadTest()
        {
            Master master = new Master(data, 7000, 1);
            Assert.AreEqual(result, master.ComputeBitcoinValueOver());
        }

        [TestMethod]
        public void TenThreadTest()
        {
            Master master = new Master(data, 7000, 10);
            Assert.AreEqual(result, master.ComputeBitcoinValueOver());
        }

        [TestMethod]
        public void MaxNumberOfThreadsTest()
        {
            Master master = new Master(data, 7000, 50);
            Assert.AreEqual(result, master.ComputeBitcoinValueOver());
        }
    }
}
