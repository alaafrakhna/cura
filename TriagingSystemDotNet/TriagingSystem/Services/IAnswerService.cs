using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriagingSystem.Models;
using TriagingSystem.Services;

namespace TriagingSystem.Services
{
    public interface IAnswerService
    {
        string getAnswer(QustionAnswer ans);
        Question getNextQuestion(QustionAnswer lastAns);
        void saveAnswer(QustionAnswer answer);
    }

    class AnswerService : IAnswerService
    {
        private readonly triagingDBContext _db;
        private readonly IQuestionService _quesServ;
        private readonly IAlogrithmService _algoServ;
        private readonly IKeywordService _keywordServ;

        public AnswerService(triagingDBContext db, IQuestionService quesServ, IAlogrithmService algoServ, IKeywordService keywordServ)
        {
            _db = db;
            _quesServ = quesServ;
            _algoServ = algoServ;
            _keywordServ = keywordServ;
        }


        public string getAnswer(QustionAnswer ans)
        {
            IEnumerable<string> keywords = null;

            int type = getQuastionType(ans);
            if (type == 1)
            { //yn
                keywords = "yes,no".Split(',');
                keywords = nlpService.GetSearchWords(ans.Answer, keywords);
                if (keywords.Count() < 1)
                    return "-1";
                else if (keywords.Count() > 1)
                    return "0";
                else
                    return keywords.ElementAt(0);
            }

            else if (type == 0)
            {  // first
                int order = _quesServ.getQuestionOrder(ans.IdQuestion);

                switch (order)
                {
                    case 0:
                        return getBadyPartAnswer(ans);

                    case 1:
                        keywords = "injury,illness".Split(',');
                        keywords = nlpService.GetSearchWords(ans.Answer, keywords);
                        if (keywords.Count() < 1)
                            return "-1";
                        else if (keywords.Count() > 1)
                            return "0";
                        else
                            return keywords.ElementAt(0);

                    case 2:
                        return getAlgorithmAnswer(ans);    /////// ###### ////////// 
                }

            }

            return "-1";
        }

        private string getBadyPartAnswer(QustionAnswer ans)
        {
            IEnumerable<string> allKeywords = _keywordServ.findBodyPartKeywords();
            IEnumerable<string> keywords = nlpService.GetSearchWords(ans.Answer, allKeywords);

            if (keywords.Count() < 1)
                return "-1";

            else if (keywords.Count() == 1)
            {
                return _keywordServ.getBodyPart(keywords.ElementAt(0));
            }

            else
            {
                string bodyPart = _keywordServ.getBodyPart(keywords.ElementAt(0));

                for (int i = 1; i < keywords.Count(); i++)
                {
                    if (bodyPart != _keywordServ.getBodyPart(keywords.ElementAt(i)))
                        return "0";
                }
                return bodyPart;

            }
        }

        private string getAlgorithmAnswer(QustionAnswer ans) ///////
        {

            IEnumerable<string> keywords = _keywordServ.findAlgorithmsKeywords(_quesServ.getQuestionAlgorithm(ans.IdQuestion).Id);
            keywords = nlpService.GetSearchWords(ans.Answer, keywords);
            if (keywords.Count() < 1)
                return "-1";

            else if (keywords.Count() == 1)
            {
                return _keywordServ.getAlgorithm(keywords.ElementAt(0));
            }

            else
            {
                string algo = _keywordServ.getAlgorithm(keywords.ElementAt(0));

                for (int i = 1; i < keywords.Count(); i++)
                {
                    if (algo != _keywordServ.getAlgorithm(keywords.ElementAt(i)))
                        return "0";
                }
                return algo;

            }
        }

        private Question getQuastion(QustionAnswer ans)
        {
            Question[] q = _db.Question.Where(a => a.Id == ans.IdQuestion).ToArray();

            if (q.Length > 0)
            {
                return q[0];
            }
            else
            {
                return null;
            }
        }

        private int getQuastionType(QustionAnswer ans)
        {
            Question q = getQuastion(ans);
            if (q.IdAlgorithem == 0)
                return 0;
            else
                return 1;
        }

        public Question getNextQuestion(QustionAnswer lastAns)
        {
            Question lastQuestion = getQuastion(lastAns);

            string a = getAnswer(lastAns);
            if (a == "-1")
            {
                return lastQuestion;
            }
            else if (a == "0")
            {
                return lastQuestion;
            }
            else
            {
                return getNextQuestion(lastQuestion);
            }
        }

        private Question getNextQuestion(Question lastQuestion)
        {
            int order = _quesServ.getQuestionOrder(lastQuestion);
            int state = _quesServ.getQuestionState(lastQuestion);
            Question q = _algoServ.getAlgorithmQuestions(lastQuestion.IdAlgorithem, state, order + 1);
            if (q != null)
                return q;
            q = _algoServ.getAlgorithmQuestions(lastQuestion.IdAlgorithem, state + 1, 1);
            if (q != null)
                return q;
            return null;
        }

        public void saveAnswer(QustionAnswer answer)
        {
            //  _db.QustionAnswer.Add(answer);
            //  _db.SaveChanges();
        }
    }
}
