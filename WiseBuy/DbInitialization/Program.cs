using XML_Parser;
using System.Xml.Linq;
using XML_Parser;

namespace DbInitialization
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreAndPriceParser storeAndPriceParser = new StoreAndPriceParser();

            ////clear DB
            storeAndPriceParser.ClearDb();

            //////storefiles
            XDocument fileXDocumentStore =
                XDocument.Load(@"C:\Projects\Go\MarketInitFiles\Hazihinam\Stores7290700100008-201608152005.xml");
            storeAndPriceParser.ParseStoreXmlFile(fileXDocumentStore);

            fileXDocumentStore =
                XDocument.Load(@"C:\Projects\Go\MarketInitFiles\Ramilevi\Stores7290058140886-201608152005.xml");
            storeAndPriceParser.ParseStoreXmlFile(fileXDocumentStore);

            fileXDocumentStore =
                XDocument.Load(@"C:\Projects\Go\MarketInitFiles\Yohananof\Stores7290803800003-201608150100.xml");
            storeAndPriceParser.ParseStoreXmlFile(fileXDocumentStore);

            //////pricefiles
            XDocument fileXDocumentPrice =
                XDocument.Load(@"C:\Users\oliak\Desktop\newPro\MarketInitFiles\MarketInitFiles\Hazihinam\PriceFull7290700100008-001-201608150010_short.xml");
            storeAndPriceParser.ParsePriceXmlFiles(fileXDocumentPrice);

            fileXDocumentPrice =
                XDocument.Load(@"C:\Users\oliak\Desktop\newPro\MarketInitFiles\MarketInitFiles\Ramilevi\PriceFull7290058140886-008-201608150010_short.xml");
            storeAndPriceParser.ParsePriceXmlFiles(fileXDocumentPrice);

            fileXDocumentPrice =
                XDocument.Load(@"C:\Users\oliak\Desktop\newPro\MarketInitFiles\MarketInitFiles\Yohananof\PriceFull7290803800003-007-201608150010_short.xml");
            storeAndPriceParser.ParsePriceXmlFiles(fileXDocumentPrice);
        }
    }
}
