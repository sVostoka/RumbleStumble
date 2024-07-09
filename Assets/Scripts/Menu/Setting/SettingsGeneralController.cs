using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsGeneralController : MonoBehaviour
{
    [SerializeField] private Slider _sensitivity;
    [SerializeField] private Switch _accelerationSwitch;
    [SerializeField] private Switch _squatSwitch;
    [SerializeField] private Switch _invetYSwitch;

    private GeneralSettings _generalSettings;

    private void Awake()
    {
        _sensitivity.onValueChanged.AddListener(delegate { ChangeSliderValue(); });

        _generalSettings = SettinsManager.instance.General;

        _sensitivity.value = _generalSettings.Sensitivity;

        Dictionary<int, Sprite> accelerationValues = new()
        {
            { 0, Resources.Load<Sprite>(Constants.SettingsGeneralController.VALUEPRESSLABEL) },
            { 1, Resources.Load<Sprite>(Constants.SettingsGeneralController.VALUEHOLDLABEL) },
        };
        _accelerationSwitch.Labels = accelerationValues;
        _accelerationSwitch.Index = _generalSettings.Acceleration;

        Dictionary<int, Sprite> squatValues = new()
        {
            { 0, Resources.Load<Sprite>(Constants.SettingsGeneralController.VALUEPRESSLABEL) },
            { 1, Resources.Load<Sprite>(Constants.SettingsGeneralController.VALUEHOLDLABEL) },
        };
        _squatSwitch.Labels = squatValues;
        _squatSwitch.Index = _generalSettings.Squat;


        Dictionary<int, Sprite> invetYValues = new()
        {
            { 0, Resources.Load<Sprite>(Constants.SettingsGeneralController.VALUENOLABEL) },
            { 1, Resources.Load<Sprite>(Constants.SettingsGeneralController.VALUEYESLABEL) },
        };
        _invetYSwitch.Labels = invetYValues;
        _invetYSwitch.Index = _generalSettings.InvertY;
        
    }

    private void ChangeSliderValue()
    {
        SettinsManager.instance.General.Sensitivity = _sensitivity.value;
    }

    public void SaveSettings()
    {
        SettinsManager.instance.General.Acceleration = _accelerationSwitch.Index;
        SettinsManager.instance.General.Squat = _squatSwitch.Index;
        SettinsManager.instance.General.InvertY = _invetYSwitch.Index;
    }
}
