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

        public static void Main(string[] args)
        {
            var mailData = new MailManager();//publisher

            mailData.MailArrived += (obj, mailevenArgs) => { Console.WriteLine(mailevenArgs.Title); };
            mailData.MailArrived += (obj, mailevenArgs) => { Console.WriteLine(mailevenArgs.Body); };

            mailData.SimulateMailArrived();
            var timer = new Timer(TimerCallback, null, 1000, 1000);
            Console.ReadLine();

        }

        private static void TimerCallback(object state)
        {
            var mailData = new MailManager();//publisher

            mailData.MailArrived += (obj, mailevenArgs) => { Console.WriteLine(mailevenArgs.Title); };
            mailData.MailArrived += (obj, mailevenArgs) => { Console.WriteLine(mailevenArgs.Body); };

            mailData.SimulateMailArrived();
            Console.WriteLine($"{DateTime.Now.TimeOfDay}");
        }
    }
}
