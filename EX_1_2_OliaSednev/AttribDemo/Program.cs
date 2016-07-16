using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AttribDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Analayze_Assembly _Assembly = new Analayze_Assembly();
                Console.WriteLine(_Assembly.AnalayzeAssembly(Assembly.GetExecutingAssembly()));

                //1.2 - 10) The attributes that I looking could not find in Int Assembly
                Console.WriteLine(_Assembly.AnalayzeAssembly(typeof(int).Assembly).ToString());

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (TargetException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
