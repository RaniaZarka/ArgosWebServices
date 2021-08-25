using CustomerExerciceWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerExerciceWebApi.Model
{
    public class Customer
    {
       public  int ID { get; set; }
       public  string FirstName { get; set; }
       public string LastName { get; set; }
        public int YearOfRegistration { get; set; }

        public Customer() { }

        public Customer( string firstName, string lastName, int year)
        {
           
            FirstName = firstName;
            LastName = lastName;
            YearOfRegistration = year;
            this.ID = CustomersController.nextId++;
        }
        public Customer( int id, string firstName, string lastName, int year)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            YearOfRegistration = year;
            
        }

    }
}
