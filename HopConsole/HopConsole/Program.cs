using HopClassLib;
using System;
using System.Collections.Generic;

namespace HopConsole
{
    class Program
    {
        // HopList h = new HopList();
       
        static void Main(string[] args)
        {

            List<Hop> hopList = new List<Hop>()
        {
            new Hop(1, "Amarillo", 7.5, 2019, 49, 100 ),
            new Hop(2, "Cascade USA", 6.5, 2020, 69, 150),
            new Hop(3, "Chinook", 11.3, 2020, 65, 200),
            new Hop(4, "Mosaic, eco", 10.01, 2020, 85, 300),
            new Hop(5, "Saaz", 2.5, 2020, 54, 200)
        };
            foreach (var v in hopList)
            {
                Console.WriteLine(v);
            }
        }
    }
}
