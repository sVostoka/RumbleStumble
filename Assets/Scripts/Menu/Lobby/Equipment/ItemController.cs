using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Enums;

public class ItemController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _background;
    [SerializeField] private Image _icon;

    private SlotController _currentSlot;
    public SlotController CurrentSlot 
    {
        get => _currentSlot;
        set
        {
            _currentSlot = value;
            //transform.SetParent(_currentSlot.transform);
            //transform.localPosition = Vector3.zero;
            //SetData();
        }
    }
    public Item Data { get; set; }

    private Canvas _canvas;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    public static readonly Dictionary<Rarity, string> backgroundsRarity = new()
    {
        {Rarity.Standard, Constants.RaritySrc.STANDARTBACKGROUNDSRC },
        {Rarity.Rare, Constants.RaritySrc.RAREBACKGROUNDSRC },
        {Rarity.Unusual, Constants.RaritySrc.UNUSUALBACKGROUNDSRC },
        {Rarity.Epic, Constants.RaritySrc.EPICBACKGROUNDSRC },
        {Rarity.Legendary, Constants.RaritySrc.LEGENDARYBACKGROUNDSRC },
    };

    private void Awake()
    {
        CurrentSlot = GetComponentInParent<SlotController>();

        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void SetData(Item data, SlotController slot)
    {
        CurrentSlot = slot;

        Data = data;
        SetImage();
    }

    public void SetImage()
    {
        _background.sprite = Resources.Load<Sprite>(backgroundsRarity[Data.Rarity]);
        _icon.sprite = Resources.Load<Sprite>(Data.ImageSrc);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (CurrentSlot.TypeSlot == TypeSlot.Inventory)
        {
            transform.SetParent(_canvas.transform);
            BlockRayCast(false);
        }
    }

    #region Drag
    public void OnDrag(PointerEventData eventData)
    {
        if (CurrentSlot.TypeSlot == TypeSlot.Inventory)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (CurrentSlot.TypeSlot == TypeSlot.Inventory)
        {
            transform.SetParent(CurrentSlot.transform);
            transform.localPosition = Vector3.zero;
            BlockRayCast(true);
        }
    }

    private void BlockRayCast(bool block)
    {
        _canvasGroup.blocksRaycasts = block;
        _background.raycastTarget = block;
        _icon.raycastTarget = block;
    }
    #endregion
}
