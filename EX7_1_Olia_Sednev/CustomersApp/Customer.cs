using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        //prop
        public string name { get; private set; }
        public string Name
        {
            get
            {
                return name.ToLower();
            }
            set
            {
                name = value;
            }
        }
        public int ID { get; set; }
        public string Address { get; set; }

        //Constructors
        public Customer(string name, int id, string address)
        {
            Name = name;
            ID = id;
            Address = address;
        }
        public Customer(string name, int id) : this(name, id, "") { }
        public Customer(string name) : this(name, 0, "") { }
        public Customer() : this("", 0, "") { }
        

        // Implementation of IComparable<Customer>
        public int CompareTo(Customer other)
        {
            if (other == null)
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
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
    }
}
