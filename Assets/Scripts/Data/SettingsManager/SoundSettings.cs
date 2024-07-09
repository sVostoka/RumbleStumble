using Newtonsoft.Json;
using System;
using UnityEngine;

public class SoundSettings : IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new SoundSettings(
            Constants.SoundSettings.SOUNDOVERALLVOLUME,
            Constants.SoundSettings.SOUNDEFFECTSVOLUME,
            Constants.SoundSettings.SOUNDMUSICVOLUME,
            Constants.SoundSettings.SOUNDINTERFACEVOLUME,
            Constants.SoundSettings.SOUNDAMBIENTVOLUME
        );

    public float OverallVolume { get; set; }
    public float EffectsVolume { get; set; }
    public float MusicVolume { get; set; }
    public float InterfaceVolume { get; set; }
    public float AmbientVolume { get; set; }

    public SoundSettings() { }

    public SoundSettings(float overallVolume, float effectsVolume, float musicVolume, float interfaceVolume, float ambientVolume)
    {
        OverallVolume = overallVolume;
        EffectsVolume = effectsVolume;
        MusicVolume = musicVolume;
        InterfaceVolume = interfaceVolume;
        AmbientVolume = ambientVolume;
    }

    public string GetKey()
    {
        return Constants.SoundSettings.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.SoundSettings.PREFSDEFAULTVALUE;
    }
}