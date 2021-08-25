using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPBroadcastSender

{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 to 1 comunication (uni casting communication)
            // sending UDP on air to all devices , we dont need to use any host name just the port number 
            // here we need to send udp datagram to specific port number 
            
            UdpClient udpBroadcastSender = new UdpClient(7000);

            // UDP is based on the end point here we need to define here we use IPAddress.Brodcast but in TCP we used IPAdress.Parse(127.0.0.1)
            // broadcast IP : 255.255.255. so we can use IPAddress.Broadcast or insert the number 
            // we have to define the port number 
            // port number can be 0 this means automaticly detect the available port on the network 
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Broadcast,0);

            // we need a random number generated 
            //  Guid.NewGuid() : this will make sure to generate the number just once 
            Random ran = new Random(Guid.NewGuid().GetHashCode());
            Console.WriteLine("press enter to start Sender");

            try
            {
                while (true)
                {
                    // here we are generating numbers from 1 to 1000 and because we r using the ran it makes sure it will generate the number once 
                    var number = ran.Next(1, 1000);

                    // convert your message into bytes
                    Byte[] sendBytes = Encoding.ASCII.GetBytes("the number is :" + number);

                    udpBroadcastSender.Send(sendBytes, sendBytes.Length, iPEndPoint);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }
    }
}
