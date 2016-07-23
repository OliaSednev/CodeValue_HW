using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var xml = new XElement("mscorelib_Classes",
                from classes in typeof(string).Assembly.GetExportedTypes()
                where classes.IsClass
                orderby (classes.Name)
                select new XElement("Type",
                new XAttribute("FullName", classes.Name),
                new  XElement("Properties",
                    from pproperties in classes.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    orderby (pproperties.Name)
                    select new XElement("Property",
                    new XAttribute("Name",pproperties.Name),
                    new XAttribute("Type", pproperties.PropertyType))),
                new XElement("Methods",
                    from methods in classes.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    orderby (methods.Name)
                    select new XElement("Method",
                    new  XAttribute("Name", methods.Name),
                    new  XAttribute("ReturnType", methods.ReturnType),
                    new  XElement("Parameters",
                        from paramater in  methods.GetParameters()
                        select new XElement("Parameter",
                        new XAttribute("Name", paramater.Name),
                        new XAttribute("Type", paramater.ParameterType)))))));
            xml.Save("ClassesInMscorelib.xml");

            Console.WriteLine("--==types With No Property==--\n");
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

            Console.WriteLine("--==Methods count==--");
            var methodscount = (from method in xml.Descendants("Method")
                                select method).Count();

            Console.WriteLine($"\nThere is {methodscount} methods!\n");

            Console.WriteLine("--==Statistics==--");
            int propertiesCount = xml.Descendants("Property").Count();
            Console.WriteLine($"There are {propertiesCount} properties");

            var commonTypeAsParameter =
                from parameter in xml.Descendants("Parameter")
                group parameter by parameter.Attribute("Type").Value
                into array
                orderby array.Count() descending
                select array.Key;
            Console.WriteLine($"The most common type as parameter is {commonTypeAsParameter.FirstOrDefault()}");


            Console.WriteLine("--==Sorting==--");
            var sortingTypes = new XElement("Types",
                from type in xml.Descendants("Type")
                orderby type.Descendants("Method").Count() descending
                select new XElement("Type",
                new XAttribute("Name", type.Attribute("FullName").Value),
                new XAttribute("SumOfMethods", type.Descendants("Method").Count()),
                new XAttribute("SumOfProperties", type.Descendants("Property").Count())));

            sortingTypes.Save("SortedXML.xml");
            Console.WriteLine(sortingTypes);

            Console.WriteLine("--==Group by the number of methods==--");
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
