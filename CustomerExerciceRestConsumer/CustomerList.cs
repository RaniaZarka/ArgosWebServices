using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerExerciceRestConsumer
{
    public class CustomerList
    {
       public List<Customer> cList = new List<Customer>()
        { new Customer(1, "John", "Smith", 2000),
          new Customer(2, "Jack", "Jones", 2002),
          new Customer(3,  "Jessica", "Smith", 2009)
        };
    }
}
