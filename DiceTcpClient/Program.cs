using DiceLib;
using System;
using System.IO;
using System.Net.Sockets;

namespace DiceTcpClient
{
    class Program
    {
    //    private static TcpClient _clientSocket;
    //    private static Stream _nstream;
    //    private static StreamWriter _streamWriter;
    //    private static StreamReader _streamReader;
        static void Main(string[] args)
        {
            DiceRoll d = new DiceRoll();
            // Server IP  - we use here always server IP address
            // Server port 
            // 127.0.0.1 -- client and server are on the same machine, or we can have localhost

            TcpClient connectionSocket = new TcpClient("127.0.0.1", 7000);

            Console.WriteLine("Insert the number of dices you want to use 1 or 2 ");

            Stream ns = connectionSocket.GetStream();

        StreamWriter sw = new StreamWriter(ns);
        StreamReader sr = new StreamReader(ns);
        sw.AutoFlush = true;
        // Insert first Message here 
      

               while (true)
            {
                var message = Console.ReadLine();
                sw.WriteLine(message);
                Console.WriteLine("Insert your guess");

                var message1 = Console.ReadLine();
                sw.WriteLine(message1);
                Console.WriteLine("Please wait for the right answer");

                int messageInt = Int32.Parse(message);
                int message1Int = Int32.Parse(message1);

                var guessResult = d.GuessResult(messageInt,message1Int);
                Console.WriteLine(guessResult);

                
                var answer = sr.ReadLine();
               
            }

          
        } 
      
    }
 }



