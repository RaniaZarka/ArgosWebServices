using System;
using System.Collections.Generic;
using System.Text;

namespace RestCustomerConsumer
{
    class Customer
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfRegistration { get; set; }


        public Customer() { }
        public Customer(int id, string first, string last, int year)
        {
            ID = id;
            FirstName = first;
            LastName = last;
            YearOfRegistration = year;

        }
    }
}
