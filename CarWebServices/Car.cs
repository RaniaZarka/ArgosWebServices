using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebServices
{
    public class Car
    {
        public Car()
        {
        }

        public Car(int iD, string model, string vendor, int price)
        {
            ID = iD;
            Model = model;
            Vendor = vendor;
            Price = price;
        }

        public int ID { get; set; }
        public string Model { get; set; }
        public string Vendor { get; set; }
        public int Price { get; set; }
    }
}
