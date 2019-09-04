using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TriagingSystem.Models;
using TriagingSystem.Services;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriagingSystem.Controllers
{
    [Route("api/[controller]")]
    public class userController : Controller
    {

        private readonly triagingDBContext _db;
        private readonly IUserService _IUserService;
        private readonly IAlogrithmService _IAlogrithmService;
        private readonly Login login;

        public userController(IUserService userService, triagingDBContext db, IAlogrithmService alogrithmService)
        {
            _db = db;
            _IUserService = userService;
            _IAlogrithmService = alogrithmService;

        }

        // GET: api/Todo
        [HttpGet("getAllUsers")]
        public async Task<ActionResult<UserInfo>> getAllUsers()
        {
            return Ok(_IUserService.getAllUsers());
        }

        // to get user information for specific user
        [HttpGet("getuser/{id}")]
        public async Task<ActionResult<UserInfo>> getUser(long id)
        {
            return Ok(_IUserService.getUser(id));
        }

        // to get Age for user
        [HttpGet("getAge/{id}")]
        public async Task<ActionResult<UserInfo>> getAge(long id)
        {
            return Ok(_IUserService.getAge(id));
        }

        // to get FirstStep using id of record
        [HttpGet("getFirstStep/{id}")]
        public async Task<ActionResult<UserRecord>> getFirstStep(long id)
        {

            try
            {
                var x = _IAlogrithmService.getFirstStep(id);
                return Ok(x);


            }
            catch (Exception e)
            {
                var asd = e;
                return Ok();
            }

        }



        /* 0000000000000 */

        // to get all record for specific user
        [HttpGet("getUserRecord/{id}")]
        public async Task<ActionResult<UserInfo>> getUserRecord(long id)
        {
            return Ok(_IUserService.getUserRecord(id));
        }


        // to get all trust contact for specific user 
        [HttpGet("getTrustedContact/{id}")]
        public async Task<ActionResult<UserInfo>> getTrustedContact(long id)
        {
            return Ok(_IUserService.getTrustedContact(id));
        }


        // POST api/<controller>
        [HttpPost("PostuserInfo")]
        public async Task<ActionResult<UserInfo>> PostuserInfo([FromBody]UserInfo userInfo)
        {
            _db.UserInfo.Add(userInfo);
            await _db.SaveChangesAsync();

            return Ok();
        }

        // to get id for user how regester in Log In
        [HttpPost("regester")]
        public UserInfo getid([FromBody] Login login)
        {
            var user = _db.UserInfo.Where(_ => (_.Email == login.Email) && (_.Password == login.Password)).FirstOrDefault();
            if (user == null) return null;

            return user;

        }

        // POST api/<controller>
        [HttpPost("PosttrustedContact")]
        public async Task<ActionResult<TrustedContact>> PosttrustedContact([FromBody]TrustedContact trustedContact)
        {
            
            _db.TrustedContact.Add(trustedContact);

            await _db.SaveChangesAsync();

            return Ok();
        }

        // POST api/<controller>
        [HttpPost("PostUserRecord")]
        public async Task<long> PostUserRecord([FromBody]UserRecord userRecord)
        {

            var xx = _db.UserRecord.ToList();
            _db.UserRecord.Add(userRecord);


            await _db.SaveChangesAsync();

            return userRecord.Id; ;
        }



        // PUT api/<controller>/5
        [HttpPut("PutuserInfo/{id}")]
        public async Task<IActionResult> PutuserInfo(long id, [FromBody] UserInfo userInfo)
        {
            if (id != userInfo.Id)
            {
                return BadRequest();
            }
            _db.Entry(userInfo).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("PuttrustedContact/{id}")]
        public async Task<IActionResult> PuttrustedContact(long id, [FromBody] TrustedContact trustedContact)
        {
            if (id != trustedContact.Id)
            {
                return BadRequest();
            }
            _db.Entry(trustedContact).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return Ok();
        }


        // DELETE  user if exist 
        [HttpDelete("DeletetrustedContact/{id}")]
        public string DeletetrustedContact(long id)
        {

            TrustedContact trustedContact = _db.TrustedContact.Find(id);


            _db.TrustedContact.Remove(trustedContact);

            _db.SaveChanges();

            return "OK";
            //var trustedContact = _db.TrustedContact.Where(_ => _.Id == id).FirstOrDefault();
            //if (trustedContact == null) return NotFound();
            //_db.TrustedContact.Remove(trustedContact);
            //_db.SaveChanges();
            //return Ok();
        }


        // DELETE  user if exist ???
        [HttpDelete("Deleteuser/{id}")]
        public async Task<IActionResult> Deleteuser(long id)
        {
            var user = _db.UserInfo.Where(_ => _.Id == id).FirstOrDefault();
            if (user == null) return NotFound();
            _db.UserInfo.Remove(user);
            _db.SaveChanges();
            return Ok();
        }



    }
}
