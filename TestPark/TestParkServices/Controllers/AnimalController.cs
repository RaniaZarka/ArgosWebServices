using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestParkServices.dataAccessService;
using TestParkServices.Models;

namespace TestParkServices.Controllers
{
    public class AnimalController : ApiController
    {

        AnimalsAccessService animalsService = new AnimalsAccessService();
        // GET: api/Animal
       // public IEnumerable<Animals> Get()
       // {
            //return new string[] { "value1", "value2" };
            //return animalsService.getAllAnimals();
       // }

        // GET: api/Animal/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Animal
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Animal/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Animal/5
        public void Delete(int id)
        {
        }
    }
}
