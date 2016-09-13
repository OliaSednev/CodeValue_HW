using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLToDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = XDocument.Load(@"C:\Users\amirc_000\Desktop\ConsoleApplication1\ConsoleApplication1\XMLFile1.xml");
            var prices = from items in doc.Root.Elements()
                         where items.Elements().Any(child => child.Element("Price") != null)
                         from item in items.Elements()
                         let price = item.Element("Price")?.Value
                         where price != null
                         select int.Parse(price);

            Console.WriteLine(string.Join(", ", prices));
            Console.ReadKey();
        }
    }
}













//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace ConsoleApplication1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var doc = XDocument.Load(@"D:\CodeV-College\XMLFile1.xml");
//            var prices = from items in doc.Root.Elements()
//                where ( items.Elements().Any(child => child.Element("ItemCode") != null)&&
//                items.Elements().Any(child => child.Element("ItemName") != null)&&
//                items.Elements().Any(child => child.Element("Price") != null)&&
//                items.Elements().Any(child => child.Element("Price") != null))

//                from item in items.Elements()
//                let price = item.Element("Price")?.Value
//                where price != null
//                select int.Parse(price);

//            Console.WriteLine(string.Join(", ", prices));
//            Console.ReadKey();
//        }
//    }
//}
