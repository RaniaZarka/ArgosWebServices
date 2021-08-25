using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HopClassLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HopWebAppApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Hops : ControllerBase
    {

        // GET: Hops
        [HttpGet]
        public IEnumerable<Hop> GetAll()
        {
            return HopList.hopList.OrderByDescending(o => o.AlphaAcid);
        }

        // GET: Hops/5
        [HttpGet("{id}", Name = "Get")]
        public Hop GetById(int id)
        {
            return HopList.hopList.FirstOrDefault(x => x.ID == id);
        }

        // POST: Hops
        [HttpPost]
        public IActionResult AddHop([FromBody] Hop value)
        {

            Hop h = GetHop(value.ID);
            if (h != null)
            {
                //Hop newHope = new Hop(GetId(), value.Name, value.Harvestyear, value.Price, value.AlphaAcid, value.Stock);
                // Hop newHop = new Hop() {ID= GetId(), Name = value.Name, AlphaAcid = value.AlphaAcid, Harvestyear = value.Harvestyear, Price = value.Price, Stock = value.Stock };
                return NotFound(new { message = "something went wrong " });

            }
            else
                HopList.hopList.Add(value);
            return CreatedAtAction("Get", new { id = GetId() }, value);
            
        }

       

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Hop h = GetHop(id);
           
            if (h != null )
            {
                HopList.hopList.Remove(h);
                return true;
            }
            else 
                return false;
        }
        public Hop GetHop(int id)
        {
            var p = HopList.hopList.FirstOrDefault(e => e.ID == id);
            return p;
        }
        int GetId()
        {
            int max = HopList.hopList.Max(x => x.ID);
            return max + 1;
        }
    }
}
