using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    internal class Reader
    {
        public List<string> ReadFromFile(StreamReader sReader)
        {
            var sReaderList = new List<string>();
            var line = "";
            while (line != null)
            {
                line = sReader.ReadLine();
                if (line != null)
                {
                    sReaderList.Add(line);
                }
            }
            sReader.Close();
            return sReaderList;
        }

    }
}
