using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatingApp.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.Api.Controllers
{
    [Authorize]//everything in this has to be authorized request
    //[Route("api/[controller]")]
    [Route("api/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context = null;

        public ValuesController(DataContext context)
        {
            this._context = context;
        }

        // GET api/values
        [HttpGet]
        [ActionName("GetAll")]
        public ActionResult<IEnumerable<string>> Get()
        {
            //throw new Exception("1");
            return new string[] { "value1", "value3" };
        }

           // GET api/values
        [HttpGet]
        [ActionName("GetAll2")]
        public async Task<IActionResult> GetAll2()
        {
           var values = await _context.Values.ToListAsync();
           return Ok(values);
        }

        [AllowAnonymous]//no need for token
        // GET api/values/5
        [HttpGet("{id}")]
        [ActionName("GetByID")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

          // GET api/values/5
        [HttpGet("{id}")]
        [ActionName("GetByID2")]
        public async Task<IActionResult> GetByID2(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
