using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestCustomerServicesAssignment.Model;

namespace RestCustomerServicesAssignment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private List<Customer> _cList;
        public CustomerController()
        {
            _cList = CustomerList.cList;
        }

  // GET: api/Customer
  [HttpGet]
        public List<Customer> Get()
        {
            return _cList; ;
        }


        // GET: api/Customer/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = GetCustomer(id);
            if(customer != null)
            {
                return Ok(customer);
            }
            else 
            {
                return NotFound(new { message = " ID does not exist" });
            }
        }

        // POST: api/Customer
        [HttpPost]
        public IActionResult Post([FromBody] Customer newCustomer)
        {
            _cList.Add(newCustomer);
            return CreatedAtAction("Get", new { id = newCustomer.ID }, newCustomer);
        }
   
        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer UpdateCustomer)
        {
            if(id != UpdateCustomer.ID)
            {
                return BadRequest();
            }
            var currentCustomer = GetCustomer(id);

            if (currentCustomer != null )
            {
                currentCustomer.FirstName = UpdateCustomer.FirstName;
                currentCustomer.LastName = UpdateCustomer.LastName;
                currentCustomer.YearOfRegistration = UpdateCustomer.YearOfRegistration;
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
            var customer = GetCustomer( id);
            if(customer != null)
            {
                _cList.Remove(customer);
            }
            else
            {
                return NotFound();
            }
            return Ok(customer);
        }

        public Customer GetCustomer(int id)
        {
            var customer = _cList.FirstOrDefault(e => e.ID == id);
            return customer;
        }
    }
}
