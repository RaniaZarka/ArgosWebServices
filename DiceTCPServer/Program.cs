using DiceLib;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiceTCPServer
{
    class Program
    {
        

        static void Main(string[] args)
        {
            DiceRoll d = new DiceRoll();
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener serverSocket = new TcpListener(ip, 7000);

            Console.WriteLine("Server started and waiting for client");
            serverSocket.Start();

            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("Server activated");

            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            while (true)
            {
                string message = sr.ReadLine();
                Console.WriteLine("Number id dices the client wants is: " + message);
                //if (message == "STOP") break;
                //string answer = Console.ReadLine();
                //sw.WriteLine(answer);


                string message1 = sr.ReadLine();
                Console.WriteLine("Number that the client has guessed: " + message1);
                //if (message == "STOP") break;

               
                string answer = Console.ReadLine();
                sw.WriteLine(answer);



            }

            //Console.WriteLine("Server stopped, press ENTER");
            //string s = Console.ReadLine();

            //ns.Close();
            //connectionSocket.Close();
            //serverSocket.Stop();

        }
    }
}

//    //try
//    //{
//    IPAddress ip = IPAddress.Parse("127.0.0.1");//  or use parse and this number so it is our own server  or we write localhost 
//    _welcomingServerSocket = new TcpListener(ip, 7000);// here we are assigning the ip and the port number it has the same as the client port number 
//                                                       // we create the welcoming socket only when we create a handshake

//    _welcomingServerSocket.Start(); // when we call start its that our client is listening here we started the server and at the end we have to stop it 
//    Console.WriteLine("server is waiting the call request of client");



//    using (_serverSocket = _welcomingServerSocket.AcceptTcpClient())
//    {

//        // TcpClient serverConnectionSocket = serverWelcomingSocket.AcceptTcpClient();
//        Console.WriteLine("Starting a new connection!");
//        //TCPService service = new TCPService(_serverSocket);

//        while (true)
//        {
//            Program p = new Program();
//            Task.Run(() => p.DoIt());

//        }

//    }
//}








