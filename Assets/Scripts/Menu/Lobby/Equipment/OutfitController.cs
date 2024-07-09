using UnityEngine;
using static Enums;

public class OutfitController : MonoBehaviour
{
    [SerializeField] private SlotController _weapon;
    [SerializeField] private SlotController _armor;
    [SerializeField] private SlotController _amulet;
    [SerializeField] private SlotController _bracelet;
    [SerializeField] private SlotController _leftRing;
    [SerializeField] private SlotController _rightRing;

    private void Awake()
    {
        _weapon.Data = ResourceManager.instance.Equipment.Weapon;
        _armor.Data = ResourceManager.instance.Equipment.Armor;
        _amulet.Data = ResourceManager.instance.Equipment.Amulet;
        _bracelet.Data = ResourceManager.instance.Equipment.Bracelet;
        _leftRing.Data = ResourceManager.instance.Equipment.LeftRing;
        _rightRing.Data = ResourceManager.instance.Equipment.RightRing;

        Subscribe();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    #region Observer
    private void Subscribe()
    {
        ResourceManager.instance.Equipment.WeaponChanged += ChangeWeapon;
        ResourceManager.instance.Equipment.ArmorChanged += ChangeArmor;
        ResourceManager.instance.Equipment.AmuletChanged += ChangeAmulet;
        ResourceManager.instance.Equipment.BraceletChanged += ChangeBracelet;
        ResourceManager.instance.Equipment.LeftRingChanged += delegate { ChangeArmor(Side.Left); };
        ResourceManager.instance.Equipment.RightRingChanged += delegate { ChangeArmor(Side.Right); };
    }

    private void Unsubscribe()
    {
        ResourceManager.instance.Equipment.WeaponChanged -= ChangeWeapon;
        ResourceManager.instance.Equipment.ArmorChanged -= ChangeArmor;
        ResourceManager.instance.Equipment.AmuletChanged -= ChangeAmulet;
        ResourceManager.instance.Equipment.BraceletChanged -= ChangeBracelet;
        ResourceManager.instance.Equipment.LeftRingChanged -= delegate { ChangeArmor(Side.Left); };
        ResourceManager.instance.Equipment.RightRingChanged -= delegate { ChangeArmor(Side.Right); };
    }

    private void ChangeWeapon()
    {
        _weapon.Data = ResourceManager.instance.Equipment.Weapon;
    }

    private void ChangeArmor()
    {
        _armor.Data = ResourceManager.instance.Equipment.Armor;
    }

    private void ChangeAmulet()
    {
        _amulet.Data = ResourceManager.instance.Equipment.Amulet;
    }

    private void ChangeBracelet()
    {
        _bracelet.Data = ResourceManager.instance.Equipment.Bracelet;
    }

    private void ChangeArmor(Side side)
    {
        if(side == Side.Left)
            _leftRing.Data = ResourceManager.instance.Equipment.LeftRing;

        if(side == Side.Right)
            _rightRing.Data = ResourceManager.instance.Equipment.RightRing;
    }

    #endregion
}