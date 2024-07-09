using UnityEngine;
using static Enums;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance = null;

    public Complexity Complexity { get; set; } = Complexity.Intern;

    public Bank Bank { get; set; }
    public Level Level { get; set; }

    public Equipment Equipment { get; set; }
    public Aptitude Aptitude { get; set; }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        InitializeManager();
    }

    private void InitializeManager()
    {
        Bank = PrefsManager.GetData<Bank>();
        Level = PrefsManager.GetData<Level>();

        Equipment = Equipment.GetData();
        Aptitude = Aptitude.GetData();
    }
}

