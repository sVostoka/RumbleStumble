using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class SortWindowController : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _byLevel;
    [SerializeField] private Button _byRarity;
    [SerializeField] private Button _byTypeItem;

    private InventoryController _inventory;

    private void Awake()
    {
        _inventory = FindObjectOfType<InventoryController>();

        _closeButton.onClick.AddListener(Hide);
        _byLevel.onClick.AddListener(delegate { ChangeSortType(TypeSortItems.ByLevel); });
        _byRarity.onClick.AddListener(delegate { ChangeSortType(TypeSortItems.ByRariry); });
        _byTypeItem.onClick.AddListener(delegate { ChangeSortType(TypeSortItems.ByTypeItem); });
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void ChangeSortType(TypeSortItems typeSort)
    {
        _inventory.TypeSort = typeSort;
        Hide();
    }
}
