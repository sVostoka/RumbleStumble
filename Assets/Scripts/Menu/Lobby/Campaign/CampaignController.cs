using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class CampaignController : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    [SerializeField] private Button _intern;
    [SerializeField] private Button _experienced;
    [SerializeField] private Button _seasoned;
    [SerializeField] private Button _nightmare;

    private Complexity _currentComplexity;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;

        _startButton.onClick.AddListener(DirectGame);

        _currentComplexity = ResourceManager.instance.Complexity;

        _intern.onClick.AddListener(delegate { Switch(_intern, Constants.CampaignController.VALUEINTERNACTIVE, Complexity.Intern); });
        _experienced.onClick.AddListener(delegate { Switch(_experienced, Constants.CampaignController.VALUEEXPERIENCEDACTIVE, Complexity.Experienced); });
        _seasoned.onClick.AddListener(delegate { Switch(_seasoned, Constants.CampaignController.VALUESEASONEDACTIVE, Complexity.Seasoned); });
        _nightmare.onClick.AddListener(delegate { Switch(_nightmare, Constants.CampaignController.VALUENIGHTMAREACTIVE, Complexity.Nightmare); });
    }

    private void Switch(Button buttonStruct, string imageSrc, Complexity newCurrentComplexity)
    {
        HideCurrentButton();

        buttonStruct.enabled = false;
        buttonStruct.GetComponent<Image>().sprite = Resources.Load<Sprite>(imageSrc);

        _currentComplexity = newCurrentComplexity;
        ResourceManager.instance.Complexity = _currentComplexity;
    }

    private void HideCurrentButton()
    {
        switch (_currentComplexity)
        {
            case Complexity.Intern:
                Hide(_intern, Constants.CampaignController.VALUEINTERNINACTIVE);
                break;

            case Complexity.Experienced:
                Hide(_experienced, Constants.CampaignController.VALUEEXPERIENCEDINACTIVE);
                break;

            case Complexity.Seasoned:
                Hide(_seasoned, Constants.CampaignController.VALUESEASONEDINACTIVE);
                break;

            case Complexity.Nightmare:
                Hide(_nightmare, Constants.CampaignController.VALUENIGHTMAREINACTIVE);
                break;
        }
    }

    private void Hide(Button buttonStruct, string imageSrc)
    {
        buttonStruct.enabled = true;
        buttonStruct.GetComponent<Image>().sprite = Resources.Load<Sprite>(imageSrc);
    }

    public void DirectEquipment()
    {
        Conductor.ShowScene(Scenes.Equipment);
    }

    public void DirectShop()
    {
        Conductor.ShowScene(Scenes.Shop);
    }

    public void DirectAptitude()
    {
        Conductor.ShowScene(Scenes.Aptitude);
    }

    public void DirectGame()
    {
        Conductor.ShowScene(Scenes.Game);
    }
}
