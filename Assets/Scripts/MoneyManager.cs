using System;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public event Action<int> PlayerMoneyChanged;
    public event Action HeroBought;
    public int PlayerMoney => _playerMoney;
    
    [SerializeField] private int _playerMoney;
    
    public void IsMoneyEnough(Hero hero)
    {
        if (_playerMoney < hero.HeroSettings.Price) return;
        
        _playerMoney -= hero.HeroSettings.Price;
        hero.MarkHero();
        HeroBought?.Invoke();
        PlayerMoneyChanged?.Invoke(_playerMoney);
    }
}
