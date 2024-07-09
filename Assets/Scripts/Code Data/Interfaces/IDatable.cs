public interface IDatable
{
    public dynamic Default { get; }

    public string GetKey();

    public string GetDefault();
}