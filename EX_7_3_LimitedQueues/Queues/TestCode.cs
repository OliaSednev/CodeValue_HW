using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    class TestCode
    {
        public void TestingCode()
        {
            LimitedQueue<int> queue = new LimitedQueue<int>(10);
            for (int i = 1; i <= 10; i++)
            {
                var item = i;
                Task.Run(() =>
                {
                    queue.Enque(item);
                    Console.WriteLine($"Added {item} to queue");
                    Console.WriteLine($"Count is: {queue.Count}");
                });

                Task.Run(async () =>
                {
                    try
                    {
                        await Task.Delay(500);
                        var dequeueItem = queue.Deque();
                        Console.WriteLine($"removed {dequeueItem} from queue");

                        Console.WriteLine($"Count is: {queue.Count}");
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                });
            }
        }
    }
}
