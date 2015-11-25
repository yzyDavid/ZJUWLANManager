using System;
using System.Collections.Generic;
using Windows.Data.Json;
using Windows.UI.Notifications;

namespace ZJUWLANManager
{
    public static class Extensions
    {
        public static JsonArray ToJsonArray(this IList<string> list)
        {
            var ja = new JsonArray();
            foreach (var str in list)
            {
                var jv = JsonValue.CreateStringValue(str);
                ja.Add(jv);
            }
            return ja;
        }

        public static JsonArray ToJsonArray(this IList<Account> list)
        {
            var ja = new JsonArray();
            foreach (var acc in list)
            {
                var jo = new JsonObject();
                jo.Add("Username", JsonValue.CreateStringValue(acc.Username));
                jo.Add("Password", JsonValue.CreateStringValue(acc.Password));
                ja.Add(jo);
            }
            return ja;
        }

        public static void FromJsonArray(this IList<Account> list, JsonArray ja)
        {
            var nl = new List<Account>();
            foreach (var jo in ja)
            {
                var acc = new Account();
                IJsonValue value;
                if (!jo.GetObject().TryGetValue("UserName", out value))
                    throw new MissingFieldException("Json content disagree");
                acc.Username = value.GetString();
                if (!jo.GetObject().TryGetValue("Password", out value))
                    throw new MissingFieldException("Json content disagree");
                acc.Password = value.GetString();
                nl.Add(acc);
            }
            list = nl;
        }

        //        public static void afds()
        //        {
        //            var a = new List<string> {"a", "b"};
        //            var ja = a.ToJsonArray();
        //        }
    }
}
