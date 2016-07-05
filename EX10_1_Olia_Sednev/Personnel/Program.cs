using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            var sReader = new StreamReader("names.txt");
            var reader = new Reader();
            var sReaderList = reader.ReadFromFile(sReader);

            foreach (var line in sReaderList)
            {
                Console.WriteLine(line);
            }
        }
    }
}
