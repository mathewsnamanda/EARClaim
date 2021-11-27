using EAR_CLAIM.Models;
using EAR_CLAIM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EAR_CLAIM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ValuesController(IConfiguration Configuration)
        {
            _configuration = Configuration ?? throw new ArgumentNullException(nameof(Configuration));
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromQuery] Class value)
        {
            
            if (ModelState.IsValid)
            {
                string MfilesUrl = this._configuration.GetConnectionString("ClaimsUrl");

                Interface interfac = new Class1();
                var test = interfac.Name(value,MfilesUrl);

                return Ok(test);
            }
            return Ok("");
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
