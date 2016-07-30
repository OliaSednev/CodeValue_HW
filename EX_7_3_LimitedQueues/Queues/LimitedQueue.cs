using System;
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
        private ReaderWriterLockSlim writerLock = new ReaderWriterLockSlim();

        public LimitedQueue(int maxQueueSize)
        {
            semaphore = new SemaphoreSlim(maxQueueSize);
        }

        public void Enque(T value)
        {
            semaphore.Wait();
            try
            {
                writerLock.TryEnterWriteLock(-1);               
                queue.Enqueue(value);
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
                semaphore.Release();
                return queue.Dequeue();
            }
            finally
            {
                writerLock.ExitWriteLock();
            }
        }
    }
}
