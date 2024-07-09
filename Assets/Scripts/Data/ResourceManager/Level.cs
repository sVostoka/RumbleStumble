using Newtonsoft.Json;

public class Level : IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new Level(
            Constants.Level.VALUEDEFAULTVALUE,
            Constants.Level.EXPERIENCEDEFAULTVALUE
        );

    private int _limitExp = 50;

    private int _value;
    public int Value
    {
        get => _value; 
        set => _value = value;
    }

    private int _experience;

    public int Experience
    {
        get => _experience;
        set 
        {
            if (_experience + value > _limitExp)
            {
                _experience = value - _limitExp;
                Value++;
            }
            else
            {
                _experience += value;
            }
        }
    }

    public Level() { }

    public Level(int value, int experience)
    {
        Value = value;
        Experience = experience;
    }

    public string GetKey()
    {
        return Constants.Level.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Level.PREFSDEFAULTVALUE;
    }
}