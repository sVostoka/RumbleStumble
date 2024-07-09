using Newtonsoft.Json;

public static class JSON
{
    public static string GetJson(dynamic obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
    }

    public static dynamic GetObject<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
    }
}
