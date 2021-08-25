using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
 

namespace ParkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            getAnimals();
            Console.ReadKey();
        }


        
        public async static Task <List<Animals>> getAnimals()
        {
            string url = "http://localhost:52343/api/Animal";
            using( HttpClient  client = new HttpClient())
            {
                string resonse = await client.GetStringAsync(url);
                
            }

            return null; 
        }
    }
}
