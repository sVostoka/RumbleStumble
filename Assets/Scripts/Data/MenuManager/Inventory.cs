using Newtonsoft.Json;
using System.Collections.Generic;

public class Inventory : IDatable
{
    [JsonIgnore]
    public dynamic Default => Test();

    public List<Item> Items { get; set; } = new();

    public Inventory Test()
    {
        Inventory inventory = new();
        inventory.Items = new()
        {
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
            Item.GetRandomItem(),
        };

        return inventory;
    }

    public string GetKey()
    {
        return Constants.Inventory.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Inventory.PREFSDEFAULTVALUE;
    }
}