using EnvironementalData2020.Models;
using EnvironementalData2020.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnvironementalData2020.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DataController : Controller
    {
        private readonly DataServices _dataService;
        // GET: DataController
        public DataController(DataServices dataServices)
        {
            _dataService = dataServices;
        }

        [HttpGet]
        public ActionResult<List<EnvironementalData>> Get() =>
            _dataService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<EnvironementalData> Get(string id)
        {
            var data = _dataService.Get(id);

            if (data == null)
            {
                return NotFound();
            }

            return data;
        }

        [HttpPost]
        public ActionResult<EnvironementalData> Create(EnvironementalData data)
        {
            _dataService.Create(data);

            return CreatedAtRoute("GetBook", new { id = data.Id.ToString() }, data);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, EnvironementalData dataIn)
        {
            var data = _dataService.Get(id);

            if (data == null)
            {
                return NotFound();
            }

            _dataService.Update(id, dataIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var data = _dataService.Get(id);

            if (data == null)
            {
                return NotFound();
            }

            _dataService.Remove(data.Id);

            return NoContent();
        }
    }
}