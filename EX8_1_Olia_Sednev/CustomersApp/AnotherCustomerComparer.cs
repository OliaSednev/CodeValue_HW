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
            if (firstCustomer == null && secondCustomer == null)
            {
                return 0;
            }
            else if (firstCustomer == null || secondCustomer == null)
            {
                return 1;
            }
            return firstCustomer.ID.CompareTo(secondCustomer.ID);
        }
    }
}
