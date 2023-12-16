using System;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelectionManager : MonoBehaviour
{
    public event Action<Hero> HeroSwitched;
    public event Action<int> BuyButtonPushed;
    public event Action<Hero> SendHero; 
    
    public Hero Hero => _hero;

    [SerializeField] private HeroSwitcher _heroSwitcher;
    [SerializeField] private HeroSelectionScreen _heroSelectionScreen;
    [SerializeField] private Transform _heroPosition;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _selectButton;
     
    private HeroesManager _heroesManager;
    private Hero _hero;
    private int _heroIndex;
    private MoneyManager _moneyManager;
    
    public void Initialize(HeroesManager heroesManager, MoneyManager moneyManager)
    {
        _heroesManager = heroesManager;
        _moneyManager = moneyManager;
        var heroesQuantity = _heroesManager.Heroes.Count;
        
        _heroSwitcher.Initialize(heroesQuantity);
        
        _heroSwitcher.SwitchButtonPushed += SwitchHero;
        HeroSwitched += _heroSelectionScreen.UpdateHeroSelectionScreen;
        BuyButtonPushed += _moneyManager.IsMoneyEnough;
    }

    private void OnDestroy()
    {
        _heroSwitcher.SwitchButtonPushed -= SwitchHero;
        HeroSwitched -= _heroSelectionScreen.UpdateHeroSelectionScreen;
        BuyButtonPushed -= _moneyManager.IsMoneyEnough;
        _moneyManager.HeroBought -= _heroesManager.Heroes[_heroIndex].MarkHero;
        _moneyManager.HeroBought -= ButtonsUpdate;
    }

    public void FillHeroSelectionScreen()
    {
        if (_hero != null || _heroesManager.Heroes.Count == 0) return;
        
         _hero = Instantiate(_heroesManager.Heroes[0], _heroPosition);
        _heroSelectionScreen.UpdateHeroSelectionScreen(_hero);
        _selectButton.interactable = false;
    }

    private void SwitchHero(int index)
    {
        if (_hero != null)
        {
            Destroy(_hero.gameObject);
        }
        
        _hero = Instantiate(_heroesManager.Heroes[index], _heroPosition);
        _heroIndex = index;
        
        HeroSwitched?.Invoke(_hero);

        if (_heroesManager.Heroes[index].IsPurchased)
        {
            ButtonsUpdate();
            return;
        }
        
        _buyButton.gameObject.SetActive(true);
        _buyButton.interactable = true;
        _selectButton.interactable = false;
    }

    public void BuyHero()
    {
        _moneyManager.HeroBought += _heroesManager.Heroes[_heroIndex].MarkHero;
        _moneyManager.HeroBought += ButtonsUpdate;

        var price = _heroesManager.Heroes[_heroIndex].HeroSettings.Price;
        BuyButtonPushed?.Invoke(price);
    }

    private void ButtonsUpdate()
    {
        _buyButton.interactable = false;
        _buyButton.gameObject.SetActive(false);
        _selectButton.interactable = true;
    }
}
