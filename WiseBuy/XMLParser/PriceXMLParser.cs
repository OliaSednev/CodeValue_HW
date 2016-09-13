using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DbCreator;

namespace XMLParser
{
    class PriceXMLParser
    {
        public IEnumerable<Item> ItemsInit(string file)
        {
            try
            {
                var doc = XDocument.Load(file);

                long chainId = long.Parse(doc.Root.Element("ChainId").Value);
                long subChainId = long.Parse(doc.Root.Element("SubChainId").Value);
                int storeId = int.Parse(doc.Root.Element("StoreId").Value);

                var items = doc.Descendants("ItemCode")
                    .Select(priceElement => priceElement.Parent)
                    .Select(item => new Item
                    {
                        //ChainId = chainId,
                        //SubChainId = subChainId,
                        //StoreId = storeId,
                        //ItemPrice = double.Parse(item.Element("ItemPrice").Value),
                        //ItemId = long.Parse(item.Element("ItemId").Value),
                        //ItemCode = long.Parse(item.Element("ItemCode").Value),
                        //ItemName = item.Element("ItemName").Value,
                        //PriceUpdateDate = DateTime.Parse(item.Element("PriceUpdateDate").Value)
                    });

                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Item>();
            }
        }
    }
}
