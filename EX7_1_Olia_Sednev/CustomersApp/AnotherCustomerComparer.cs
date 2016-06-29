using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class AnotherCustomerComparer : IComparer<Customer>
    {
        // Implementation of IComparer<Customer>
        public int Compare(Customer firstCustomer, Customer secondCustomer)
        {
            if (firstCustomer.ID.CompareTo(secondCustomer.ID) != 0)
                return firstCustomer.ID.CompareTo(secondCustomer.ID);
            else
                return 1;
        }
    }
}
