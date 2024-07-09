using Newtonsoft.Json;

public class Talents
{
    public int Level { get; set; }
}

//Увеличение здоровья
public class Health : Talents, IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new Health(
            Constants.Health.LEVELDEFAULTVALUE,
            Constants.Health.HPBOOSTDEFAULTVALUE
        );

    public int HPBoost { get; set; }

    public Health() { }

    public Health(int level, int hpBoost)
    {
        Level = level;
        HPBoost = hpBoost;
    }

    public string GetKey()
    {
        return Constants.Health.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Health.PREFSDEFAULTVALUE;
    }
}

//Увеличение скорости
public class Speed : Talents, IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new Speed(
            Constants.Speed.LEVELDEFAULTVALUE,
            Constants.Speed.SPEEDBOOSTDEFAULTVALUE
        );

    public int SpeedBoost { get; set; }   

    public Speed() { }

    public Speed(int level, int speedBoost)
    {
        Level = level;
        SpeedBoost = speedBoost;
    }

    public string GetKey()
    {
        return Constants.Speed.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Speed.PREFSDEFAULTVALUE;
    }
}

//Увеличение силы прыжка
public class Bounce : Talents, IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new Bounce(
            Constants.Bounce.LEVELDEFAULTVALUE,
            Constants.Bounce.BOUNCEBOOSTDEFAULTVALUE
        );

    public int BounceBoost { get; set; }

    public Bounce() { }

    public Bounce(int level, int bounceBoost)
    {
        Level = level;
        BounceBoost = bounceBoost;
    }

    public string GetKey()
    {
        return Constants.Bounce.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Bounce.PREFSDEFAULTVALUE;
    }
}

//Увеличение процента поглащения урона
public class Stability : Talents, IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new Stability(
            Constants.Stability.LEVELDEFAULTVALUE,
            Constants.Stability.RESISTBOOSTDEFAULTVALUE
        );

    public int ResistBoost { get; set; }

    public Stability() { }

    public Stability(int level, int resistBoost)
    {
        Level = level;
        ResistBoost = resistBoost;
    }

    public string GetKey()
    {
        return Constants.Stability.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Stability.PREFSDEFAULTVALUE;
    }
}

//Увеличение урона
public class Power : Talents, IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new Power(
            Constants.Power.LEVELDEFAULTVALUE,
            Constants.Power.DAMAGEBOOSTDEFAULTVALUE
        );

    public int DamageBoost { get; set; }

    public Power() { }

    public Power(int level, int damageBoost)
    {
        Level = level;
        DamageBoost = damageBoost;
    }

    public string GetKey()
    {
        return Constants.Power.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Power.PREFSDEFAULTVALUE;
    }
}

//Увеличение бонуса от лечения при переходе в новую комнату
public class Treatment : Talents, IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new Treatment(
         Constants.Treatment.LEVELDEFAULTVALUE,
         Constants.Treatment.TREATMENTBOOSTDEFAULTVALUE
     );

    public int TreatmentBoost { get; set; }

    public Treatment() { }

    public Treatment(int level, int treatmentBoost)
    {
        Level = level;
        TreatmentBoost = treatmentBoost;
    }

    public string GetKey()
    {
        return Constants.Treatment.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Treatment.PREFSDEFAULTVALUE;
    }
}

//Увеличение шанса полностью заблокировать урон
public class Block : Talents, IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new Block(
            Constants.Block.LEVELDEFAULTVALUE,
            Constants.Block.BLOCKCHANCEDEFAULTVALUE
        );

    public int BlockChance { get; set; }

    public Block() { }

    public Block(int level, int blockChance)
    {
        Level = level;
        BlockChance = blockChance;
    }

    public string GetKey()
    {
        return Constants.Block.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Block.PREFSDEFAULTVALUE;
    }
}

//Увеличение скорости перезарядки
public class RechargeSpeed : Talents, IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new RechargeSpeed(
            Constants.RechargeSpeed.LEVELDEFAULTVALUE,
            Constants.RechargeSpeed.RECHARGESPEEDBOOSTDEFAULTVALUE
        );

    public int RechargeSpeedBoost { get; set; }

    public RechargeSpeed() { }

    public RechargeSpeed(int level, int rechargeSpeedBoost)
    {
        Level = level;
        RechargeSpeedBoost = rechargeSpeedBoost;
    }

    public string GetKey()
    {
        return Constants.RechargeSpeed.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.RechargeSpeed.PREFSDEFAULTVALUE;
    }
}

//Увеличение количества здоровья при повышении уровня
public class Leadership : Talents, IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new Leadership(
            Constants.Leadership.LEVELDEFAULTVALUE,
            Constants.Leadership.HEALTHLEVELUPDEFAULTVALUE
        );

    public int HealthLevelUp { get; set; }

    public Leadership() { }

    public Leadership(int level, int healthLevelUp)
    {
        Level = level;
        HealthLevelUp = healthLevelUp;
    }

    public string GetKey()
    {
        return Constants.Leadership.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Leadership.PREFSDEFAULTVALUE;
    }
}

//Увеличение количества дополнительных навыков в походе
public class Glory : Talents, IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new Glory(
            Constants.Glory.LEVELDEFAULTVALUE,
            Constants.Glory.COUNTEXTRASKILLSDEFAULTVALUE
        );

    public int CountExtraSkills { get; set; }

    public Glory() { }

    public Glory(int level, int countExtraSkills)
    {
        Level = level;
        CountExtraSkills = countExtraSkills;
    }

    public string GetKey()
    {
        return Constants.Glory.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Glory.PREFSDEFAULTVALUE;
    }
}

//Увеличение заработка
public class Income : Talents, IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new Income(
            Constants.Income.LEVELDEFAULTVALUE,
            Constants.Income.INCOMEBOOSTDEFAULTVALUE
        );

    public int IncomeBoost { get; set; }

    public Income() { }

    public Income(int level, int incomeBoost)
    {
        Level = level;
        IncomeBoost = incomeBoost;
    }

    public string GetKey()
    {
        return Constants.Income.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Income.PREFSDEFAULTVALUE;
    }
}

//Увеличения количества денег оставленных после проигрыша
public class Loss : Talents, IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new Loss(
            Constants.Loss.LEVELDEFAULTVALUE,
            Constants.Loss.SAVEONLOSSDEFAULTVALUE
        );

    public int SaveOnLoss { get; set; }

    public Loss() { }

    public Loss(int level, int saveOnLoss)
    {
        Level = level;
        SaveOnLoss = saveOnLoss;
    }

    public string GetKey()
    {
        return Constants.Loss.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Loss.PREFSDEFAULTVALUE;
    }
}