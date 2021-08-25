using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TradeAgainTCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                TcpListener serverSocket = new TcpListener(ip, 7000);
                serverSocket.Start();
                while (true)
                {
                    TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                    Console.WriteLine("Server activated now");
                    EchoServices service = new EchoServices(connectionSocket);
                    //Task solution with delegates
                    Task.Factory.StartNew(() => service.DoIt());
                }
                serverSocket.Stop();
            }
        }
    }

