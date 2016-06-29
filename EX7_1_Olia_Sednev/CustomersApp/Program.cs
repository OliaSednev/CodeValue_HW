using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //AArray creation
            Customer[] customersArray = new Customer[6];
            customersArray[0] = new Customer("alon", 123456789, "Tel Aviv");
            customersArray[1] = new Customer("OLIA", 987654321, "Jerusalem");
            customersArray[2] = new Customer("Zoy", 777777777, "Jaffa");
            customersArray[3] = new Customer("bella", 987654321, "Jerusalem");
            customersArray[4] = new Customer("Olia", 777777777, "Ashdod");
            customersArray[5] = new Customer("KOLIA", 123456789, "Tel Aviv");

            //IComparable<Customer>
            Console.WriteLine("---=== IComparable<Customer> ===---");
            int Comparable_result = customersArray[1].CompareTo(customersArray[4]);
            if(Comparable_result == 0)
            {
                Console.WriteLine("The same name");
            }
            else
            {
                Console.WriteLine("Different names");
            }

            //IEquatable<Customer>
            Console.WriteLine("\n\n----=== IEquatable<Customer> ===----");
            bool Equatable_result = customersArray[4].Equals(customersArray[5]);

            if (Equatable_result)
            {
                Console.WriteLine("The same customer");
            }
            else
            {
                Console.WriteLine("Different customers");
            }

            //Display array
            Console.WriteLine("\n\n---=== Customers Array ===---");
            foreach (var item in customersArray)
            {
                Console.WriteLine("Name:{0, 15}\t ID: {1, 15}\t Address:{2, 15}", item.Name, item.ID, item.Address);
            }

            //Display sorted array
            Array.Sort(customersArray);
            Console.WriteLine("\n\n---=== Sorted Array ===---");
            foreach (var item in customersArray)
            {
                Console.WriteLine("Name:{0,15}\t ID: {1, 15}\t Address:{2, 15}", item.Name, item.ID, item.Address);
            }

            //IComparer<Customer>
            Console.WriteLine("\n\n---=== IComparer<Customer> ===---");
            AnotherCustomerComparer customersComparison = new AnotherCustomerComparer();
            Array.Sort(customersArray, customersComparison);
            foreach (var item in customersArray)
            {
                Console.WriteLine("Name:{0,15}\t ID: {1, 15}\t Address:{2, 15}", item.Name, item.ID, item.Address);
            }

        }
    }
}
