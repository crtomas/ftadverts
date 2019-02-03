using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FTAdverts.Controllers
{
    [ApiController]
    [ApiVersion( "1.0" )]
    [Route( "api/v{version:apiVersion}/[controller]" )]    
    public class FTAdvertsController : ControllerBase
    {
        // GET api/v{version}/ftadverts
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "api", "ftadverts v15" };
        }

        // GET api/v{version}/ftadverts/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/v{version}/ftadverts
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/v{version}/ftadverts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/v{version}/ftadverts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
