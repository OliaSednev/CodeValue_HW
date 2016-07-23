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

            var query = new Queries();

            Console.WriteLine("--==Types With no Property==--\n");
            query.TypesWithNoProperty(xml);

            Console.WriteLine("--==Methods counter==--");
            query.MethodsCounter(xml);

            Console.WriteLine("--==Properties counter==--");
            query.PropertiesCounter(xml);

            Console.WriteLine("--==Sorting types==--");
            query.SortingTypes(xml);

            Console.WriteLine("--==Sorting Groups==--");
            query.SortingGroups(xml);

        }
    }
}
