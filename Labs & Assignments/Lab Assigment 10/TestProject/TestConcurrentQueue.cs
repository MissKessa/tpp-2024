using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentQueue.Tests
{
    [TestClass]
    public class TestConcurrentQueue
    {
        [TestMethod]
        public void Enqueue1Thread()
        {
            Concurrency.ConcurrentQueue<int> q = new Concurrency.ConcurrentQueue<int>();
            Thread[] threads = new Thread[1];
            for (int i = 0; i < threads.Length; i++)
            {
                int j = i;
                threads[i] = new Thread(
                    () => { q.Enqueue(j); }
                 );

                threads[i].Name = "Worker " + (i + 1);
                threads[i].Priority = ThreadPriority.BelowNormal;
                threads[i].Start();
            }

            foreach (var t in threads)
            {
                t.Join();
            }

            Assert.AreEqual(1, q.NumberOfElements);
            Assert.AreEqual(0, q.Peek());
            for(int i=0; i < q.NumberOfElements; i++)
            {
                Assert.AreEqual(i, q.GetElement(i));
            }
        }

        [TestMethod]
        public void Enqueue5Thread()
        {
            Concurrency.ConcurrentQueue<int> q = new Concurrency.ConcurrentQueue<int>();
            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; i++)
            {
                int j = i;
                threads[i] = new Thread(
                    () => { q.Enqueue(j); }
                 );

                threads[i].Name = "Worker " + (i + 1);
                threads[i].Priority = ThreadPriority.BelowNormal;
                threads[i].Start();
            }

            foreach (var t in threads)
            {
                t.Join();
            }

            Assert.AreEqual(5, q.NumberOfElements);
            Assert.AreEqual(0, q.Peek());
            for (int i = 0; i < q.NumberOfElements; i++)
            {
                Assert.AreEqual(i, q.GetElement(i));
            }
        }

        [TestMethod]
        public void Enqueue20Thread()
        {
            Concurrency.ConcurrentQueue<int> q = new Concurrency.ConcurrentQueue<int>();
            Thread[] threads = new Thread[20];
            for (int i = 0; i < threads.Length; i++)
            {
                int j = i;
                threads[i] = new Thread(
                    () => { q.Enqueue(j); }
                 );

                threads[i].Name = "Worker " + (i + 1);
                threads[i].Priority = ThreadPriority.BelowNormal;
                threads[i].Start();
            }

            foreach (var t in threads)
            {
                t.Join();
            }

            Assert.AreEqual(20, q.NumberOfElements);
            Assert.AreEqual(0, q.Peek());
            for (int i = 0; i < q.NumberOfElements; i++)
            {
                Assert.AreEqual(i, q.GetElement(i));
            }
        }

        [TestMethod]
        public void Dequeue1Thread()
        {
            Concurrency.ConcurrentQueue<int> q = new Concurrency.ConcurrentQueue<int>();
            for (int i=0; i < 20; i++)
            {
                q.Enqueue(i);
            }

            List<int> eliminated = new List<int>();
            Thread[] threads = new Thread[1];
            for (int i = 0; i < threads.Length; i++)
            {
                int j = i;
                threads[i] = new Thread(
                    () => { eliminated.Add(q.Dequeue()); }
                 );

                threads[i].Name = "Worker " + (i + 1);
                threads[i].Priority = ThreadPriority.BelowNormal;
                threads[i].Start();
            }

            foreach (var t in threads)
            {
                t.Join();
            }

            Assert.AreEqual(20-1, q.NumberOfElements);
            Assert.AreEqual(1, q.Peek());
            for (int i = 0; i < q.NumberOfElements; i++)
            {
                Assert.AreEqual(i+1, q.GetElement(i));
            }
            Assert.AreEqual(1, eliminated.Count);
            for (int i = 0; i < eliminated.Count; i++)
            {
                Assert.AreEqual(i, eliminated.ElementAt(i));
            }
        }

        [TestMethod]
        public void Dequeue5Thread()
        {
            Concurrency.ConcurrentQueue<int> q = new Concurrency.ConcurrentQueue<int>();
            for (int i = 0; i < 20; i++)
            {
                q.Enqueue(i);
            }

            List<int> eliminated = new List<int>();
            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; i++)
            {
                int j = i;
                threads[i] = new Thread(
                    () => { eliminated.Add(q.Dequeue()); }
                 );

                threads[i].Name = "Worker " + (i + 1);
                threads[i].Priority = ThreadPriority.BelowNormal;
                threads[i].Start();
            }

            foreach (var t in threads)
            {
                t.Join();
            }

            Assert.AreEqual(20 - 5, q.NumberOfElements);
            Assert.AreEqual(5, q.Peek());
            for (int i = 0; i < q.NumberOfElements; i++)
            {
                Assert.AreEqual(i + 5, q.GetElement(i));
            }
            Assert.AreEqual(5, eliminated.Count);
            for (int i = 0; i < eliminated.Count; i++)
            {
                Assert.AreEqual(i, eliminated.ElementAt(i));
            }
        }

        [TestMethod]
        public void Dequeue20Thread()
        {
            Concurrency.ConcurrentQueue<int> q = new Concurrency.ConcurrentQueue<int>();
            for (int i = 0; i < 20; i++)
            {
                q.Enqueue(i);
            }

            List<int> eliminated = new List<int>();
            Thread[] threads = new Thread[20];
            for (int i = 0; i < threads.Length; i++)
            {
                int j = i;
                threads[i] = new Thread(
                    () => { eliminated.Add(q.Dequeue()); }
                 );

                threads[i].Name = "Worker " + (i + 1);
                threads[i].Priority = ThreadPriority.BelowNormal;
                threads[i].Start();
            }

            foreach (var t in threads)
            {
                t.Join();
            }

            Assert.AreEqual(20 - 20, q.NumberOfElements);
            try
            {
                q.Peek();
                throw new InvalidOperationException("Should have thrown exception");
            } catch (IndexOutOfRangeException e)
            {

            }

            Assert.AreEqual(20, eliminated.Count);
            for (int i = 0; i < eliminated.Count; i++)
            {
                Assert.AreEqual(i, eliminated.ElementAt(i));
            }
        }

    }
}
