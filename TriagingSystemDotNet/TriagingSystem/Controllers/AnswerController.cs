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
    public class AnswerController : Controller
    {
        private readonly triagingDBContext _db;
        private readonly IAnswerService _ansServ;

        public AnswerController(triagingDBContext db, IAnswerService ansServ)
        {
            _db = db;
            _ansServ = ansServ;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<QustionAnswer> Get()
        {
            return _db.QustionAnswer.ToList();
            // return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{jsonAns}")]
        public string Get(string jsonAns)
        {
            QustionAnswer questionAnswer = (QustionAnswer)JSONHelper.ToObject(jsonAns);
            questionAnswer.AnswerApproved = _ansServ.getAnswer(questionAnswer);
            //saveAnswer(ans);

            return "hh";
        }

        // POST api/<controller>
        [HttpPost]
        public Question Post([FromBody]QustionAnswer answer)
        {
            answer.AnswerApproved = _ansServ.getAnswer(answer);
            _ansServ.saveAnswer(answer);
            return _ansServ.getNextQuestion(answer);
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
