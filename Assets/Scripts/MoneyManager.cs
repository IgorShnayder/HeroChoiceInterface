using System;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public event Action PlayerMoneyChanged;
    [field: SerializeField] public int PlayerMoney { get; private set; }
    
    public bool TryPurchase(int price)
    {
        if (PlayerMoney >= price)
        {
            PlayerMoney -= price;
            PlayerMoneyChanged?.Invoke();
            return true;
        }

        return false;
    }
}
