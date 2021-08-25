using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketEchoTPCClient
{
    class Program
    {

        private static TcpClient _clientSocket;
        private static Stream _nStream;
        private static StreamWriter _sWriter;
        private static StreamReader _sReader;

        static void Main(string[] args)
        {

            try
            {
                using (_clientSocket = new TcpClient("192.168.24.217", 6578))
                {
                    using (_nStream = _clientSocket.GetStream())
                    {
                        _sWriter = new StreamWriter(_nStream) { AutoFlush = true };
                        _sReader = new StreamReader(_nStream);

                        Console.WriteLine(" Insert your message here: ");
                        var ClientMsg = Console.ReadLine();

                        _sWriter.WriteLine(ClientMsg);
                        var msgFromServer = _sReader.ReadLine();
                        Console.WriteLine("Server message " + msgFromServer);
                    }
                }
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
        
  

