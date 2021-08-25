using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace RestCustomerServicesAssignment.Model
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfRegistration { get; set; }


        public Customer() { }
        public Customer ( int id, string first, string last, int year)
        {
            ID = id;
            FirstName = first;
            LastName = last;
            YearOfRegistration = year;
            this.ID = id++;
        }
    }
}
