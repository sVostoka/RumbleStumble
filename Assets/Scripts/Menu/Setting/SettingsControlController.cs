using UnityEngine;

public class SettingsControlController : MonoBehaviour
{ 
    private ControlSettings _controlSettings;

    private void Awake()
    {
        _controlSettings = SettinsManager.instance.Control;
    }
    public void SaveSettings()
    {
        SettinsManager.instance.Control.Stub = "Stub";
    }
}
