using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Leilao.Application.Controllers.v1
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        // GET: api/<PublicSaleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PublicSaleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PublicSaleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PublicSaleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PublicSaleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
