using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;


namespace DynInvoke
{
    class Program
    {
        private static string InvokeHello(object obj, string inputString)
        {
            return obj.GetType().InvokeMember("Hello", BindingFlags.InvokeMethod, null, obj,
                new object[] { inputString }).ToString();
        }
        static void Main(string[] args)
        {
            try
            {
                A aMember = new A();
                B bMember = new B();
                C cMember = new C();

                Console.WriteLine(InvokeHello(aMember, "Olia"));
                Console.WriteLine(InvokeHello(bMember, "Olia"));
                Console.WriteLine(InvokeHello(cMember, "Olia"));
            }
            catch (TargetException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (TargetInvocationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
   
}