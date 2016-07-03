using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSystem
{
    public class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived; 

        public void SimulateMailArrived()
        {
            Console.WriteLine("SimulateMailArrived.....");

            OnMailArrived(new MailArrivedEventArgs("new title...", "new body...."));
        }
        protected virtual void OnMailArrived(MailArrivedEventArgs arg)
        {
            if (MailArrived != null)
                MailArrived(this, arg);
        }
    }
}

