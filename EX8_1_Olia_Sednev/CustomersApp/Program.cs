using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Program
    {
        //Declare a delegate
        public delegate bool CustomerFilter(Customer customerObj);

        //filters
        public static bool FilterByFirstLetterA_K(Customer customer)
        {
            return ((customer.Name.ToLower()[0] >= 'a' && customer.Name.ToLower()[0] <= 'k')); 
        }

        public static bool FilterByID_0_100(Customer customer)
        {
            return ((customer.ID >= 0 && customer.ID <= 100));
        }

        public static List<Customer> GetCustomers(List<Customer> _Customers, CustomerFilter filter)
        {
            if (filter == null)
            {
                return _Customers;
            }
            List<Customer> _FilteredCustomers = new List<Customer>();
            foreach (Customer item in _Customers)
            {
                if(filter(item))
                {
                    _FilteredCustomers.Add(item);
                }
            }
            return _FilteredCustomers;
        }

        static void Main(string[] args)
        {


            //Array creation
            List<Customer> _Customers = new List<Customer>();
            _Customers.Add(new Customer("alon", 12, "Tel Aviv"));
            _Customers.Add(new Customer("OLIA", 987654321, "Jerusalem"));
            _Customers.Add(new Customer("Zoy", 777777777, "Jaffa"));
            _Customers.Add(new Customer("bella", 98, "Jerusalem"));
            _Customers.Add(new Customer("Olia", 777777777, "Ashdod"));
            _Customers.Add(new Customer("KOLIA", 123456789, "Tel Aviv"));

            //Use a separate method to implement the delegate.
            CustomerFilter _FilteredByFirstLetter = new CustomerFilter(FilterByFirstLetterA_K);
            Console.WriteLine("Customers who's names begins with letters A-K: ");
            Console.WriteLine("-----------------------------------------------");
            Customer.DisplayCustomers(GetCustomers(_Customers, _FilteredByFirstLetter));


            //Anonymous delegate.
            CustomerFilter _FilteredCustomers = delegate (Customer customer)
             {
                 return (customer.Name.ToLower()[0] >= 'l' && customer.Name.ToLower()[0] <= 'z');
             };
            Console.WriteLine("\nCustomers who's names begins with letters L-Z: ");
            Console.WriteLine("-----------------------------------------------");
            Customer.DisplayCustomers(GetCustomers(_Customers, _FilteredCustomers));


            //Lambda
            CustomerFilter _FilterCustomersByID = (Customer customer) => FilterByID_0_100(customer);
            Console.WriteLine("\nCustomers who's ID 0-100: ");
            Console.WriteLine("--------------------------");
            Customer.DisplayCustomers(GetCustomers(_Customers, FilterByID_0_100));

        }
    }
}
