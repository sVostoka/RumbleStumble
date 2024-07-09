using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettinsGraphicController : MonoBehaviour
{
    [SerializeField] private Button _forwardMenuButton;
    [SerializeField] private Button _backMenuButton;

    [SerializeField] private GameObject _generalMode;
    [SerializeField] private GameObject _qualityMode;

    [SerializeField] private Slider _brightness;
    [SerializeField] private Switch _resolutionSwitch;
    [SerializeField] private Switch _modeSwitch;

    [SerializeField] private Switch _texturesSwitch;
    [SerializeField] private Switch _shadowsSwitch;
    [SerializeField] private Switch _effectsSwitch;
    [SerializeField] private Switch _lightingSwitch;

    private GraphicSettings _graphicsSettings;

    private void Awake()
    {
        _forwardMenuButton.onClick.AddListener(ChangeModeMenu);
        _backMenuButton.onClick.AddListener(ChangeModeMenu);

        _brightness.onValueChanged.AddListener(delegate { ChangeSliderValue(); });

        _graphicsSettings = SettinsManager.instance.Graphic;

        _brightness.value = _graphicsSettings.Brightness;

        Dictionary<int, Sprite> resolutionValues = new()
        {
            { 0, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUERESOLUTION720LABEL) },
            { 1, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUERESOLUTION1080LABEL) }
        };
        _resolutionSwitch.Labels = resolutionValues;
        _resolutionSwitch.Index = _graphicsSettings.Resolution;

        Dictionary<int, Sprite> modeValues = new()
        {
            { 0, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUEMODEWINDOWLABEL) },
            { 1, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUEMODEFULLSCREENLABEL) }
        };
        _modeSwitch.Labels = modeValues;
        _modeSwitch.Index = _graphicsSettings.Mode;

        Dictionary<int, Sprite> texturesValues = new()
        {
            { 0, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUELOWLABEL) },
            { 1, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUEMIDDLELABEL) },
            { 2, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUEHIGHLABEL) }
        };
        _texturesSwitch.Labels = texturesValues;
        _texturesSwitch.Index = _graphicsSettings.Textures;

        Dictionary<int, Sprite> shadowsValues = new()
        {
            { 0, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUELOWLABEL) },
            { 1, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUEMIDDLELABEL) },
            { 2, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUEHIGHLABEL) }
        };
        _shadowsSwitch.Labels = shadowsValues;
        _shadowsSwitch.Index = _graphicsSettings.Shadows;

        Dictionary<int, Sprite> effectsValues = new()
        {
            { 0, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUELOWLABEL) },
            { 1, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUEMIDDLELABEL) },
            { 2, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUEHIGHLABEL) }
        };
        _effectsSwitch.Labels = effectsValues;
        _effectsSwitch.Index = _graphicsSettings.Effects;

        Dictionary<int, Sprite> lightingValues = new()
        {
            { 0, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUELOWLABEL) },
            { 1, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUEMIDDLELABEL) },
            { 2, Resources.Load<Sprite>(Constants.SettingsGraphicController.VALUEHIGHLABEL) }
        };
        _lightingSwitch.Labels = lightingValues;
        _lightingSwitch.Index = _graphicsSettings.Lighting;
    }

    private void ChangeModeMenu()
    {
        if (_generalMode.activeSelf)
        {
            _generalMode.SetActive(false);
            _qualityMode.SetActive(true);
        }
        else
        {
            _generalMode.SetActive(true);
            _qualityMode.SetActive(false);
        }
    }

    private void ChangeSliderValue()
    {
        SettinsManager.instance.Graphic.Brightness = _brightness.value;
    }

    public void SaveSettings()
    {
        SettinsManager.instance.Graphic.Resolution = _resolutionSwitch.Index;
        SettinsManager.instance.Graphic.Mode = _modeSwitch.Index;

        SettinsManager.instance.Graphic.Textures = _texturesSwitch.Index;
        SettinsManager.instance.Graphic.Shadows = _shadowsSwitch.Index;
        SettinsManager.instance.Graphic.Effects = _effectsSwitch.Index;
        SettinsManager.instance.Graphic.Lighting = _lightingSwitch.Index;
    }
}
