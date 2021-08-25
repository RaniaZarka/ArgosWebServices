using HopClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopWebAppApi
{
    public class HopList
    {

        public static List<Hop> hopList = new List<Hop>()
        {
             new Hop(1, "Amarillo", 7.5, 2019, 49, 100 ),
            new Hop(2, "Cascade USA", 6.5, 2020, 69, 150),
            new Hop(3, "Chinook", 11.3, 2020, 65, 200),
            new Hop(4, "Mosaic, eco", 10.01, 2020, 85, 300),
            new Hop(5, "Saaz", 2.5, 2020, 54, 200)
        };
    }
}
