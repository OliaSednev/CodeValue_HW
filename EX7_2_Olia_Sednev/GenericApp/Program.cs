using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiDictionary<int, string> _multiDictionary = new MultiDictionary<int, string>() { { 1, "one" },{ 2, "two" },
                { 3, "three" }, { 1, "ich" }, { 2, "nee" }, { 3, "sun" }, { 1, "uno" } };

            //Add item to multi dictionary
            _multiDictionary.Add(2, "dos");
            _multiDictionary.Add(3, "tres");

            Console.WriteLine("\nValues:");
            Console.WriteLine("-----------------------");
            foreach (var item in _multiDictionary.Values)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nKeys:");
            Console.WriteLine("-----------------------");
            foreach (var item in _multiDictionary.Keys)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("\n_multiDictionary.Count");
            Console.WriteLine("-----------------------");
            Console.WriteLine(_multiDictionary.Count); 

            Console.WriteLine("\nKeyValuePair<int, string>");
            Console.WriteLine("--------------------------");
            foreach (KeyValuePair<int, string> kvp in _multiDictionary)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

            //Does Pair: key = 1, value = one contains in the dictionary ?
            Console.WriteLine("\nDoes Pair: key = 1, value = one contains in the dictionary ?");
            Console.WriteLine("-----------------------");
            Console.WriteLine(_multiDictionary.Contains(1, "one"));
            //Does Pair: key = 2, value = one contains in the dictionary ?
            Console.WriteLine("\nDoes Pair: key = 2, value = one contains in the dictionary ?");
            Console.WriteLine("-----------------------");
            Console.WriteLine(_multiDictionary.Contains(2, "one"));

            Console.WriteLine("\n_multiDictionary.Remove(2)");
            Console.WriteLine("-----------------------");
            _multiDictionary.Remove(2);

            foreach (KeyValuePair<int, string> kvp in _multiDictionary)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

            Console.WriteLine("\n_multiDictionary.Remove(1, uno);");
            Console.WriteLine("-----------------------");
            _multiDictionary.Remove(1, "uno");

            foreach (KeyValuePair<int, string> kvp in _multiDictionary)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

            Console.WriteLine("\nDictionary after _multiDictionary.Clear()");
            Console.WriteLine("-----------------------------------------\n\n");
            _multiDictionary.Clear();
            foreach (var item in _multiDictionary.Values)
            {
                Console.WriteLine(item);
            }


        }
    }
}
