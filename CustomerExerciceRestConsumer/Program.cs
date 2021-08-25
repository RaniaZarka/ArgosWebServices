using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExerciceRestConsumer
{

    class Program
    {
        static HttpClient client = new HttpClient();
        static Customer c = new Customer();
        static string uri = "https://localhost:44307/customers";

        private static TcpListener _welcomingSocket;
        private static TcpClient _serverSocket;
        private static object tcpService;

        static void Main(string[] args)
        {

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            _welcomingSocket = new TcpListener(ip, 4646);

            _welcomingSocket.Start();

            using (_serverSocket = _welcomingSocket.AcceptTcpClient())
            {

                Console.WriteLine("Server is connected");
                TCPServices service = new TCPServices(_serverSocket, _welcomingSocket);

                while (true)
                {

                    Task.Run(() => service.DoIt());
                }


            }
            //Console.WriteLine("Customer's list");

           // PrintAllCustomers();

            //Console.WriteLine("Insert a customer ID: ");
            //ConsoleKeyInfo key = Console.ReadKey();
            //Console.WriteLine("ID:" + key);

        }


    }
}
