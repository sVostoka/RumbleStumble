using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class InventoryController : MonoBehaviour
{ 
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _frontButton;

    [SerializeField] private Button _sortButton;

    [SerializeField] private GameObject _slotsObject;

    private TypeSortItems _typeSort = TypeSortItems.ByRariry;
    public TypeSortItems TypeSort
    {
        get => _typeSort;
        set
        {
            _typeSort = value;

            SortItems();
            SetData();
        }
    }

    private int _currentPage = 1;
    public int CurrentPage
    {
        get => _currentPage;
        set
        {
            _currentPage = value;

            SetData();
        }
    }

    private List<Item> _invetory;

    private List<SlotController> _slotsList;
    private int _countItems;
    private int _countPage;

    private void Awake()
    {
        _backButton.onClick.AddListener(BackPage);
        _frontButton.onClick.AddListener(FrontPage);
        _sortButton.onClick.AddListener(OpenSortWidndow);

        _slotsList = _slotsObject.GetComponentsInChildren<SlotController>().ToList();
        _countItems = _slotsList.Count;

        _invetory = LobbyManager.instance.Inventory.Items;

        _countPage = (int)Math.Ceiling((float)_invetory.Count / _countItems);

        if(_countPage <= 1)
        {
            _backButton.interactable = false;
            _frontButton.interactable = false;

            if (_countPage == 0)
            {
                _sortButton.interactable = false;
            }
        }

        SortItems();
        SetData();
    }

    private void BackPage()
    {
        CurrentPage = (CurrentPage - 1 <= 0) ? _countPage : CurrentPage - 1;
    }

    private void FrontPage()
    {
        CurrentPage = (CurrentPage + 1 > _countPage) ? 1 : CurrentPage + 1;
    }

    private void OpenSortWidndow()
    {
        SortWindowController sort = FindObjectOfType<SortWindowController>(true);
        sort.gameObject.SetActive(true);
    }

    private void SetData()
    {
        int start = (_currentPage - 1) * _countItems;

        _slotsList.ForEach(slot => slot.Data = null);

        for (int invIter = start, itemsIter = 0; invIter < _invetory.Count && itemsIter < _countItems; invIter++, itemsIter++)
        {
            _slotsList[itemsIter].Data = _invetory[invIter];
        }
    }

    private void SortItems()
    {
        switch (TypeSort)
        {
            case TypeSortItems.ByLevel:
                _invetory.Sort((x, y) => y.Level.CompareTo(x.Level));
                break;
            case TypeSortItems.ByRariry:
                _invetory.Sort((x, y) => y.Rarity.CompareTo(x.Rarity));
                break;
            case TypeSortItems.ByTypeItem:
                _invetory.Sort((x, y) => 
                    {
                        TypeItem xType = (TypeItem)Enum.Parse(typeof(TypeItem), x.GetType().Name);
                        TypeItem yType = (TypeItem)Enum.Parse(typeof(TypeItem), y.GetType().Name);

                        return xType.CompareTo(yType);
                    });
                break;
        }
    }

    public void DeleteInventory(Item deleteItem)
    {
        _invetory.Remove(deleteItem);

        SetData();
    }

    public void AddInventory(Item addItem)
    {
        _invetory.Add(addItem);

        SetData();
    }

    public void SwapItemsInInventory(Item deleteItem, Item addItem)
    {
        _invetory.Remove(deleteItem);
        _invetory.Add(addItem);

        SetData();
    }
}
