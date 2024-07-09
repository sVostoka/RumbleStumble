using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaleItemsController : MonoBehaviour
{
    private List<Item> _saleItems;
    private List<SlotController> _saleSlots;

    private void Awake()
    {
        LobbyManager.instance.SaleItems.GetNewItems();
        _saleItems = LobbyManager.instance.SaleItems.Items;
        
        _saleSlots = GetComponentsInChildren<SlotController>().ToList();
        for(int i = 0; i < _saleSlots.Count; i++)
        {
            _saleSlots[i].Data = _saleItems[i];
        }
    }
}