using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceCarCore
{
    public class Car
    {

        public int Id { get; set; }
        public string Vendor { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }

        public Car()
        {

        }

       
        public Car(int id, string vendor, string model, int price)
        {
            Id = id;
            Vendor = vendor;
            Model = model;
            Price = price;
        }
    }
}
