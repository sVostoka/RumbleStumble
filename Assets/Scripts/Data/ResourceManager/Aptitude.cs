public class Aptitude
{
    public Health Health { get; set; }
    public Speed Speed { get; set; }
    public Bounce Bounce { get; set; }
    public Stability Stability { get; set; }
    public Power Power { get; set; }
    public Treatment Treatment { get; set; }
    public Block Block { get; set; }
    public RechargeSpeed RechargeSpeed { get; set; }
    public Leadership Leadership { get; set; }
    public Glory Glory { get; set; }
    public Income Income { get; set; }
    public Loss Loss { get; set; }

    public static Aptitude GetData()
    {
        Aptitude result = new();

        result.Health = PrefsManager.GetData<Health>();
        result.Speed = PrefsManager.GetData<Speed>();
        result.Bounce = PrefsManager.GetData<Bounce>();
        result.Stability = PrefsManager.GetData<Stability>();
        result.Power = PrefsManager.GetData<Power>();
        result.Treatment = PrefsManager.GetData<Treatment>();
        result.Block = PrefsManager.GetData<Block>();
        result.RechargeSpeed = PrefsManager.GetData<RechargeSpeed>();
        result.Leadership = PrefsManager.GetData<Leadership>();
        result.Glory = PrefsManager.GetData<Glory>();
        result.Income = PrefsManager.GetData<Income>();
        result.Loss = PrefsManager.GetData<Loss>();

        return result;
    }

    public bool SetDataPrefs()
    {
        try
        {
            PrefsManager.SetData(Health);
            PrefsManager.SetData(Speed);
            PrefsManager.SetData(Bounce);
            PrefsManager.SetData(Stability);
            PrefsManager.SetData(Power);
            PrefsManager.SetData(Treatment);
            PrefsManager.SetData(Block);
            PrefsManager.SetData(RechargeSpeed);
            PrefsManager.SetData(Leadership);
            PrefsManager.SetData(Glory);
            PrefsManager.SetData(Income);
            PrefsManager.SetData(Loss);

            return true;
        }
        catch
        {
            return false;
        }
    }
}
