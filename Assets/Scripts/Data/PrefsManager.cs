using UnityEngine;

public class PrefsManager
{
    public static T GetData<T>(T obj = null) where T : class, IDatable, new()
    {
        T defaultObj;

        if (obj == null)
        {
            obj = new();
            defaultObj = obj.Default;
        }
        else
        {
            defaultObj = obj;
        }
        string result = PlayerPrefs.GetString(obj.GetKey(), obj.GetDefault());
        return (result == obj.GetDefault()) ? defaultObj : JSON.GetObject<T>(result);
    }

    public static bool SetData<T>(T obj) where T : IDatable
    {
        try
        {
            PlayerPrefs.SetString(obj.GetKey(), JSON.GetJson(obj));
            return true;
        }
        catch
        {
            return false;
        }
    }
}