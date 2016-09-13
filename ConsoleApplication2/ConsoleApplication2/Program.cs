using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication2
{
    class Program
    {
        class Product
        {
            public string id { get; set; }
            public string name { get; set; }
            public string price { get; set; }
        }

        static void Main(string[] args)
        {
            XDocument doc = XDocument.Parse(@"D:\Product.xml");
            XElement lex = doc.Element("Table");
            Product[] catWords = null;
            if (lex != null)
            {
                IEnumerable<XElement> product = lex.Elements("Product");
                catWords = (from itm in product
                            where itm.Element("Product_id") != null
                                && itm.Element("Product_id").Value == "1"
                                && itm.Element("Product_name") != null
                                && itm.Element("Product_price") != null
                            select new Product()
                            {
                                id = itm.Element("Product_id").Value,
                                name = itm.Element("Product_name").Value,
                                price = itm.Element("Product_price").Value,
                            }).ToArray<Product>();
            }

            //print it
            if (catWords != null)
            {
                Console.WriteLine("Words with <category> and value verb:\n");
                foreach (Product itm in catWords)
                    Console.WriteLine("[Found]\n Id: {0}\n name: {1}\n price: {2}\n", itm.price, itm.id, itm.name);
            }
        }
    }
}
