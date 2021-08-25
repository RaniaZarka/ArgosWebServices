using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPBroadcastReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            // here we r createing a UPDClient 
            //when we r defining a receiver, so reading a broadcast data , 
            //we have to mention the port number the one we defined in the UDPBroadcastSender 

            UdpClient udpBroadcastReceiver = new UdpClient(7000);

            // here we have to define the IP address and the port number 
            // receiver become automaticaly broadcaster , so we need IPAdress.Any to be able to receive from any localhost 
            // port number we use 0 so it automatically detect the port number,
            //we can also write the 7000 number we defined up, but better use 0 
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Receiver is block untilmessage from host device" );

            try
            {
                while (true)
                {
                    // we use ref cause it means return the variabe
                    Byte[] receiveByte = udpBroadcastReceiver.Receive(ref ipEndPoint);

                    // convert bytes into message

                    string stringMessage = Encoding.ASCII.GetString(receiveByte);
                    Console.WriteLine("the message coming from remote host " + stringMessage);
                    Console.WriteLine("The Remote IP address" + ipEndPoint.Address + "and port number is " + ipEndPoint.Port);
                    Thread.Sleep(2000);
                }



            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }


        }
    }
}
