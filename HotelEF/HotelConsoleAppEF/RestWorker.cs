using HotelEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HotelConsoleAppEF
{
    class RestWorker
    {

        public static List<Hotel> Gethotel(string url)
        {
            const string serverURL = "http://localhost:51639";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (HttpClient client=new HttpClient(handler))
            {
                client.BaseAddress= new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                 client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                 try
                 {
                    var response= client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();
                   string data = response.Content.ReadAsStringAsync().Result;
                   List<Hotel> hList = JsonConvert.DeserializeObject<List<Hotel>>(data);
                   return hList;
                 }
                 catch (Exception ex)
                 {
                     return new List<Hotel>();
                 }
            }
        }

        public static List<Room> GetRoom(string url)
        {
            const string serverURL = "http://localhost:51639";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();
                    string data = response.Content.ReadAsStringAsync().Result;
                    List<Room> rList = JsonConvert.DeserializeObject<List<Room>>(data);
                    return rList;
                }
                catch (Exception ex)
                {
                    return new List<Room>();
                }
            }
        }
    }
}
