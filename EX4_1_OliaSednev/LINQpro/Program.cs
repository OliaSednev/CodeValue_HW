using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LINQpro
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = new Querys();

            Console.WriteLine("---===  Public Interfaces  ===---");
            query.InterfacesQuery();

            Console.WriteLine("---===  Processes  ===---");
            query.ProcessesQuery();

            Console.WriteLine("---===  Processes by Base Priority  ===---");
            query.ProcessesQueryWithBasePriority();

            Console.WriteLine("---===  Total number of theards  ===---");
            query.Threads();

            Console.WriteLine("---===  CopyTo  ===---");
            var a1_Object = new ClassA("shalom");
            var a2_Object = new ClassA("olia");

            var b1_Object = new ClassB("Michael");
            var b2_Object = new ClassB("Nitzan");

            Console.WriteLine(b1_Object);
            a1_Object.CopyTo(b1_Object);
            Console.WriteLine(b1_Object);

            Console.WriteLine(a1_Object);
            a2_Object.CopyTo(a1_Object);
            Console.WriteLine(a1_Object);

            Console.WriteLine(a1_Object);
            b2_Object.CopyTo(a1_Object);
            Console.WriteLine(a1_Object);

        }
    }
}
