using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestParkServices.Models;

namespace TestParkConsole
{
    class Program
    {

       
        static void Main(string[] args)
        {
            getAnimals();

            Console.WriteLine("hello");
        }

        public async static Task<List<Animals>>getAnimals()
        {
            List<Animals> aList = new List<Animals>();
            string url = "http://localhost:52343/api/Animal";
            using(HttpClient client =new HttpClient())
            {
                string response = await client.GetStringAsync(url);
               aList= JsonConvert.DeserializeObject<List<Animals>>(response);

            }
            return aList;
                

        }


    }
}
