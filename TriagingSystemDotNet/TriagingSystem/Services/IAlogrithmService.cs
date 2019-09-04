using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TriagingSystem.Models;

namespace TriagingSystem.Services
{
    public interface IAlogrithmService
    {
        IEnumerable<Algorithm> getAlogrithms();
        Algorithm getAlogrithm(long id);
        IEnumerable<Algorithm> getAlogrithm(string name);
        Boolean isExist(long id);
        IEnumerable<Question> getAlgorithmQuestions(Algorithm algo);
        IEnumerable<Question> getAlgorithmQuestions(long algoID, int state);
        Question getAlgorithmQuestions(long algoID, int state, int order);
        string getFirstStep(long RID);
        string getFirstStep(Algorithm algo);
        string InstructionCare(long RID);
    }

    public class AlogrithmService : IAlogrithmService
    {
        private readonly triagingDBContext _db;
        private readonly IUserService _userService;

        public AlogrithmService(triagingDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Algorithm> getAlogrithms()
        {
            return _db.Algorithm.ToList();
        }

        public Algorithm getAlogrithm(long id)
        {
            if (isExist(id))
            {
                Algorithm[] algo = _db.Algorithm.Where(a => a.Id == id).ToArray();
                return algo[0];
            }
            else
            {
                return null;
            }

        }

        public IEnumerable<Algorithm> getAlogrithm(string name)
        {
            return _db.Algorithm.Where(a => a.Name == name).ToList();
        }

        public Boolean isExist(long id)
        {
            if (_db.Algorithm.Any(o => o.Id == id)) return true;
            return false;

        }

        public IEnumerable<Question> getAlgorithmQuestions(Algorithm algo)
        {
            return _db.Question
                 .Where(q => q.IdAlgorithem == algo.Id)
                 .ToList();
        }

        public IEnumerable<Question> getAlgorithmQuestions(long algoID, int state)
        {
            return _db.Question
                 .Where(q => (q.IdAlgorithem == algoID) && (q.State == state))
                 .OrderByDescending(q => q.QuestionOrder)
                 .ToList();
        }

        public Question getAlgorithmQuestions(long algoID, int state, int order)
        {
            return _db.Question
                 .Where(q => (q.IdAlgorithem == algoID) && (q.State == state) && (q.QuestionOrder == order))
                 .OrderByDescending(q => q.QuestionOrder)
                 .ToArray()[0];
        }

        public string getFirstStep(Algorithm algo)
        {
            if (isExist(algo.Id))
            {
                return algo.FirstStep;
            }
            else
            {
                return null;
            }
        }

        public string getFirstStep(long RID)
        {
            IEnumerable<QustionAnswer> qustionAnswers = _db.QustionAnswer
                                                         .Where(q => q.IdRecord == RID)
                                                         .ToList();


            var x = _db.QustionAnswer.ToList();
            var y = _db.QustionAnswer.Where(q => q.IdRecord == RID).ToList();
            Question algorithemQuestion = null;
            foreach (var item in qustionAnswers)
                algorithemQuestion = _db.Question
                                                        .Where(q => ((q.Id == item.IdQuestion)))
                                                        .ToArray()[0];

            Algorithm algo = getAlogrithm(algorithemQuestion.IdAlgorithem);//////////PP

            return getFirstStep(algo);

        }


        public string InstructionCare(long RID)
        {
            IEnumerable<QustionAnswer> qustionAnswers = _db.QustionAnswer
                                                         .Where(q => q.IdRecord == RID)
                                                         .ToList();
            Question algorithemQuestion = null;
            foreach (var item in qustionAnswers)
                algorithemQuestion = _db.Question
                                                        .Where(q => ((q.Id == item.IdQuestion) && (q.IdAlgorithem != 0)))
                                                        .ToArray()[0];

            int state = (int)_userService.getRecord(RID).FinalState;

            IEnumerable<InstructionCare> instructionCare = _db.InstructionCare
                                                         .Where(q => ((q.AlgorithmId == algorithemQuestion.IdAlgorithem) && (q.State == state)))
                                                        .ToList();
            string Careinstruction = instructionCare.ElementAt(0).InstructionCare1;

            return Careinstruction;

        }


    }
}
