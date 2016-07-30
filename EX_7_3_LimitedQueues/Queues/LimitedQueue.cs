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
        private object _lock =new object();
        private ReaderWriterLockSlim writerLock = new ReaderWriterLockSlim();

        public LimitedQueue(int maxQueueSize)
        {
            semaphore = new SemaphoreSlim(maxQueueSize);
        }

        public void Enque(T obj)
        {
            semaphore.Wait();
            writerLock.EnterWriteLock();
            queue.Enqueue(obj);
            writerLock.ExitWriteLock();
        }

        public T Deque()
        {
            T value;
            lock (_lock)
            {
                value = queue.Dequeue();
                semaphore.Release();
            }
            return value;
        }

        public int Count => queue.Count;
    }
}
