using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TriagingSystem.Services
{
    public interface IJSONHelper
    {
        string ToJSON(object obj);
        object ToObject(string jsonData);
    }

    public class JSONHelper 
    {
        public static string ToJSON(object obj)
        {
            string output = JsonConvert.SerializeObject(obj);
            return output;
        }

        public static object ToObject(string jsonData)
        {
                  
            return JsonConvert.DeserializeObject<object>(jsonData);
        }

    }
}
