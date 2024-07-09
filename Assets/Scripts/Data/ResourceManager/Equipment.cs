using System;
using System.Reflection;
using UnityEngine;

public class Equipment
{
    public event Action WeaponChanged;
    public event Action ArmorChanged;
    public event Action AmuletChanged;
    public event Action BraceletChanged;
    public event Action LeftRingChanged;
    public event Action RightRingChanged;

    private Weapon _weapon;
    public Weapon Weapon 
    { 
        get => _weapon;
        set 
        {
            _weapon = value;
            
            if(WeaponChanged != null)
            {
                WeaponChanged.Invoke();
            }
        }
        
    }

    private Armor _armor;
    public Armor Armor
    {
        get => _armor;
        set
        {
            _armor = value;

            if(ArmorChanged != null)
            {
                ArmorChanged.Invoke();
            }
        }
    }

    private Amulet _amulet;
    public Amulet Amulet
    {
        get => _amulet;
        set
        {
            _amulet = value;
            if(AmuletChanged != null)
            {
                AmuletChanged.Invoke();
            }
        }
    }

    private Bracelet _bracelet;
    public Bracelet Bracelet
    {
        get => _bracelet;
        set
        {
            _bracelet = value;
            if(BraceletChanged != null)
            {
                BraceletChanged.Invoke();
            }
        }
    }

    private Ring _leftRing;
    public Ring LeftRing
    {
        get => _leftRing;
        set
        {
            _leftRing = value;
            if(LeftRingChanged != null)
            {
                LeftRingChanged.Invoke();
            }
        }
    }

    private Ring _rightRing;
    public Ring RightRing
    {
        get => _rightRing;
        set
        {
            _rightRing = value;
            if(RightRingChanged != null)
            {
                RightRingChanged.Invoke();
            }
        }
    }

    public static Equipment GetData()
    {
        Equipment result = new();

        result.Weapon = PrefsManager.GetData<Weapon>();
        result.Armor = PrefsManager.GetData<Armor>();
        result.Amulet = PrefsManager.GetData<Amulet>();
        result.Bracelet = PrefsManager.GetData<Bracelet>();
        result.LeftRing = PrefsManager.GetData<Ring>(new(Enums.Side.Left));
        result.RightRing = PrefsManager.GetData<Ring>(new(Enums.Side.Right));

        return result;
    }

    public bool SetDataPrefs()
    {
        try
        {
            PrefsManager.SetData(Weapon);
            PrefsManager.SetData(Armor);
            PrefsManager.SetData(Amulet);
            PrefsManager.SetData(Bracelet);
            PrefsManager.SetData(LeftRing);
            PrefsManager.SetData(RightRing);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool SetValueEquip<T>(T obj)
    {
        try
        {
            PrefsManager.SetData(obj as IDatable);

            if(obj.GetType() == typeof(Ring))
            {
                if((obj as Ring).Side == Enums.Side.Left)
                {
                    LeftRing = obj as Ring;
                }
                else
                {
                    RightRing = obj as Ring;
                }
            }
            else
            {
                PropertyInfo[] properties = GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    if (property.PropertyType == obj.GetType())
                    {
                        property.SetValue(this, obj);
                        break;
                    }
                }
            }

            return true;
        }
        catch
        {
            return false;
        }
    }
}