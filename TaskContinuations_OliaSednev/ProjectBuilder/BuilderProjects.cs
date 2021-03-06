﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    class BuilderProjects
    {
        public void Builder(int numProject)
        {
            Console.WriteLine($"Please wait, Building project number: {numProject}");
            Thread.Sleep(1000);
        }
        public void Sequentially()
        {
            Task task_1 = Task.Factory.StartNew(() => Builder(1));
            Task task_2 = task_1.ContinueWith(project => Builder(2));
            Task task_3 = task_2.ContinueWith(project => Builder(3));
            Task task_4 = task_3.ContinueWith(project => Builder(4));
            Task task_5 = task_4.ContinueWith(project => Builder(5));
            Task task_6 = task_5.ContinueWith(project => Builder(6));
            Task task_7 = task_6.ContinueWith(project => Builder(7));
            Task task_8 = task_7.ContinueWith(project => Builder(8));
            Task.WaitAll(task_8);

        }
        public void Concurrently()
        {
            Task task_1 = Task.Factory.StartNew(() => Builder(1));
            Task task_2 = Task.Factory.StartNew(() => Builder(2));
            Task task_3 = Task.Factory.StartNew(() => Builder(3));
            Task task_4 = task_1.ContinueWith(p => Builder(4));
            Task task_5 = Task.Factory.ContinueWhenAll(new Task[] { task_1, task_2, task_3 }, projects => Builder(5));
            Task task_6 = Task.Factory.ContinueWhenAll(new Task[] { task_3, task_4 }, projects => Builder(6));
            Task task_7 = Task.Factory.ContinueWhenAll(new Task[] { task_5, task_6 }, projects => Builder(7));
            Task task_8 = task_5.ContinueWith(project => Builder(8));
            Task.WaitAll(task_7, task_8);
        }
    }
}
