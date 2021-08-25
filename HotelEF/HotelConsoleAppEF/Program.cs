using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEF;

namespace HotelConsoleAppEF
{
    class Program
    {
        static void Main(string[] args)
        {
            string h_url = "/api/Hotels";
            string r_url = "/api/Rooms";
            const string serverURL = "http://localhost:51639";

            Console.WriteLine("------creating new hotel--------");
            Hotel newHotel = new Hotel() { Address = "Copenhagen", Hotel_No = 12, Name = "Wake Up" };

            Console.WriteLine("--------Creating new room---------");
            Room newRoom = new Room() {Hotel_No = 12, Room_No = 19, Price = 250, Types = "S"};
            

            GenericHotelTest<Hotel> gHotel = new GenericHotelTest<Hotel>(serverURL, h_url);
            GenericHotelTest<Room> gRoom = new GenericHotelTest<Room>(serverURL, r_url);

            gHotel.createOne(newHotel);
            
            gRoom.createOne(newRoom);

            Hotel hDelete = gHotel.deleteOne(8).Result;
            Console.WriteLine("the hotel that has been deleted is" +hDelete.Name);

            Room rDelete = gRoom.deleteOne(1).Result;
            Console.WriteLine("the room that has been deleted is" + rDelete.Types + rDelete.Hotel);


            Hotel nHotel = new Hotel(){Hotel_No = 12, Address ="USA", Name = "Cabinn Metro"};
            gHotel.updateOne(12,newHotel);

            Console.WriteLine("--------Get All Hotels--------");

            
            List<Hotel> hotelList= gHotel.GetAll().Result;
            foreach( var h in hotelList)
            {
                Console.WriteLine(h);
            }

            
            Console.WriteLine("--------Get All Rooms--------");
            
            
            List<Room> roomList = gRoom.GetAll().Result;
            foreach (var r in roomList)
            {
                Console.WriteLine(r);
            }

            Console.ReadLine();
        }
    }

    
}
