using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Diploma_Zayats.Utilities.Helpers;

public class JsonHelper
{
    public static JObject FromJson(string json)
    {
        return JsonConvert.DeserializeObject<JObject>(json);
    }
}