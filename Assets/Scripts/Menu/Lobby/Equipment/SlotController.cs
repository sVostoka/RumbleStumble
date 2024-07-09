using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Enums;

public class SlotController : MonoBehaviour, IDropHandler
{
    [SerializeField] private AboutElementController _aboutElement;
    private Button _aboutButton;

    [SerializeField] private TypeSlot _typeSlot;
    public TypeSlot TypeSlot
    {
        get => _typeSlot;
    }

    [SerializeField] private ItemController _itemController;

    private Item _data = null;
    public Item Data
    {
        get => _data;
        set
        {
            _data = value;

            if (value != null && value.ImageSrc != null)
            {
                ShowItem();
            }
            else
            {
                HideItem();
            }
        }
    }

    private void Awake()
    {
        SetListener();
    }

    private void SetListener()
    {
        _aboutButton = GetComponent<Button>();

        _aboutButton.onClick.AddListener(delegate {
            _aboutElement.OpenElement(Data, _aboutButton.transform.position, TypeSlot);
        });
    }

    private void ShowItem()
    {
        _itemController.gameObject.SetActive(true);
        _itemController.SetData(Data, this);
    }

    private void HideItem()
    {
        _itemController.gameObject.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        SlotController dropSlot = eventData.pointerDrag.GetComponent<ItemController>().CurrentSlot;

        if (gameObject.name.Contains(dropSlot.Data.GetType().Name))
        {
            Item currentData = Data;
            Data = dropSlot.Data;
            dropSlot.Data = currentData;

            if (Data.GetType() == typeof(Ring))
            {
                (Data as Ring).Side = gameObject.name.Contains(nameof(Side.Left)) ? Side.Left : Side.Right;
            }

            ResourceManager.instance.Equipment.SetValueEquip(Data);

            if (currentData.ImageSrc == null)
            {
                FindObjectOfType<InventoryController>().DeleteInventory(Data);
            }
            else
            {
                FindObjectOfType<InventoryController>().SwapItemsInInventory(Data, dropSlot.Data);
            }
        }
    }
}