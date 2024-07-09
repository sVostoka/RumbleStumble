using UnityEngine;

public class SettinsManager : MonoBehaviour
{
    public static SettinsManager instance = null;

    public GeneralSettings General { get; set; }
    public ControlSettings Control { get; set; }
    public GraphicSettings Graphic { get; set; }
    public SoundSettings Sound { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        InitializeManager();
    }

    private void InitializeManager()
    {
        General = PrefsManager.GetData<GeneralSettings>();
        Control = PrefsManager.GetData<ControlSettings>();
        Graphic = PrefsManager.GetData<GraphicSettings>();
        Sound = PrefsManager.GetData<SoundSettings>();
    }

    public void SaveAll()
    {
        SaveGeneral();
        SaveControl();
        SaveGraphic();
        SaveSound();
    }

    public void SaveGeneral()
    {
        PrefsManager.SetData(General);
    }

    public void SaveControl()
    {
        PrefsManager.SetData(Control);
    }

    public void SaveGraphic()
    {
        PrefsManager.SetData(Graphic);
    }

    public void SaveSound()
    {
        PrefsManager.SetData(Sound);
    }
}
