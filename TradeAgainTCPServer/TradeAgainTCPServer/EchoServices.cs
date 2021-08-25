using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;

namespace TradeAgainTCPServer
{
    class EchoServices
    {
        private TcpClient connectionSocket;

        public EchoServices(TcpClient connectionSocket)
        {
            // TODO: Complete member initialization
            this.connectionSocket = connectionSocket;
        }
        internal void DoIt()
        {
            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing
            string message = sr.ReadLine();
            string answer;
            while (message != null && message != "")
            {
                string readMsgFromClient = sr.ReadLine();
                Console.WriteLine("the client want to  " + readMsgFromClient);
                var total = 0;
                if (message == "Buy")
                {
                    //var total = Trade.CalculatePrice("Buy", 10000, 200, 300);
                    Console.WriteLine(total);
                }
                else if (message == "Sell")
                {
                    // var total = Trade.CalculatePrice("Sell", 10000, 200, 300);
                    Console.WriteLine(total);
                }

                sw.WriteLine(message);
                message = sr.ReadLine();

            }
            ns.Close();
            connectionSocket.Close();
        }

    }
}
