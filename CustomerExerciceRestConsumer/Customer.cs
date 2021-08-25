using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerExerciceRestConsumer
{
   public  class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfRegistration { get; set; }

        public Customer() { }

        public Customer(int id, string firstName, string lastName, int year)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            YearOfRegistration = year;
            
        }
    }
}
