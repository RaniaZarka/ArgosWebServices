using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace CustomerExerciceRestConsumer
{
        class TCPServices
    {
        private static TcpClient _serverSocket;
        private TcpListener _welcomingSocket;
        private FileStream _fileStream;
        string uri = @"https://localhost:44307/customers";
        Controller c = new Controller();
        public TCPServices(TcpClient serverSocket, TcpListener welcomingSocket)
        {
            _serverSocket = serverSocket;
            _welcomingSocket = welcomingSocket;
        }

        public void DoIt()
        {
            using (Stream stream = _serverSocket.GetStream())

            {
                StreamReader sr = new StreamReader(stream);
                StreamWriter sw = new StreamWriter(stream);
                sw.AutoFlush = true;


                string request = sr.ReadLine();
                string response = "";

                while (!string.IsNullOrEmpty(request))
                {
                    Console.WriteLine("Client: " + request);

                    string[] messageStrings = c.ConvertRequestToArray(request);

                    switch (messageStrings[0])
                    {
                        case "getOne":
                            response = JsonSerializer.Serialize(c.GetOneCustomer(1));
                            break;
                        case "getAll":
                            response = JsonSerializer.Serialize(c.GetCustomers());
                            break;
                        case "save":
                            response = "Saved";
                            c.AddCustomer(JsonSerializer.Deserialize<Customer>(messageStrings[1]));
                            break;
                        default:
                            response = "Wrong Request";
                            break;
                    }

                    try
                    {
                        sw.WriteLine(response);
                        request = sr.ReadLine();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                        break;
                    }
                }

                Console.WriteLine("Closing Connection");
                stream.Close();
                _serverSocket.Close();
            }
        }


    }
}
