using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriagingSystem.Models;
using TriagingSystem.Services;

namespace TriagingSystem.Services
{
    public interface IKeywordService
    {
        IEnumerable<string> findAlgorithmsKeywords(long algoID);
        IEnumerable<string> findBodyPartKeywords();
        string getBodyPart(string keyword);
        string getAlgorithm(string keyword);
    }

    public class KeywordService : IKeywordService
    {
        private readonly triagingDBContext _db;

        public KeywordService(triagingDBContext db)
        {
            _db = db;
        }
        public IEnumerable<string> findAlgorithmsKeywords(long algoID) ////////////
        {
            return _db.KeywordAlgorithem
                .Where(q => q.IdAlgorithem == algoID)
                .Select(q => q.Keyword)
                .ToList();
        }

        public IEnumerable<string> findBodyPartKeywords() //////////// 888888888888
        {
            IEnumerable<string> result = _db.KeyWordBody
                                        .Select(q => q.KeyWord)
                                        .ToList();

            result = result.Select(a => a = a.Trim()).ToList();

            return result;
        }

        public string getBodyPart(string keyword)
        {
            IEnumerable<KeyWordBody> keyBody = _db.KeyWordBody
                .Where(c => c.KeyWord.Contains(keyword))
                .ToList();
            if (keyBody.Count() < 1)
                return "0";

            long id = keyBody.ElementAt(0).IdBodyPart;
            BodyPart body = getBodyPart(id);

            return body.Name;

        }

        public BodyPart getBodyPart(long id)
        {
            if (isExist(id))
            {
                BodyPart[] bodyPart = _db.BodyPart.Where(a => a.Id == id).ToArray();
                return bodyPart[0];
            }
            else
            {
                return null;
            }

        }
        public Boolean isExist(long id)
        {
            if (_db.BodyPart.Any(o => o.Id == id)) return true;
            return false;

        }

        public string getAlgorithm(string keyword)
        {
            IEnumerable<KeywordAlgorithem> keyAlgo = _db.KeywordAlgorithem
                .Where(c => c.Keyword.Equals(keyword))
                .ToList();
            if (keyAlgo.Count() < 1)
                return "0";
            IEnumerable<Algorithm> algo = _db.Algorithm
                .Where(b => b.Id.Equals(keyAlgo.ElementAt(0)))
                .ToList();
            if (algo.Count() < 1)
                return "0";
            return algo.ElementAt(0).Name;
        }
    }
}
