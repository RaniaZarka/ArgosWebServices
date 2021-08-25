using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCustomerServicesAssignment.Model
{
    public class CustomerList
    {
        int ID = 0;
        public static List<Customer> cList = new List<Customer>()
        { 
            new Customer(1,"John","Smith",2000),
            new Customer(2,"Lucas", "Maalouf", 2012),
            new Customer(3, "Jack", "Johns",2006)
        };
    }
}
 