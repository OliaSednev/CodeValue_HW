﻿using System;
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
            for (int i = 1; i <= 20; i++)
            {
                var number = i;

                Task.Run(async () =>
                {
                    queue.Enque(number);
                    Console.WriteLine($"Added to queue: {number} .");

                    await Task.Delay(2000);
                    var dequeNumber = queue.Deque();
                    Console.WriteLine($"Removed from queue: {dequeNumber} .");
                });
            }
        }
    }
}
