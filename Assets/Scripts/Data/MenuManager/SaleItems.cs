using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SaleItems : IDatable
{
    [JsonIgnore]
    public dynamic Default => GenerateItems();

    public DateTime LastRequest { get; set; }
    public List<Item> Items {  get; set; } = new();

    private SaleItems GenerateItems()
    {
        SaleItems saleItems = new();
        saleItems.Items = GetItems();
        saleItems.LastRequest = DateTime.Now;

        return saleItems;
    }

    private List<Item> GetItems()
    {
        return new()
        {
            Item.GetRandomWeapon(),
            Item.GetRandomArmor(),
            Item.GetRandomAmulet(),
            Item.GetRandomBracelet(),
            Item.GetRandomRing(),
            Item.GetRandomRing()
        };
    }

    public string GetKey()
    {
        return Constants.SaleItems.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.SaleItems.PREFSDEFAULTVALUE;
    }

    public void GetNewItems()
    {
        int difference = DateTime.Now.Subtract(LastRequest).Days;

        if(difference >= 1)
        {
            Items = GetItems();
        }
    }
}