using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katerina
{
    public class Food
    {
        public Food() { }

        public Food(int id, string name, int inStock, int lowLevel)
        {
            ID = id;
            Name = name;
            InStock = inStock;
            LowLevel = lowLevel;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int InStock { get; set; }
        public int LowLevel { get; set;}


    }
}
