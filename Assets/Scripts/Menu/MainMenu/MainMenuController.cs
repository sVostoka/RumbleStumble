using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _continueButton;

    private void Awake()
    {
        _continueButton.interactable = SaveData.IsSave;
    }

    public void InLobby()
    {
        Conductor.ShowScene(Scenes.Campaign);
    }

    public void Continue()
    {
        Conductor.ShowScene(Scenes.Game);
    }

    public void Settings()
    {
        Conductor.ShowScene(Scenes.Settings, UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }

    public void Authors()
    {
        Conductor.ShowScene(Scenes.Authors);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
