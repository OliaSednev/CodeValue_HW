using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSystem
{
    class Program
    {
        class TimerState
        {
            public int counter = 0;
            public Timer timer;
        }
        static void CheckStatus(object state)
        {
            MailManager mailData = new MailManager();
            mailData.MailArrived += (obj, mailevenArgs) => { Console.WriteLine(mailevenArgs.Title); };
            mailData.MailArrived += (obj, mailevenArgs) => { Console.WriteLine(mailevenArgs.Body); };
            mailData.SimulateMailArrived();

            TimerState timerState = (TimerState)state;
            timerState.counter++;
            Console.WriteLine("{0} Checking Status {1}.", DateTime.Now.TimeOfDay, timerState.counter);

        }
        static void Main(string[] args)
        {
            MailManager mailData = new MailManager();//publisher

            mailData.MailArrived += (obj, mailevenArgs) => { Console.WriteLine(mailevenArgs.Title); };
            mailData.MailArrived += (obj, mailevenArgs) => { Console.WriteLine(mailevenArgs.Body); };

            mailData.SimulateMailArrived();


            TimerState timerState = new TimerState();

            // Create the delegate that invokes methods for the timer.
            TimerCallback timerDelegate = new TimerCallback(CheckStatus);

            // Create a timer that waits one second, then invokes every second.
            Timer timer = new Timer(timerDelegate, timerState, 1000, 1000);

            // Keep a handle to the timer, so it can be disposed.
            timerState.timer = timer;

            // The main thread does nothing until the timer is disposed.
            while (timerState.timer != null)
                Thread.Sleep(0);
            Console.WriteLine("Timer example done.");
            // The following method is called by the timer's delegate.
        }
    }
}
