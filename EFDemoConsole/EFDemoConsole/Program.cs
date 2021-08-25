using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EFDemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HotelModel db = new HotelModel();

           /* var results = from b in db.Hotels
                select b;
            // get all hotels
            foreach (var b in results)
            {
                Console.WriteLine(b);
            }*/

            // get hotels in roskilde 
          /*  var roskildeHotels = from b in db.Hotels
                select b;
            foreach (var b in roskildeHotels)
            {
                if (b.Address.Contains("Roskilde"))
                {
                    Console.WriteLine(b);
                }

            }*/

            // get info about the rooms that are at the hotel “Scandik”

            var scandicRooms = from r in db.Rooms
                select r;
            foreach (var r in scandicRooms)
            {
                if (r.Hotel.Name == "Scandic")
                {
                    Console.WriteLine(r);
                }
            }

                           Console.ReadKey();
        }

    }
}
