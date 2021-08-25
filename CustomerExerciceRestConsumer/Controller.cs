using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExerciceRestConsumer
{
    class Controller
    {
        public CustomerList c = new CustomerList(); // create a reference of the class so we can call methods and properties
        private const string CustomersUri = "https://localhost:44307/customers";
        public Controller() { }
      

        public List<Customer> GetCustomers()
        {
            return c.cList;
        }

        public Customer GetOneCustomer(int id)
        {
            return c.cList.FirstOrDefault(data => data.ID == id);
        }

        public void AddCustomer(Customer newCustomer)
        {
            c.cList.Add(newCustomer);
        }

        public string[] ConvertRequestToArray(string message)
        {
            string[] array = message.Split("|");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i].Trim();
            }

            return array;
        }

        public static async Task<IList<Customer>> GetCustomersAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(CustomersUri);
                IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);
                return cList;
            }
        }

        public static async Task<Customer> GetOneCustomerAsync(int id)
        {
            string requestUri = CustomersUri + "/" + id;
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(requestUri);
                Customer c = JsonConvert.DeserializeObject<Customer>(content);
                return c;
            }
        }

        public static async Task<Customer> GetOneCustomerAsync1(int id)
        {
            string requestUri = CustomersUri + "/" + id;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(requestUri);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("Customer not found. Try another id");

                }
                response.EnsureSuccessStatusCode();
                string str = await response.Content.ReadAsStringAsync();
                Customer c = JsonConvert.DeserializeObject<Customer>(str);
                return c;
            }
        }
        public static async Task<Customer> DeleteOneCustomerAsync(int id)
        {
            string requestUri = CustomersUri + "/" + id;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(requestUri);
                Console.WriteLine("Statuscode" + response.StatusCode);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("Customer not found or customer is persistent. Try another id");

                }
                response.EnsureSuccessStatusCode();
                string str = await response.Content.ReadAsStringAsync();
                Customer deletedCustomer = JsonConvert.DeserializeObject<Customer>(str);
                return deletedCustomer;

            }
        }


        public static async Task<Customer> AddCustomerAsync(Customer newCustomer)
        {
            using (HttpClient client = new HttpClient())
            {

                var jsonString = JsonConvert.SerializeObject(newCustomer);
                Console.WriteLine("JSON: " + jsonString);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(CustomersUri, content);
                if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    throw new Exception("Customer already exists. Try another id");
                }
                response.EnsureSuccessStatusCode();
                string str = await response.Content.ReadAsStringAsync();
                Customer copyOfNewCustomer = JsonConvert.DeserializeObject<Customer>(str);
                return copyOfNewCustomer;
            }

        }

        public static async Task<Customer> UpdateCustomerAsync(Customer newCustomer, int id)
        {


            using (HttpClient client = new HttpClient())
            {
                string requestUri = CustomersUri + "/" + id;
                var jsonString = JsonConvert.SerializeObject(newCustomer);
                Console.WriteLine("JSON: " + jsonString);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(requestUri, content);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("Customer not found. Try another id");
                }
                //response.EnsureSuccessStatusCode();
                string str = await response.Content.ReadAsStringAsync();
                Customer updCustomer = JsonConvert.DeserializeObject<Customer>(str);
                return updCustomer;
            }

        }
        public static async Task<string> printTest()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(CustomersUri);
                IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);

                for (int i = 0; i < cList.Count; i++)
                    Console.WriteLine(cList[i].ToString());
                Console.WriteLine();
            }

            return null;


        }
    }
}
