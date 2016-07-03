using System;

namespace MailSystem
{
    public class MailArrivedEventArgs: EventArgs
    {
        public readonly string Title;
        public readonly string Body;

        internal MailArrivedEventArgs(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}