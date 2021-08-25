using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Katerina.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Foods : ControllerBase
    {

        public static List<Food> theList = new List<Food>()
        {
       new Food(1, "CornFlex", 5, 5),
       new Food(2, "Cola", 15,10 ),
       new Food(3, "Milk, lowFat", 12, 15),
       new Food(4, "Chocolate", 7,5 ),
       new Food(5, "cookie", 5, 10),
       new Food(6, "beer", 14, 10)
           
        };
        // GET: Food
        [HttpGet]
        public IEnumerable<Food> Get()
        {
            return theList;
        }

        // GET: Food
        [HttpGet("BySubstring", Name ="GetBySubstring")]

        public IEnumerable<Food> GetBySubstringOfName(String substring)
        {
            substring = ",";

            List<Food> substringList = theList.FindAll(e => e.Name.Contains(substring));
 
            return substringList;
            

        }
        // GET: Food
        [HttpGet("ByName/{name}", Name = "GetByName")]
        public IEnumerable<Food> GetByName(String name)
        {
            List<Food> nameList = new List<Food>();

            var f = ByName(name);
            nameList.Add(f);
            return nameList;
        }

        // GET: Food
        [HttpGet("ByPurchase", Name = "GetByPurchase")]

        public IEnumerable<Food> GetPurchases()
        {         
          List<Food> purchaseList = theList.FindAll(e => e.InStock < e.LowLevel);
                                 
         return purchaseList;

        }






        // GET: api/Food/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Food
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Food/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        public Food ByName(string name)
        {
            var f = theList.FirstOrDefault(e => e.Name == name);
            return f;
        }

    }
}
