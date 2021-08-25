
using System;
using System.IO;
using System.Net.Sockets;
namespace TradeTCPClientAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            //Trade d = new Trade();

            TcpClient connectionSocket = new TcpClient("127.0.0.1", 7000); // we create connection socket, it send request to the server. 

            Console.WriteLine("Welcome, please insert Sell  or Buy to get the price");

            Stream ns = connectionSocket.GetStream();// provides a stream

            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);
            sw.AutoFlush = true;// 
            string MSgFromClient = "Sell";
            sw.WriteLine(MSgFromClient);
            string totalPrice = sr.ReadLine();

            while (totalPrice != "")
            {
                Console.WriteLine("the total is" + totalPrice);
                totalPrice = sr.ReadLine();
            }
               

                
                Console.WriteLine("No more from server, press enter");
                 Console.ReadLine();

                ns.Close();
                connectionSocket.Close();
            }
        }
    }
  