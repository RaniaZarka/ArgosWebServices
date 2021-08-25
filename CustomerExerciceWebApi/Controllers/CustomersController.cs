using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerExerciceWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerExerciceWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public static int nextId = 0;
        private static List<Customer> cList = new List<Customer>()
        { new Customer("John", "Smith", 2000),
            new Customer("Jack", "Jones", 2002),
            new Customer( "Jessica", "Smith", 2009)

        };
        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return cList;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = GetCustomer( id);
            if(customer == null)
            {
                return NotFound(new { message = "ID not found" });
            }
            return Ok(customer);
        }

        // POST: api/Customers
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            
            if(!CustomerExists(customer.ID ))
            {
                customer.ID = nextId++;
                cList.Add(customer);
                return CreatedAtAction("Get", new { id = customer.ID }, customer);
            }
            else
            {
                return NotFound(new { message = "Id alreay exist" });
            }

        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer newCustomer)
        {
            var currentcustomer = GetCustomer(id);
            if(id!= newCustomer.ID)
            {
                return BadRequest();
            }
            else if(currentcustomer !=null )
            {
                currentcustomer.ID = newCustomer.ID;
                currentcustomer.FirstName = newCustomer.FirstName;
                currentcustomer.LastName = newCustomer.LastName;
                currentcustomer.YearOfRegistration = newCustomer.YearOfRegistration;
            }
            else
            {
                return NotFound();
            }
            return NoContent();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = GetCustomer(id);
            if( customer!=null)
            {
                cList.Remove(customer);
            }
            else
            {
                return NotFound();
            }
            return Ok(customer);
        }

        public Customer GetCustomer(int id)
        {
            var customer = cList.FirstOrDefault(c => c.ID == id);
            return customer;
        }

        public bool CustomerExists(long id)
        {
            return cList.Any(c => c.ID == id);
        }
    }
}
