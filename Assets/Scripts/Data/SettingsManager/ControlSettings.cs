using Newtonsoft.Json;
using System;
using UnityEngine;

public class ControlSettings : IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new ControlSettings(
            Constants.ControlSettings.STUBDEFAULTTEST
        );

    public string Stub { get; set; }  

    public ControlSettings() { }

    public ControlSettings(string stub)
    {
        Stub = stub;
    }

    public string GetKey()
    {
        return Constants.ControlSettings.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.ControlSettings.PREFSDEFAULTVALUE;
    }
}