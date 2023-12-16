using System;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public event Action<int> PlayerMoneyChanged;
    public event Action HeroBought;
    public int PlayerMoney => _playerMoney;
    
    [SerializeField] private int _playerMoney;
    
    public void IsMoneyEnough(int price)
    {
        if (_playerMoney < price) return;
        
        _playerMoney -= price;
        HeroBought?.Invoke();
        PlayerMoneyChanged?.Invoke(_playerMoney);
    }
}
