using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPsenderClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Loopback IP means the local IP is 127.0.0.1 which is the server IP 
            // below we are defining the IP and the port number 
            // client should use the port number of the server 
            UdpClient udpSender = new UdpClient("127.0.0.1", 9999);
            Console.WriteLine("Take input from console");
            var input = Console.ReadLine();
            int number = 0;
            try
            { // 20 is the number of times we want the message to be sent, we can change it to what we need
                for (int i = 0; i < 20; i++)
                { // send datagram to remote host
                  // byte in array because 
                  // when u send ur text message u must convert ur text data into bytes of stream 
                    Byte[] sendingBytes = Encoding.ASCII.GetBytes("The number is" + number + input);
                    udpSender.Send(sendingBytes, sendingBytes.Length);
                    number++;
                    Console.WriteLine(number);
                    Thread.Sleep(500); 
                 }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
