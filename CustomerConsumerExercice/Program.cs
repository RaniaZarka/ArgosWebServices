using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CustomerConsumerExercice
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static Customer c = new Customer();
        static string uri = "https://localhost:44307/customers";
        static void Main(string[] args)
        {
            //IList<Customer> GetAllCustomers = await GetCustomersAsync();
            //ShowAllCustomers(GetAllCustomers);
            Console.WriteLine("hello");
            Console.ReadKey();
        }

        static async void RunAsync()
        {
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<IList<Customer>> GetCustomersAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(uri);
                IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);
                return cList;
            }
        }

        public static async Task<Customer> GetCustomerById(int id)
        {

            string uriId = uri + "/" + id;
            HttpResponseMessage response = await client.GetAsync(uriId);
            if (response.StatusCode != HttpStatusCode.NotFound)
            {
                response.EnsureSuccessStatusCode();
                string jsonContent = await response.Content.ReadAsStringAsync();
                var singleObj = JsonConvert.DeserializeObject<Customer>(jsonContent);
                return singleObj;
            }
            else
            {
                throw new Exception("Customer Id is not found");
            }
        }

        public static async Task<Customer> AddNewCustomer(Customer newCustomer)
        {
            var jsonContent = JsonConvert.SerializeObject(newCustomer);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, content);
            if (response.StatusCode != HttpStatusCode.Conflict)
            {
                response.EnsureSuccessStatusCode();
                string jsonString = await response.Content.ReadAsStringAsync();
                var newlyCreatedResource = JsonConvert.DeserializeObject<Customer>(jsonString);
                return newlyCreatedResource;
            }
            else
            {
                throw new Exception("Customer already exist, try anther Id");
            }
        }

        public static async Task<Customer> UpdateResource(Customer updateOne, string id)
        {
            var jsonContent = JsonConvert.SerializeObject(updateOne);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/" + id, content);
            if (response.StatusCode != HttpStatusCode.Conflict)
            {
                response.EnsureSuccessStatusCode();
                string jsonString = await response.Content.ReadAsStringAsync();
                var newlyCreatedResource = JsonConvert.DeserializeObject<Customer>(jsonString);
                return newlyCreatedResource;
            }
            else
            {
                throw new Exception("Customer ID does not exist");
            }
        }

        static async void DeleteCustomer(string id)
        {
            string uriId = uri + "/" + id;
            HttpResponseMessage response = await client.DeleteAsync(uriId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Customer not found with that Id. Try another id");
            }
            response.EnsureSuccessStatusCode();
        }

        static void ShowAllCustomers(IList<Customer> theList)
        {
            foreach (var c in theList)
            {
                Console.WriteLine(c.ID + ":" + c.FirstName + " :" + c.LastName + ":" + c.YearOfRegistration + ":");
            }
        }

        static void ShowOneCustomer(Customer c)
        {
            Console.WriteLine(c.ID + ":" + c.FirstName + " :" + c.LastName + ":" + c.YearOfRegistration + ":");
        }
    }
}
