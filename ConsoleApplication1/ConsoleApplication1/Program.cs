using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            var xmlStr = File.ReadAllText(@"D:\Product.xml");


            var str = XElement.Parse(xmlStr);

            var result = str.Elements("word").Where(x => x.Element("Product_name").Value.Equals("Product 3")).ToList();

            Console.WriteLine(result);


            //XmlTextReader reader = new XmlTextReader(@"D:\Product.xml");

            //while (reader.Read())
            //{
            //    switch (reader.NodeType)
            //    {
            //        case XmlNodeType.Element: // The node is an element.
            //            Console.Write("<" + reader.Name + "> ");
            //            break;

            //        case XmlNodeType.Text: //Display the text in each element.
            //            Console.Write(reader.Value);
            //            break;

            //        case XmlNodeType.EndElement: //Display the end of the element.
            //            Console.WriteLine(" </" + reader.Name + ">");
            //            break;


            //        }
            //    }

        }

    }
}

