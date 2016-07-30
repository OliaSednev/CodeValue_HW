﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class LimitedQueue<T>
    {
        private Queue<T> queue = new Queue<T>();
        private SemaphoreSlim semaphore;
        private object _lock = new object();
        private ReaderWriterLockSlim writerLock = new ReaderWriterLockSlim();

        public LimitedQueue(int maxQueueSize)
        {
            semaphore = new SemaphoreSlim(maxQueueSize);
        }

        public void Enque(T obj)
        {

            try
            {
                semaphore.Wait();
                writerLock.TryEnterWriteLock(-1);
                //writerLock.EnterWriteLock();
                queue.Enqueue(obj);
            }
            finally
            {
                writerLock.ExitWriteLock();
            }
        }

        public T Deque()
        {
            try
            {
                writerLock.TryEnterWriteLock(-1);
                //writerLock.EnterWriteLock();
                var obj = queue.Dequeue();
                semaphore.Release();
                return obj;
            }
            finally
            {
                writerLock.ExitWriteLock();
            }
        }


    }
}