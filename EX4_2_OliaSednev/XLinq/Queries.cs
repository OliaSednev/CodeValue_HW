using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XLinq
{
    class Queries
    {
        private XElement xml;

        //public Queries(XElement xml)
        //{
        //    this.xml = xml;
        //}

        //List all types that have no properties.
        public void typesWithNoProperty(XElement xml)
        {
            int count = 0;
            var query1 = from type in xml.Descendants("Type")
                         let element = type.Element("FullName")
                         where element != null && element.IsEmpty
                         orderby (string) type.Attribute("Name").Value
                         select type.Attribute("Name").Value;

            foreach (var itemWithNoProperty in query1)
            {
                count++;
                Console.WriteLine(itemWithNoProperty);    
            }
            Console.WriteLine($"There are {count} Types without properties");
        }



    }
}
