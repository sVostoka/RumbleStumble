using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class AboutBoxController : MonoBehaviour
{
    [SerializeField] private Button _closeButton;

    [Header("Image Box")]
    [SerializeField] private Image _imageItem;

    [Header("Label Box")]
    [SerializeField] private Image _labelItem;

    [Header("Buy Button")]
    [SerializeField] private Button _buyButton;

    private static readonly Dictionary<TypeItem, string> _labelBoxes = new()
    {
        { TypeItem.Weapon, Constants.AboutBoxController.WEAPONBOXLABEL },
        { TypeItem.Armor, Constants.AboutBoxController.ARMORBOXLABEL},
        { TypeItem.Amulet, Constants.AboutBoxController.AMULETBOXLABEL},
        { TypeItem.Bracelet, Constants.AboutBoxController.BRACELETBOXLABEL},
        { TypeItem.Ring, Constants.AboutBoxController.RINGBOXLABEL},
    };

    private AboutElementController _aboutElement;

    private void Awake()
    {
        _aboutElement = FindObjectOfType<AboutElementController>(true);
        _closeButton.onClick.AddListener(Hide);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OpenElement(Image imageItem, Item data, TypeItem typeItem)
    {
        gameObject.SetActive(true);
        if(_aboutElement != null) _aboutElement.gameObject.SetActive(false);

        _imageItem.sprite = imageItem.sprite;

        _labelItem.sprite = Resources.Load<Sprite>(_labelBoxes[typeItem]);
    }
}