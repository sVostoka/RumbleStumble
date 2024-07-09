using Newtonsoft.Json;

public class GraphicSettings : IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new GraphicSettings(
            Constants.GraphicSettings.GRAPHICDEFAULTBRIGHTNESS,
            Constants.GraphicSettings.GRAPHICDEFAULTRESOLUTION,
            Constants.GraphicSettings.GRAPHICDEFAULTMODE,
            Constants.GraphicSettings.GRAPHICDEFAULTTEXTURES,
            Constants.GraphicSettings.GRAPHICDEFAULTSHADOWS,
            Constants.GraphicSettings.GRAPHICDEFAULTEFFECTS,
            Constants.GraphicSettings.GRAPHICDEFAULTLIGHTING
        );

    public float Brightness { get; set; }
    public int Resolution { get; set; }
    public int Mode { get; set; }

    public int Textures { get; set; }
    public int Shadows { get; set; }
    public int Effects { get; set; }
    public int Lighting { get; set; }    

    public GraphicSettings() { }

    public GraphicSettings(float brightness, int resolution, int mode, int textures, int shadows, int effects, int lighting)
    {
        Brightness = brightness;
        Resolution = resolution;
        Mode = mode;

        Textures = textures;
        Shadows = shadows;
        Effects = effects;
        Lighting = lighting;
    }

    public string GetKey()
    {
        return Constants.GraphicSettings.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.GraphicSettings.PREFSDEFAULTVALUE;
    }
}