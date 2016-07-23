using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XLinq
{
    class Queries
    {
        public void TypesWithNoProperty(XElement xml)
        {
            var typesWithNoProperty = (from type in xml.Descendants("Type")
                                       let xElement = type.Element("Properties")
                                       let typeName = (string)type.Attribute("FullName")
                                       orderby typeName
                                       where xElement != null && !xElement.HasElements
                                       select typeName).ToList();

            foreach (var item in typesWithNoProperty)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\nThere are {typesWithNoProperty.Count} Types without properties\n");
        }

        public void MethodsCounter(XElement xml)
        {
            var methodscount = (from method in xml.Descendants("Method")
                                select method).Count();
            Console.WriteLine($"\nThere is {methodscount} methods!\n");
        }

        public void PropertiesCounter(XElement xml)
        {
            int propertiesCount = xml.Descendants("Property").Count();
            Console.WriteLine($"There are {propertiesCount} properties");
            var commonTypeAsParameter = from parameter in xml.Descendants("Parameter")
                                        group parameter by parameter.Attribute("Type").Value
                                        into array
                                        orderby array.Count() descending
                                        select array.Key;
            Console.WriteLine($"The most common type as parameter is {commonTypeAsParameter.FirstOrDefault()}");
        }

        public void SortingTypes(XElement xml)
        {
            var sortingTypes = new XElement("Types",
                from type in xml.Descendants("Type")
                orderby type.Descendants("Method").Count() descending
                select new XElement("Type",
                new XAttribute("Name", type.Attribute("FullName").Value),
                new XAttribute("SumOfMethods", type.Descendants("Method").Count()),
                new XAttribute("SumOfProperties", type.Descendants("Property").Count())));

            sortingTypes.Save("SortedXML.xml");
            Console.WriteLine(sortingTypes);

        }

        public void sortingGroups(XElement xml)
        {
            var sortingGroups = from type in xml.Descendants("Type")
                                orderby type.Attribute("FullName").Value
                                group type by type.Descendants("Method").Count()
                                into groups
                                orderby groups.Key descending
                                select groups;
            foreach (var groups in sortingGroups)
            {
                Console.WriteLine($"Number Of methods in the classes: {groups.Key}");
                Console.WriteLine("--------------------------------------------------");
                foreach (var type in groups)
                {
                    Console.WriteLine($"The class {type.Attribute("FullName")}");
                }
                Console.WriteLine();
            }
        }
    }
}
