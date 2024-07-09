using Newtonsoft.Json;

public class GeneralSettings : IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new GeneralSettings(
            Constants.GeneralSettings.GENERALDEFAULTSENSITIVITY,
            Constants.GeneralSettings.GENERALDEFAULTACCELERATION,
            Constants.GeneralSettings.GENERALDEFAULTSQUAT,
            Constants.GeneralSettings.GENERALDEFAULTINVERTY
        );

    public float Sensitivity { get; set; }
    public int Acceleration { get; set; }
    public int Squat { get; set; }
    public int InvertY { get; set; }

    public GeneralSettings() { }

    public GeneralSettings(float sensitivity, int acceleration, int squat, int invertY)
    {
        Sensitivity = sensitivity;
        Acceleration = acceleration;
        Squat = squat;
        InvertY = invertY;
    }

    public string GetKey()
    {
        return Constants.GeneralSettings.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.GeneralSettings.PREFSDEFAULTVALUE;
    }
}