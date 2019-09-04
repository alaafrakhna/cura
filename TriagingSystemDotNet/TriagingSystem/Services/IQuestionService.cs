using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriagingSystem.Models;
using TriagingSystem.Services;

namespace TriagingSystem.Services
{
    public interface IQuestionService
    {
        Question getQuestion(long Qid);
        Boolean isExist(long id);
        int getQuestionOrder(Question question);
        int getQuestionState(Question question);
        int getQuestionState(long questionID);
        int getQuestionOrder(long questionID);
        Algorithm getQuestionAlgorithm(long Qid);
    }

    public class QuestionService : IQuestionService
    {
        private readonly triagingDBContext _db;
        private readonly IAlogrithmService _algoServ;
        public QuestionService(triagingDBContext db, IAlogrithmService algoServ)
        {
            _db = db;
            _algoServ = algoServ;
        }


        public Question getQuestion(long Qid)
        {
            if (isExist(Qid))
            {
                return _db.Question.Where(a => a.Id == Qid).ToArray()[0];
            }
            else
            {
                return null;
            }

        }

        public Boolean isExist(long id)
        {
            if (_db.Question.Any(o => o.Id == id)) return true;
            return false;

        }

        public int getQuestionOrder(Question question)
        {
            return question.QuestionOrder;
        }

        public int getQuestionState(Question question)
        {
            return question.State;
        }

        public int getQuestionState(long questionID)
        {
            Question question = getQuestion(questionID);
            return question.State;
        }

        public int getQuestionOrder(long questionID)
        {
            Question question = getQuestion(questionID);
            return question.QuestionOrder;
        }

        public Algorithm getQuestionAlgorithm(long Qid) ///////////
        {
            if (isExist(Qid))
            {
                Question q = _db.Question.Where(a => a.Id == Qid).ToArray()[0];
                return _db.Algorithm.Where(a => a.Id == q.IdAlgorithem).ToArray()[0];
            }
            else
            {
                return null;
            }

        }
    }

}
