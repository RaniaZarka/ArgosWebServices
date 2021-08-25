using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HotelEF;
using Newtonsoft.Json;

namespace HotelConsoleAppEF
{
    class GenericHotelTest<T> where T:class, new()
    {
        private HttpClientHandler handler;
        private HttpClient client;
        private string _url;
        public GenericHotelTest(string serverURL, string url)
        { 
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            client = new HttpClient(handler);
            client.BaseAddress = new Uri(serverURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _url = url;
        }

        public async  Task <List<T>> GetAll()
        {
            using ( client)
            {
                try
                {
                    var response = await client.GetAsync(_url);
                    response.EnsureSuccessStatusCode();
                    string data = response.Content.ReadAsStringAsync().Result;
                    List<T> list = JsonConvert.DeserializeObject<List<T>>(data);
                    return list;
                }
                catch (Exception ex)
                {
                    return new List<T>();
                }
            }
            
        }

        public async  void createOne(T obj)
        {
            using(client)
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8,"application/json");
                var response = await client.PostAsync(_url, content);
                response.EnsureSuccessStatusCode();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async  Task<T> deleteOne(int id)
        {
            using (client)
                try
                {
                    string newURL = _url + "/" + id;
                    var response = await client.DeleteAsync(newURL);
                    response.EnsureSuccessStatusCode();
                    string data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<T>(data);

                }
                catch (Exception ex)
                {
                    return new T();
                }
        }

        public async void updateOne(int id, T obj)
        {
            using (client)
                try
                {
                    string newURL = _url + "/" + id;
                    string data = JsonConvert.SerializeObject(obj);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(newURL, content);
                    response.EnsureSuccessStatusCode();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

        }

    }
}

