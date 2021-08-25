using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketIterative
{
    class Program
    {
        
        private static TcpListener _welcomingServerSocket;
        private static TcpClient _serverSocket;
         
       
       
        static void Main(string[] args)
        {

            try
            {
                
                IPAddress ip = IPAddress.Parse("192.168.24.228");
                _welcomingServerSocket = new TcpListener(ip, 6789);
                                                                   

                _welcomingServerSocket.Start(); 
                Console.WriteLine("server is waiting the call request of client");
                using (_serverSocket = _welcomingServerSocket.AcceptTcpClient()) 
                {
                   
                    var clientIp = ((IPEndPoint)_serverSocket.Client.RemoteEndPoint).Address;
                    
                    var clientPort = ((IPEndPoint)_serverSocket.Client.RemoteEndPoint).Port;

                    Console.WriteLine("clientPort has a IP:" + clientIp + "and port number:" + clientPort);
                    Console.WriteLine("Now hanshake has been created");
                    Console.WriteLine("Client and server are able to communicate over the network");

                    TCPEchoService service = new TCPEchoService(_serverSocket);
                    service.DoIt();
                   
                }
                _welcomingServerSocket.Stop();
                Console.ReadKey();
                   

                        

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();

            }
        


    

}
    }
}
