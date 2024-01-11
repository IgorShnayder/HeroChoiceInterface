using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [field: SerializeField] public int PlayerMoney { get; private set; }
    [SerializeField] private List<MoneyView> _moneyViews;
    
    private void Awake()
    {
        foreach (var moneyView in _moneyViews)
        {
            moneyView.Initialize(PlayerMoney);
        }
    }

    public bool TryPurchase(int price)
    {
        if (PlayerMoney >= price)
        {
            PlayerMoney -= price;
            UpdateMoneyViews(PlayerMoney);
            return true;
        }

        return false;
    }

    private void UpdateMoneyViews(int money)
    {
        foreach (var moneyView in _moneyViews)
        {
            moneyView.UpdateMoneyView(money);
        }
    }
}
