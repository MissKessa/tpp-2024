using System;
using System.Threading;

namespace Concurrency
{
    /// <summary>
    /// Generic class that provides a thread safe queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConcurrentQueue<T>
    {
        ReaderWriterLockSlim CacheLock = new ReaderWriterLockSlim();
        LinkedList.List<T> l;
        /// <summary>
        /// Basic constructor that sets the queue empty
        /// </summary>
        public ConcurrentQueue() { l = new LinkedList.List<T>(); }

        /// <summary>
        /// Constructor that sets the value of the root to the given one
        /// </summary>
        /// <param name="value">The value for the root</param>
        public ConcurrentQueue(T value){ l = new LinkedList.List<T>(value); }

        /// <summary>
        /// Returns the number of elements of the queue
        /// </summary>
        public int NumberOfElements
        {
            get {
                CacheLock.EnterReadLock();
                try {
                    return l.NumberOfElements;
                }
                finally {
                    CacheLock.ExitReadLock();
                }
            }
        }

        /// <summary>
        /// Returns if the queue is empty
        /// </summary>
        public Boolean IsEmpty
        {
            get {
                CacheLock.EnterReadLock();
                try {
                    return NumberOfElements == 0;
                }
                finally {
                    CacheLock.ExitReadLock();
                }
            }
        }

        /// <summary>
        /// Adds the given value to the end of the queue
        /// </summary>
        /// <param name="value">The value to be added</param>
        /// <returns>true if it was added</returns>
        public Boolean Enqueue(T value)
        {
            CacheLock.EnterUpgradeableReadLock();
            try {
                CacheLock.EnterWriteLock();
                try {
                    return l.Add(value);
                }
                finally {
                    CacheLock.ExitWriteLock();
                }
            }
            finally {
                CacheLock.ExitUpgradeableReadLock();
            }
        }

        /// <summary>
        /// Removes the first element in the queue
        /// </summary>
        /// <returns>The removed element</returns>
        public T Dequeue()
        {
            CacheLock.EnterUpgradeableReadLock();
            try {
                    CacheLock.EnterWriteLock();
                try {
                    return l.RemoveFirst();
                }
                finally {
                    CacheLock.ExitWriteLock();
                }
            }
            finally {
                CacheLock.ExitUpgradeableReadLock();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The first element of the queue without removing it</returns>
        public T Peek()
        {
            CacheLock.EnterReadLock();
            try {
                return l.GetElement(0);
            } catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("The queue is empty");
            }
            finally {
                CacheLock.ExitReadLock();
            }
        }

        public T GetElement(int index)
        {
            CacheLock.EnterReadLock();
            try
            {
                return l.GetElement(index);
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("The queue is empty");
            }
            finally
            {
                CacheLock.ExitReadLock();
            }
        }
        
    }
}
