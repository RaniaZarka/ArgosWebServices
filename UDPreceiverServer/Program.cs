using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPreceiverServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // create udpReceiver
            
            // here  we reserve our port number 
            UdpClient udpReceiver = new UdpClient(9999);

            // we can identify the IP address and the port number of the remote host by using the IPEndPoint
            // here because we are using the same IP server we write the 127.0.0.1
            // but if they are different we have to define the IP address of the remote host
            IPEndPoint remoteEbdPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            try
            { // we use while to be able to handle multiple data multiple requests  
                while (true)
                {
                    Console.WriteLine("Receiver is blocked until he could not receive message from remote host" );
                    // here we use receive cause we r receivig data from remoste host 
                    // ref below 
                    Byte[] receivingByteData = udpReceiver.Receive(ref remoteEbdPoint);

                    // then we have to convert Byte into string message 
                    string recievedStringData = Encoding.ASCII.GetString(receivingByteData);
                    Console.WriteLine("Data coming from remote host" + receivingByteData);
                    // if we want to know the IP address of the client we write what is below 

                    Console.WriteLine("The message send by Host IP" + remoteEbdPoint.Address );
                }
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}
