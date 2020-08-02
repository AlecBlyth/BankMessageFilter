using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace NapierBankMessageFilter
{
    //Used to serialise and deserialise files 
    class JSONClass 
    {
        private static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };


        public static string JsonSerializer<T>(T t)
        {
            string jsonStr = JsonConvert.SerializeObject(t, settings); //Converts object into JSON string 
            return jsonStr;
        }

        public static T JsonDeserialize<T>(string jsonStr) //Deserialises JSON object 
        {
            T obj = JsonConvert.DeserializeObject<T>(jsonStr, settings);
            return obj;
        }
    }
}
