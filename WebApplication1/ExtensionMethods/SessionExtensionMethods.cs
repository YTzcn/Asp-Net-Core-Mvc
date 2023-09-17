using Microsoft.JSInterop.Implementation;
using Newtonsoft.Json;

namespace WebApplication1.ExtensionMethods
{
    public static class SessionExtensionMethods
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string objString = JsonConvert.SerializeObject(value);
            session.SetString(key, objString);
        }
        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string str = session.GetString(key);
            if (string.IsNullOrEmpty(str))
            {
                return null; 
            }
            
            T Valuee = JsonConvert.DeserializeObject<T>(str);
            return Valuee;
        }

    }
}

