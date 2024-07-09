using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class AboutElementController : MonoBehaviour
{
    [SerializeField] private Button _closeButton;

    [Header ("Image Item")]
    [SerializeField] private Image _backgroundImageItem;
    [SerializeField] private Image _imageItem;

    [Header ("Up Button")]
    [SerializeField] private Button _upButton;
    [SerializeField] private TextMeshProUGUI _upValue;

    [Header("Buy Button")]
    [SerializeField] private Button _buyButton;
    [SerializeField] private TextMeshProUGUI _buyValue;

    [Header("Parameters")]
    [SerializeField] private Image _qualityValue;
    [SerializeField] private List<ParameterItemController> _paramsItem;

    private AboutBoxController _aboutBox;
    private Rect _fullSize;

    public static readonly Dictionary<Rarity, string> labelsRarity = new()
    {
        {Rarity.Standard, Constants.RaritySrc.STANDARTLABELSRC },
        {Rarity.Rare, Constants.RaritySrc.RARELABELSRC },
        {Rarity.Unusual, Constants.RaritySrc.UNUSUALLABELSRC },
        {Rarity.Epic, Constants.RaritySrc.EPICLABELSRC },
        {Rarity.Legendary, Constants.RaritySrc.LEGENDARYLABELSRC },
    };

    public static readonly Dictionary<Rarity, Color> colorsRarity = new()
    {
        {Rarity.Standard, new Color32(168, 168, 168, 255) },
        {Rarity.Rare, new Color32(175, 203, 0, 255) },
        {Rarity.Unusual, new Color32(26, 136, 24, 255) },
        {Rarity.Epic, new Color32(29, 130, 152, 255) },
        {Rarity.Legendary, new Color32(82, 14, 112, 255) },
    };

    private void Awake()
    {
        _fullSize = gameObject.GetComponent<RectTransform>().rect;
        _aboutBox = FindObjectOfType<AboutBoxController>(true);
        _closeButton.onClick.AddListener(Hide);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OpenElement(Item data, Vector3 buttonPosititon, TypeSlot typeSlot)
    {
        gameObject.SetActive(true);
        if(_aboutBox != null) _aboutBox.gameObject.SetActive(false);

        _backgroundImageItem.sprite = Resources.Load<Sprite>(ItemController.backgroundsRarity[data.Rarity]);
        _imageItem.sprite = Resources.Load<Sprite>(data.ImageSrc);
        
        
        if (typeSlot == TypeSlot.Outfit || typeSlot == TypeSlot.Inventory)
        {
            _upButton.gameObject.SetActive(true);
            _buyButton.gameObject.SetActive(false);
        }
        else
        {
            _upButton.gameObject.SetActive(false);
            _buyButton.gameObject.SetActive(true);
        }

        SetParameters(data);

        transform.position = GetPosititon(buttonPosititon);
    }

    private void SetParameters(Item data)
    {
        _qualityValue.sprite = Resources.Load<Sprite>(labelsRarity[data.Rarity]);

        List<Parameter> parameters = data.GetListParams();

        SetSize(parameters.Count);

        for(int i = 0; i < parameters.Count; i++)
        {
            _paramsItem[i].Label.sprite = Resources.Load<Sprite>(parameters[i].LabelSrc);
            _paramsItem[i].Value.text = parameters[i].Value;
            _paramsItem[i].Value.color = colorsRarity[parameters[i].Rarity];
        }

        _upValue.text = data.PriceUp.ToString();
    }

    private void SetSize(int countParams)
    {
        _paramsItem.ForEach(param => { param.gameObject.SetActive(true); });

        for (int i = countParams; i < _paramsItem.Count; i++)
        {
            _paramsItem[i].gameObject.SetActive(false);
        }

        gameObject.GetComponent<RectTransform>().sizeDelta = new(
            gameObject.GetComponent<RectTransform>().rect.width,
            _fullSize.height - (_paramsItem.Count - countParams) * Constants.AboutElementController.PADDINGPARAMS
            );
    }

    private Vector3 GetPosititon(Vector3 buttonPosititon)
    {
        float distToLeft = buttonPosititon.x;
        float distToRight = Screen.width - buttonPosititon.x;

        return new(
                (distToLeft > distToRight) ? distToLeft / 2 : Screen.width - distToRight / 2,
                transform.position.y,
                transform.position.z
            );
    }
}
