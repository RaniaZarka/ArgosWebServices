using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketIterative
{
    public class TCPEchoService
    {
        TcpClient _serverSocket;
        Stream _ntream;
        StreamReader _sReader;
        StreamWriter _sWriter;
        public TCPEchoService(TcpClient serviceSocket)
        {
            _serverSocket = serviceSocket;
        }

        public void DoIt()
        {
            try
            {
                   _ntream = _serverSocket.GetStream();
                    StreamReader _sReader = new StreamReader(_ntream);
                    StreamWriter _sWriter = new StreamWriter(_ntream) { AutoFlush = true };
                    var outputFromCLient = _sReader.ReadLine();
                    while (true)
                    {
                        Console.WriteLine("Client message " + outputFromCLient);
                        var resondingServerMessage = "Hi client welcome to pool of jungle ";
                        _sWriter.WriteLine(resondingServerMessage);
                        outputFromCLient = _sReader.ReadLine();
                    }
                _ntream.Close();
                _serverSocket.Close();

                
                
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }

    }
}

