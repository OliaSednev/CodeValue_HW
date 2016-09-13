using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DbCreator;

namespace InterfaceXmlToDb
{
    public interface IXmlManager
    {
        void ParseStoreXmlFile(XDocument doc);
        void ParsePriceXmlFiles(XDocument doc);
    }
}
