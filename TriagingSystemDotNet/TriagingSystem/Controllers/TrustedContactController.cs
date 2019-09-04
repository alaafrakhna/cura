using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TriagingSystem.Models;
using TriagingSystem.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriagingSystem.Controllers
{
    [Route("api/[controller]")]
    public class TrustedContactController : Controller
    {

        private readonly triagingDBContext _db;
        private readonly IUserService _IUserService;

        public TrustedContactController(IUserService userService, triagingDBContext db)
        {
            _db = db;
            _IUserService = userService;

        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // to get all trust contact for specific user 
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> getTrustedContact(int id)
        {
            // return Ok(IUserService.getTrustedContact(id)); 0000000
            return null;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
