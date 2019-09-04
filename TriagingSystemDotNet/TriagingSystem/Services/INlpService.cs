//using LemmaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriagingSystem.Models;

namespace TriagingSystem.Services
{
    public interface INlpService
    {
        string[] getAlogrithm();
        string[] GetSearchWords(string text, IEnumerable<string> keyWords);
        string[] extractWords(string text);
        IEnumerable<string> findkeywords(IEnumerable<string> words, IEnumerable<string> keywords);
    }

    public class nlpService 
    {
        private string[] data = { "salsabel", "name" };


        public static string[] getAlogrithm()
        {
            string[] algo = Main();
            return algo;
        }

        private static string[] Main()
        {
            string[] algo = new string[3];
            /*
            string[] a = { "wrote", "injury", "illness", "break", "broken", "operate", "operating", "operates", "operation", "operative", "operatives", "operational", "Hand", "Hands", "Bone", "Bones", "Finger", "Fingers", "Phalange", "Phalanges" };
            a = lemmatizationWords(a);
            a.ToList().ForEach(Console.WriteLine);
            Console.ReadKey();
            */
            string str1 = "my leg hurt me";
            string str2 = "i think its an injury";
            string str3 = "It may be broken because I fell off the stairs";

            var bodyPart = "head,back,hand,eye,leg";
            var injury_illness = "injury,illness";
            var problem = "Burn,broken,torsion";


            var keywords = bodyPart.Split(',');
            IEnumerable<string> words = GetSearchWords(str1, keywords);
            //algo[0]= "bodyPart: ";
            //Console.Write("bodyPart: ");

            // words.ToList().ForEach(Console.WriteLine);
            if(words.Count() > 0)
            {
                algo[0] = words.ElementAt(0);
            }
                        
            keywords = injury_illness.Split(',');
            words = GetSearchWords(str2, keywords);
            //Console.Write("injury_illness: ");
            // words.ToList().ForEach(Console.WriteLine);

            algo[1] = words.ElementAt(0);

            keywords = problem.Split(',');
            words = GetSearchWords(str3, keywords);
            // Console.Write("problem: ");
            // words.ToList().ForEach(Console.WriteLine);
            algo[2] = words.ElementAt(0);

            return algo;
        }

        public static IEnumerable<string> GetSearchWords(string text, IEnumerable<string> keyWords)
        {
            string[] extract = extractWords(text);
            //return extract.Intersect(keyWords);

            keyWords.ElementAt(0).Trim();
            return extract.Where(word => keyWords.Contains(word.Trim()));
        }

        public static IEnumerable<string> GetSearchWords(IEnumerable<string> words, IEnumerable<string> keywords)
        {
           return words.Intersect(keywords);
        }

        public static string[] extractWords(string text)
        {
            var words = text.Split();

            string[] keywords = removeStopWords(words);
            //keywords = EnglishStemmer(keywords);
            //keywords = lemmatizationWords(keywords);

            return keywords;
        }

        /// <summary>
        /// Converts single word to lowercase and lemmatizes
        /// </summary>
        /// <param name="word"></param>
        /// <param name="lemmatizer"></param>
        /// <returns></returns>
        //private static string[] lemmatizationWords(string[] words)
        //{
        //    string[] result = new string[words.Length];

        //    ILemmatizer lemmatizer = new LemmatizerPrebuiltCompact(LemmaSharp.LanguagePrebuilt.English);

        //    for (int i = 0; i < words.Length; i++)
        //    {
        //        result[i] = lemmatizer.Lemmatize(words[i].ToLower().Trim()).Trim();
        //    }

        //    return result;
        //}


        private static string[] removeStopWords(string[] words)
        {
            /* OR:
             * 
             * static string[] removeStopWords(string text)
             * var words = text.Split();
             */


            List<string> stopWords = new List<string>()
            {
                "a",
                "able",
                "about",
                "above",
                "according",
                "accordingly",
                "across",
                "actually",
                "after",
                "afterwards",
                "again",
                "against",
                "ain't",
                "all",
                "allow",
                "allows",
                "almost",
                "alone",
                "along",
                "already",
                "also",
                "although",
                "always",
                "am",
                "among",
                "amongst",
                "an",
                "and",
                "another",
                "any",
                "anybody",
                "anyhow",
                "anyone",
                "anything",
                "anyway",
                "anyways",
                "anywhere",
                "apart",
                "appear",
                "appreciate",
                "appropriate",
                "are",
                "aren't",
                "around",
                "as",
                "a's",
                "aside",
                "ask",
                "asking",
                "associated",
                "at",
                "available",
                "away",
                "awfully",
                "be",
                "became",
                "because",
                "become",
                "becomes",
                "becoming",
                "been",
                "before",
                "beforehand",
                "behind",
                "being",
                "believe",
                "below",
                "beside",
                "besides",
                "best",
                "better",
                "between",
                "beyond",
                "both",
                "brief",
                "but",
                "by",
                "came",
                "can",
                "cannot",
                "cant",
                "can't",
                "cause",
                "causes",
                "certain",
                "certainly",
                "changes",
                "clearly",
                "c'mon",
                "co",
                "com",
                "come",
                "comes",
                "concerning",
                "consequently",
                "consider",
                "considering",
                "contain",
                "containing",
                "contains",
                "corresponding",
                "could",
                "couldn't",
                "course",
                "c's",
                "currently",
                "definitely",
                "described",
                "despite",
                "did",
                "didn't",
                "different",
                "do",
                "does",
                "doesn't",
                "doing",
                "done",
                "don't",
                "down",
                "downwards",
                "during",
                "each",
                "edu",
                "eg",
                "eight",
                "either",
                "else",
                "elsewhere",
                "enough",
                "entirely",
                "especially",
                "et",
                "etc",
                "even",
                "ever",
                "every",
                "everybody",
                "everyone",
                "everything",
                "everywhere",
                "ex",
                "exactly",
                "example",
                "except",
                "far",
                "few",
                "fifth",
                "first",
                "five",
                "followed",
                "following",
                "follows",
                "for",
                "former",
                "formerly",
                "forth",
                "four",
                "from",
                "further",
                "furthermore",
                "get",
                "gets",
                "getting",
                "given",
                "gives",
                "go",
                "goes",
                "going",
                "gone",
                "got",
                "gotten",
                "greetings",
                "had",
                "hadn't",
                "happens",
                "hardly",
                "has",
                "hasn't",
                "have",
                "haven't",
                "having",
                "he",
                "he'd",
                "he'll",
                "hello",
                "help",
                "hence",
                "her",
                "here",
                "hereafter",
                "hereby",
                "herein",
                "here's",
                "hereupon",
                "hers",
                "herself",
                "he's",
                "hi",
                "him",
                "himself",
                "his",
                "hither",
                "hopefully",
                "how",
                "howbeit",
                "however",
                "how's",
                "i",
                "i'd",
                "ie",
                "if",
                "ignored",
                "i'll",
                "i'm",
                "immediate",
                "in",
                "inasmuch",
                "inc",
                "indeed",
                "indicate",
                "indicated",
                "indicates",
                "inner",
                "insofar",
                "instead",
                "into",
                "inward",
                "is",
                "isn't",
                "it",
                "it'd",
                "it'll",
                "its",
                "it's",
                "itself",
                "i've",
                "just",
                "keep",
                "keeps",
                "kept",
                "know",
                "known",
                "knows",
                "last",
                "lately",
                "later",
                "latter",
                "latterly",
                "least",
                "less",
                "lest",
                "let",
                "let's",
                "like",
                "liked",
                "likely",
                "little",
                "look",
                "looking",
                "looks",
                "ltd",
                "mainly",
                "many",
                "may",
                "maybe",
                "me",
                "mean",
                "meanwhile",
                "merely",
                "might",
                "more",
                "moreover",
                "most",
                "mostly",
                "much",
                "must",
                "mustn't",
                "my",
                "myself",
                "name",
                "namely",
                "nd",
                "near",
                "nearly",
                "necessary",
                "need",
                "needs",
                "neither",
                "never",
                "nevertheless",
                "new",
                "next",
                "nine",
                "no",
                "nobody",
                "non",
                "none",
                "noone",
                "nor",
                "normally",
                "not",
                "nothing",
                "novel",
                "now",
                "nowhere",
                "obviously",
                "of",
                "off",
                "often",
                "oh",
                "ok",
                "okay",
                "old",
                "on",
                "once",
                "one",
                "ones",
                "only",
                "onto",
                "or",
                "other",
                "others",
                "otherwise",
                "ought",
                "our",
                "ours",
                "ourselves",
                "out",
                "outside",
                "over",
                "overall",
                "own",
                "particular",
                "particularly",
                "per",
                "perhaps",
                "placed",
                "please",
                "plus",
                "possible",
                "presumably",
                "probably",
                "provides",
                "que",
                "quite",
                "qv",
                "rather",
                "rd",
                "re",
                "really",
                "reasonably",
                "regarding",
                "regardless",
                "regards",
                "relatively",
                "respectively",
                "right",
                "said",
                "same",
                "saw",
                "say",
                "saying",
                "says",
                "second",
                "secondly",
                "see",
                "seeing",
                "seem",
                "seemed",
                "seeming",
                "seems",
                "seen",
                "self",
                "selves",
                "sensible",
                "sent",
                "serious",
                "seriously",
                "seven",
                "several",
                "shall",
                "shan't",
                "she",
                "she'd",
                "she'll",
                "she's",
                "should",
                "shouldn't",
                "since",
                "six",
                "so",
                "some",
                "somebody",
                "somehow",
                "someone",
                "something",
                "sometime",
                "sometimes",
                "somewhat",
                "somewhere",
                "soon",
                "sorry",
                "specified",
                "specify",
                "specifying",
                "still",
                "sub",
                "such",
                "sup",
                "sure",
                "take",
                "taken",
                "tell",
                "tends",
                "th",
                "than",
                "thank",
                "thanks",
                "thanx",
                "that",
                "thats",
                "that's",
                "the",
                "their",
                "theirs",
                "them",
                "themselves",
                "then",
                "thence",
                "there",
                "thereafter",
                "thereby",
                "therefore",
                "therein",
                "theres",
                "there's",
                "thereupon",
                "these",
                "they",
                "they'd",
                "they'll",
                "they're",
                "they've",
                "think",
                "third",
                "this",
                "thorough",
                "thoroughly",
                "those",
                "though",
                "three",
                "through",
                "throughout",
                "thru",
                "thus",
                "to",
                "together",
                "too",
                "took",
                "toward",
                "towards",
                "tried",
                "tries",
                "truly",
                "try",
                "trying",
                "t's",
                "twice",
                "two",
                "un",
                "under",
                "unfortunately",
                "unless",
                "unlikely",
                "until",
                "unto",
                "up",
                "upon",
                "us",
                "use",
                "used",
                "useful",
                "uses",
                "using",
                "usually",
                "value",
                "various",
                "very",
                "via",
                "viz",
                "vs",
                "want",
                "wants",
                "was",
                "wasn't",
                "way",
                "we",
                "we'd",
                "welcome",
                "well",
                "we'll",
                "went",
                "were",
                "we're",
                "weren't",
                "we've",
                "what",
                "whatever",
                "what's",
                "when",
                "whence",
                "whenever",
                "when's",
                "where",
                "whereafter",
                "whereas",
                "whereby",
                "wherein",
                "where's",
                "whereupon",
                "wherever",
                "whether",
                "which",
                "while",
                "whither",
                "who",
                "whoever",
                "whole",
                "whom",
                "who's",
                "whose",
                "why",
                "why's",
                "will",
                "willing",
                "wish",
                "with",
                "within",
                "without",
                "wonder",
                "won't",
                "would",
                "wouldn't",
                "yes",
                "yet",
                "you",
                "you'd",
                "you'll",
                "your",
                "you're",
                "yours",
                "yourself",
                "yourselves",
                "you've",
                "zero"
            };

            return words.Where(word => !stopWords.Contains(word)).ToArray();
        }


    }

}

