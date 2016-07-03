using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{


    public class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        //prop
        //some some comment
        public string Name { get; private set; }
        public int ID { get; private set; }
        public string Address { get; private set; }

        //Constructors
        public Customer(string name, int id, string address)
        {
            Name = name;
            ID = id;
            Address = address;
        }
        public Customer(string name, int id) : this(name, id, "null") { }
        public Customer(string name) : this(name, 0, "null") { }
        public Customer() : this("null", 0, "null") { }


        // Implementation of IComparable<Customer>
        public int CompareTo(Customer other)
        {
            if (other == null)
            {
                return 1;
            }
            return string.Compare(Name, other.Name, true);
        }

        // Implementation of IEquatable<Customer>
        public bool Equals(Customer other)
        {
            if (other == null)
                return false;

            if ((Name == other.Name) && (ID == other.ID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void DisplayCustomers(IEnumerable<Customer> _customers)
        {
            foreach (Customer item in _customers)
            {
                Console.WriteLine(item);
            }
        }
        public override string ToString()
        {
            return string.Format("Name:{0, 15}\t ID: {1, 15}\t Address:{2, 15}", Name, ID, Address);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode()^ID.GetHashCode();
        }
    }
}
