﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestParkServices.Controllers
{
    public class AdoptionController : ApiController
    {
        // GET: api/Adoption
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Adoption/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Adoption
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Adoption/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Adoption/5
        public void Delete(int id)
        {
        }
    }
}
