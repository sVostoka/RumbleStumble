using UnityEngine;
using UnityEngine.UI;

public class SettingsSoundController : MonoBehaviour
{
    [SerializeField] private Slider _overall;
    [SerializeField] private Slider _effects;
    [SerializeField] private Slider _music;
    [SerializeField] private Slider _interface;
    [SerializeField] private Slider _ambient;

    private SoundSettings _soundSettings;

    private void Awake()
    {
        _overall.onValueChanged.AddListener(delegate { ChangeOverallSliderValue(); });
        _effects.onValueChanged.AddListener(delegate { ChangeEffectsSliderValue(); });
        _music.onValueChanged.AddListener(delegate { ChangeMusicSliderValue(); });
        _interface.onValueChanged.AddListener(delegate { ChangeInterfaceSliderValue(); });
        _ambient.onValueChanged.AddListener(delegate { ChangeAmbientSliderValue(); });

        _soundSettings = SettinsManager.instance.Sound;

        _overall.value = _soundSettings.OverallVolume;
        _effects.value = _soundSettings.EffectsVolume;
        _music.value = _soundSettings.MusicVolume;
        _interface.value = _soundSettings.InterfaceVolume;
        _ambient.value = _soundSettings.AmbientVolume;
    }

    private void ChangeOverallSliderValue()
    {
        SettinsManager.instance.Sound.OverallVolume = _overall.value;
    }

    private void ChangeEffectsSliderValue()
    {
        SettinsManager.instance.Sound.EffectsVolume = _effects.value;
    }

    private void ChangeMusicSliderValue()
    {
        SettinsManager.instance.Sound.MusicVolume = _music.value;
    }

    private void ChangeInterfaceSliderValue()
    {
        SettinsManager.instance.Sound.InterfaceVolume = _interface.value;
    }

    private void ChangeAmbientSliderValue()
    {
        SettinsManager.instance.Sound.AmbientVolume = _ambient.value;
    }

    public void SaveSettings()
    {
        
    }
}
