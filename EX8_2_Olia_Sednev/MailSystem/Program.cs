using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSystem
{
    internal class Program
    {
        private class TimerState
        {
            public int Counter = 0;
            public Timer Timer;
        }

        private static void CheckStatus(object state)
        {
            var mailData = new MailManager();
            mailData.MailArrived += (obj, mailevenArgs) => { Console.WriteLine(mailevenArgs.Title); };
            mailData.MailArrived += (obj, mailevenArgs) => { Console.WriteLine(mailevenArgs.Body); };
            mailData.SimulateMailArrived();

            var timerState = (TimerState)state;
            timerState.Counter++;
            Console.WriteLine($"{DateTime.Now.TimeOfDay} Checking Status {timerState.Counter}.");

        }

        public static void Main(string[] args)
        {
            var mailData = new MailManager();//publisher

            mailData.MailArrived += (obj, mailevenArgs) => { Console.WriteLine(mailevenArgs.Title); };
            mailData.MailArrived += (obj, mailevenArgs) => { Console.WriteLine(mailevenArgs.Body); };

            mailData.SimulateMailArrived();


            var timerState = new TimerState();

            // Delegate that invokes methods for the timer.
            var timerDelegate = new TimerCallback(CheckStatus);

            // timer that waits one second, then invokes every second.
            var timer = new Timer(timerDelegate, timerState, 1000, 1000);

            // Keep a handle to the timer, so it can be disposed.
            timerState.Timer = timer;

            // The main thread does nothing until the timer is disposed.
            while (timerState.Timer != null)
            {
                Thread.Sleep(0);
            }
        }
    }
}
