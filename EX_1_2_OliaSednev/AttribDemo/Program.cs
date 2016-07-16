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
                Analayze_Assembly myAssembly = new Analayze_Assembly();
                Console.WriteLine(myAssembly.AnalayzeAssembly(Assembly.GetExecutingAssembly()));

                //1.2 - 10) The attributes that I looking could not find in Int Assembly
                Console.WriteLine(myAssembly.AnalayzeAssembly(typeof(int).Assembly).ToString());

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
