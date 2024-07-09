using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static Constants;
using static Enums;

public class SaleBoxesController : MonoBehaviour
{
    private AboutBoxController _aboutBox;

    private List<Button> _boxesButton;

    private void Awake()
    {
        _aboutBox = FindObjectOfType<AboutBoxController>(true);

        _boxesButton = GetComponentsInChildren<Button>().ToList();

        foreach (var boxButton in _boxesButton)
        {
            Item item;
            TypeItem typeItem;

            switch (boxButton.name.Split(' ')[0]) 
            {
                case nameof(TypeItem.Weapon):
                    item = Item.GetRandomWeapon();
                    typeItem = TypeItem.Weapon;
                    break;
                case nameof(TypeItem.Armor):
                    item = Item.GetRandomArmor();
                    typeItem = TypeItem.Armor;
                    break;
                case nameof(TypeItem.Amulet):
                    item = Item.GetRandomAmulet();
                    typeItem = TypeItem.Amulet;
                    break;
                case nameof(TypeItem.Bracelet):
                    item = Item.GetRandomBracelet();
                    typeItem = TypeItem.Bracelet;
                    break;
                case nameof(TypeItem.Ring):
                    item = Item.GetRandomRing();
                    typeItem = TypeItem.Ring;
                    break;
                default: 
                    item = null;
                    typeItem = TypeItem.Weapon;
                    break;
            }

            boxButton.onClick.AddListener(delegate
            {
                _aboutBox.OpenElement(boxButton.GetComponent<Image>(), item, typeItem);
            });
        }
    }
}