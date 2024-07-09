using Newtonsoft.Json;
using System;
using UnityEngine;

public class Bank : IDatable
{
    public event Action BankChanged;

    [JsonIgnore]
    dynamic IDatable.Default => new Bank(
            Constants.Bank.COINSDEFAULTVALUE,
            Constants.Bank.DIAMONDSDEFAULTVALUE
        );

    private int _coins;

    public int Coins
    {
        get => _coins;
        set 
        {
            _coins = value;

            CallObservers();
        }
    }

    private int _diamonds;

    public int Diamonds
    {
        get => _diamonds;
        set
        {
            _diamonds = value;

            CallObservers();
        }

    }

    public Bank() { }

    public Bank(int coins, int diamonds)
    {
        Coins = coins;
        Diamonds = diamonds;
    }

    private void CallObservers()
    {
        if (BankChanged != null)
        {
            BankChanged.Invoke();
        }
    }

    public string GetKey()
    {
        return Constants.Bank.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Bank.PREFSDEFAULTVALUE;
    }
}