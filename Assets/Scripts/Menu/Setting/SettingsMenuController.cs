using UnityEngine;
using UnityEngine.SceneManagement;
using static Enums;

public class SettingsMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _generalSettings;
    [SerializeField] private GameObject _controlSettings;
    [SerializeField] private GameObject _graphicSettings;
    [SerializeField] private GameObject _soundSettings;

    private void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)Scenes.Settings));
    }

    public void ShowGeneralSettings()
    {
        _generalSettings.SetActive(true);
        _controlSettings.SetActive(false);
        _graphicSettings.SetActive(false);
        _soundSettings.SetActive(false);
    }

    public void ShowControlSettings()
    {
        _generalSettings.SetActive(false);
        _controlSettings.SetActive(true);
        _graphicSettings.SetActive(false);
        _soundSettings.SetActive(false);
    }

    public void ShowGraphicSettings()
    {
        _generalSettings.SetActive(false);
        _controlSettings.SetActive(false);
        _graphicSettings.SetActive(true);
        _soundSettings.SetActive(false);
    }

    public void ShowSoundSettings()
    {
        _generalSettings.SetActive(false);
        _controlSettings.SetActive(false);
        _graphicSettings.SetActive(false);
        _soundSettings.SetActive(true);
    }

    public void BackButton()
    {
        SaveAllSettings();

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

    private void SaveAllSettings()
    {
        _generalSettings.GetComponent<SettingsGeneralController>().SaveSettings();
        _controlSettings.GetComponent<SettingsControlController>().SaveSettings();
        _graphicSettings.GetComponent<SettinsGraphicController>().SaveSettings();
        _soundSettings.GetComponent<SettingsSoundController>().SaveSettings();

        SettinsManager.instance.SaveAll();
    }
}
