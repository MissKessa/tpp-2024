using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaxValueApp
{
    internal class MaxValue
    {
        //the attribute
        int value;
        //a random number generator to complicate things
        Random r = new Random();
        ReaderWriterLockSlim CacheLock = new ReaderWriterLockSlim();
        public MaxValue(int value)
        {
            this.value = value;
        }
        public int Value
        {
            get
            {
                CacheLock.EnterReadLock();
                try
                {
                    return value;
                }
                finally
                {
                    CacheLock.ExitReadLock();
                }
            }
            set
            {
                CacheLock.EnterUpgradeableReadLock();
                try
                {
                    if (value > this.value) //only updated if value is > this.value
                    {
                        Thread.Sleep(r.Next(50)); //to make things worse
                        CacheLock.EnterWriteLock();
                        //just to complicate things
                        try
                        {
                            
                            this.value = value;
                        }
                        finally
                        {
                            CacheLock.ExitWriteLock();
                        }
                    }
                }
                finally
                {
                    CacheLock.ExitUpgradeableReadLock();
                }
            }
        }
    }
}
