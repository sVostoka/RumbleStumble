using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager instance = null;

    public Inventory Inventory { get; set; }
    public SaleItems SaleItems { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        InitializeManager();
    }

    private void InitializeManager()
    {
        Inventory = PrefsManager.GetData<Inventory>();
        SaleItems = PrefsManager.GetData<SaleItems>();
    }

    public void SaveAll()
    {
        SaveInventory();
        SaveSaleItem();
    }

    public void SaveInventory()
    {
        PrefsManager.SetData(Inventory);
    }

    public void SaveSaleItem()
    {
        PrefsManager.SetData(SaleItems);
    }
}