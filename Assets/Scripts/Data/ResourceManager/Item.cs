using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static Enums;
public class Parameter
{
    public string Name { get; set; }
    public string LabelSrc { get; set; }
    public string Value { get; set; }

    public Rarity Rarity { get; set; }

    public Parameter(string name, string labelSrc, string value, Rarity rarity)
    {
        Name = name;
        LabelSrc = labelSrc;
        Value = value;
        Rarity = rarity;
    }
}

public abstract class Item
{
    public string ModelSrc { get; set;}
    public string ImageSrc { get; set; }
    public Rarity Rarity { get; set; }
    public int PriceSell { get; set; }
    public int PriceBuy { get; set; }
    public int PriceUp { get; set; }
    public int Level { get; set; }

    public abstract List<Parameter> GetListParams();

    public static Item GetRandomItem()
    {
        Random rnd = new();

        TypeItem randomType = (TypeItem)rnd.Next(Enum.GetValues(typeof(TypeItem)).Length);
        
        switch (randomType)
        {
            case TypeItem.Weapon: return GetRandomWeapon();
            case TypeItem.Armor: return GetRandomArmor();
            case TypeItem.Amulet: return GetRandomAmulet();
            case TypeItem.Bracelet: return GetRandomBracelet();
            case TypeItem.Ring: return GetRandomRing();
            default: return null;
        }
    }

    public static Item GetRandomWeapon() { return DataBase.GetItem<Weapon>();}
    public static Item GetRandomArmor() { return DataBase.GetItem<Armor>();}
    public static Item GetRandomAmulet() { return DataBase.GetItem<Amulet>(); }
    public static Item GetRandomBracelet() { return DataBase.GetItem<Bracelet>(); }
    public static Item GetRandomRing() { return DataBase.GetItem<Ring>(); }
}

public class Weapon : Item, IDatable
{
    [JsonIgnore]
    //dynamic IDatable.Default => new Weapon(
    //        Constants.Weapon.MODELSRCDEFAULTVALUE,
    //        Constants.Weapon.IMAGESRCDEFAULTVALUE,
    //        Constants.Weapon.RARITYDEFAULTVALUE,
    //        Constants.Weapon.PRICESELLDEFAULTVALUE,
    //        Constants.Weapon.PRICEBUYDEFAULTVALUE,
    //        Constants.Weapon.PRICEUPDEFAULTVALUE,
    //        Constants.Weapon.LEVELDEFAULTVALUE,
    //        Constants.Weapon.DAMAGEDEFAULTVALUE,
    //        Constants.Weapon.RANGEDEFAULTVALUE,
    //        Constants.Weapon.AMMOCOUNTDEFAULTVALUE,
    //        Constants.Weapon.RELOADINGDEFAULTVALUE
    //    );

    dynamic IDatable.Default => new Weapon();

    public int Damage { get; set; }
    public int Range { get; set; }
    public int AmmoCount { get; set; }
    public float Reloading { get; set; }

    public Weapon() { }

    public Weapon(
            string modelSrc, string imageSrc, Rarity rarity,
            int priceSell, int priceBuy, int priceUp, int level,
            int damage, int range, int ammoCount, float reloading
        )
    {
        ModelSrc = modelSrc;
        ImageSrc = imageSrc;
        Rarity = rarity;
        PriceSell = priceSell;
        PriceBuy = priceBuy;
        PriceUp = priceUp;
        Level = level;
        Damage = damage;
        Range = range;
        AmmoCount = ammoCount;
        Reloading = reloading;
    }

    public string GetKey()
    {
        return Constants.Weapon.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Weapon.PREFSDEFAULTVALUE;
    }

    public override List<Parameter> GetListParams()
    {
        Rarity damageRarity = (Damage < 2) ? Rarity.Standard : (Damage < 5) ? Rarity.Rare : (Damage < 10) ? Rarity.Unusual : (Damage < 15) ? Rarity.Epic : Rarity.Legendary;
        Rarity rangeRarity = (Range < 20) ? Rarity.Standard : (Range < 40) ? Rarity.Rare : (Range < 80) ? Rarity.Unusual : (Range < 160) ? Rarity.Epic : Rarity.Legendary;
        Rarity ammoCountRarity = (AmmoCount < 5) ? Rarity.Standard : (AmmoCount < 10) ? Rarity.Rare : (AmmoCount < 20) ? Rarity.Unusual : (AmmoCount < 40) ? Rarity.Epic : Rarity.Legendary;
        Rarity reloadingRarity = (Reloading > 10) ? Rarity.Standard : (Reloading > 8) ? Rarity.Rare : (Reloading > 6) ? Rarity.Unusual : (Reloading > 4) ? Rarity.Epic : Rarity.Legendary;

        return new()
        {
            new Parameter(nameof(Damage), Constants.Weapon.DAMAGELABELSRC, Damage.ToString() + " "  + Constants.UnitsLabel.UNIT, damageRarity),
            new Parameter(nameof(Range), Constants.Weapon.RANGELABELSRC, Range.ToString() + " "  + Constants.UnitsLabel.METER, rangeRarity),
            new Parameter(nameof(AmmoCount), Constants.Weapon.AMMOCOUNTLABELSRC, AmmoCount.ToString() + " "  + Constants.UnitsLabel.PIECE, ammoCountRarity),
            new Parameter(nameof(Reloading), Constants.Weapon.RELOADINGLABELSRC, Reloading.ToString() + " "  + Constants.UnitsLabel.SECOND, reloadingRarity)
        };
    }
}

public class Armor : Item, IDatable
{
    [JsonIgnore]
    public dynamic Default => new Armor();

    public int Strength { get; set; }
    public int Resist { get; set; }

    public string GetKey()
    {
        return Constants.Armor.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Armor.PREFSDEFAULTVALUE;
    }

    public override List<Parameter> GetListParams()
    {
        Rarity strengthRarity = (Strength < 20) ? Rarity.Standard : (Strength < 60) ? Rarity.Rare : (Strength < 180) ? Rarity.Unusual : (Strength < 250) ? Rarity.Epic : Rarity.Legendary;
        Rarity resistRarity = (Resist < 3) ? Rarity.Standard : (Resist < 6) ? Rarity.Rare : (Resist < 12) ? Rarity.Unusual : (Resist < 24) ? Rarity.Epic : Rarity.Legendary;

        return new()
        {
            new Parameter(nameof(Strength), Constants.Armor.STRENGTHLABELSRC, Strength.ToString() + " " + Constants.UnitsLabel.UNIT, strengthRarity),
            new Parameter(nameof(Resist), Constants.Armor.RESISTLABELSRC, Resist.ToString() + " "  + Constants.UnitsLabel.PERCENT, resistRarity)
        };
    }
}

public class Amulet : Item, IDatable
{
    [JsonIgnore]
    public dynamic Default => new Amulet();

    public int HPBoost { get; set; }

    public string GetKey()
    {
        return Constants.Amulet.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Amulet.PREFSDEFAULTVALUE;
    }

    public override List<Parameter> GetListParams()
    {
        Rarity hpBoostRarity = (HPBoost < 10) ? Rarity.Standard : (HPBoost < 15) ? Rarity.Rare : (HPBoost < 20) ? Rarity.Unusual : (HPBoost < 25) ? Rarity.Epic : Rarity.Legendary;

        return new()
        {
            new Parameter(nameof(HPBoost), Constants.Amulet.HPBOOSTLABELSRC, HPBoost.ToString() + " " + Constants.UnitsLabel.UNIT, hpBoostRarity)
        };
    }
}

public class Bracelet : Item, IDatable
{
    [JsonIgnore]
    public dynamic Default => new Bracelet();

    public int DamageBoost { get; set; }

    public string GetKey()
    {
        return Constants.Bracelet.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Bracelet.PREFSDEFAULTVALUE;
    }

    public override List<Parameter> GetListParams()
    {
        Rarity damageBoostRarity = (DamageBoost < 10) ? Rarity.Standard : (DamageBoost < 15) ? Rarity.Rare : (DamageBoost < 20) ? Rarity.Unusual : (DamageBoost < 25) ? Rarity.Epic : Rarity.Legendary;

        return new()
        {
            new Parameter(nameof(DamageBoost), Constants.Bracelet.DAMAGEBOOSTLABELSRC, DamageBoost.ToString() + " " + Constants.UnitsLabel.UNIT, damageBoostRarity)
        };
    }
}

public class Ring : Item, IDatable
{
    [JsonIgnore]
    public dynamic Default => new Ring();

    public Side Side { get; set; }

    public int SpeedBoost { get; set; }

    public Ring() { }

    public Ring(Side side)
    {
        Side = side;
    }

    public override List<Parameter> GetListParams()
    {
        Rarity damageBoostRarity = (SpeedBoost < 10) ? Rarity.Standard : (SpeedBoost < 15) ? Rarity.Rare : (SpeedBoost < 20) ? Rarity.Unusual : (SpeedBoost < 25) ? Rarity.Epic : Rarity.Legendary;

        return new()
        {
            new Parameter(nameof(SpeedBoost), Constants.Ring.SPEEDBOOST, SpeedBoost.ToString() + " " + Constants.UnitsLabel.UNIT, damageBoostRarity)
        };
    }

    public string GetKey()
    {
        return (Side == Side.Left) ? Constants.Ring.PREFSKEYLEFT : Constants.Ring.PREFSKEYRIGHT;
    }

    public string GetDefault()
    {
        return (Side == Side.Left) ? Constants.Ring.PREFSDEFAULTVALUE : Constants.Ring.PREFSDEFAULTVALUE;
    }

    public void ChangeSide(string side)
    {
        Side = Constants.Ring.PREFSKEYLEFT.Contains(side) ? Side.Left : Side.Right;
    }
}