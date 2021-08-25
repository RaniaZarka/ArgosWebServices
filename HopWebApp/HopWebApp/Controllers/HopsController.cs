using HopClassLib;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HopWebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HopsController : ControllerBase
    {


        // GET: <ValuesController>
        [HttpGet]
        public IEnumerable<Hop> GetAll()
        {
            return HopList.hopList;
        }

        // GET <ValuesController>/5
        [HttpGet("{id}")]
        public Hop GetById(int id)
        {
            return HopList.hopList.FirstOrDefault(x => x.ID == id);
        }

       // POST<ValuesController>
       [HttpPost]
        public int AddHop([FromBody] Hop value)
        {
            Hop h = GetHop(value.ID);
            if (h != null)
            {
                Hop newHop = new Hop() { ID = GetId(), Name = value.Name, AlphaAcid = value.AlphaAcid, Harvestyear = value.Harvestyear, Price = value.Price };

                HopList.hopList.Add(newHop);
            }
            return value.ID;
        }



        // DELETE <ValuesController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Hop h = GetHop(id);
            if (id != null)
            {
                HopList.hopList.Remove(h);
                return true;
            }
            else return false;
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
