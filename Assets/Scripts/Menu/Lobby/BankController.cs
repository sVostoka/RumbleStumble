using TMPro;
using UnityEngine;

public class BankController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _firstValue;
    [SerializeField] private TextMeshProUGUI _secondValue;

    private void Awake()
    {
        Subscribe();
        BankChanged();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        ResourceManager.instance.Bank.BankChanged += BankChanged;
    }

    private void Unsubscribe()
    {
        ResourceManager.instance.Bank.BankChanged -= BankChanged;
    }

    private void BankChanged()
    {
        _firstValue.text = ResourceManager.instance.Bank.Coins.ToString();
        _secondValue.text = ResourceManager.instance.Bank.Diamonds.ToString();
    }
}
