using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestCustomerConsumer
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static Customer cust = new Customer();
        static string uri = "https://localhost:44333/customer";
        static void Main(string[] args)
        {
            try
            {
                RunAsync();
                Console.ReadKey();
            }
            catch (Exception ex)
            {


            }
        }
        static async void RunAsync()
        {
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Get all data from resources 
            IList<Customer> getAllList = await GetAllCustomersAsync();
            ShowObjectData(getAllList);
            Console.WriteLine("Get By Id ...............................");
            var getAllListById = await GetAllCustomersById("1");
            ShowSingleObjectData(getAllListById);
            Console.WriteLine("Add New Resource ...............................");
            Customer newCustomer = new Customer() { ID = 4, FirstName = "Jessica", LastName = "John", YearOfRegistration = 2001};
            var newResource = await AddNewResource(newCustomer);
            ShowSingleObjectData(newResource);

        }
        static async Task<IList<Customer>> GetAllCustomersAsync() // why async: to be performed intependant on other tasks. 
                                                                  //it wont wait for other tasks to be done they can all run at the same time 
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonContent = await client.GetStringAsync(uri);
                IList<Customer> cust = JsonConvert.DeserializeObject<IList<Customer>>(jsonContent);
                return cust;
            }
        }


            static async Task<Customer> GetAllCustomersById(string id)
        {
            string uriId = uri + "/" + id;
            HttpResponseMessage response = await client.GetAsync(uriId);
            if (response.StatusCode != HttpStatusCode.NotFound)
            {
                response.EnsureSuccessStatusCode();
                string jsonContent = await response.Content.ReadAsStringAsync(); // the data comes here in Json format
                var singleObj = JsonConvert.DeserializeObject<Customer>(jsonContent);// here we deserialze it 
                return singleObj; // and it will return the desirialized object 
            }
            else
            {
                throw new Exception("Customer Id is not found");
            }
        }
        static async Task<Customer> AddNewResource(Customer newCust)
        {
            var jsonContent = JsonConvert.SerializeObject(newCust);
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
        static async Task<Customer> UpdateResource(Customer cust, int id)
        {
            var jsonContent = JsonConvert.SerializeObject(cust);
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
                throw new Exception("Customer already exist, try anther Id");
            }
        }
        static async void DeleteToDoItemAsync(string id)
        {
            string uriId = uri + "/" + id;
            HttpResponseMessage response = await client.DeleteAsync(uriId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Customer not found with that Id. Try another id");
            }
            response.EnsureSuccessStatusCode();
        }

        static void ShowObjectData(IList<Customer> list)
        {
            foreach (var i in list)
            {
                Console.WriteLine(i.ID + ":" + i.FirstName + ":" + i.LastName + ":"+ i.YearOfRegistration);
            }
        }
        static void ShowSingleObjectData(Customer cust)
        {
            Console.WriteLine(cust.ID + ":" + cust.FirstName + ":" + cust.LastName + ":" +  cust.YearOfRegistration);
        }

    }
}
