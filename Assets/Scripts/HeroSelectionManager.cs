using System;
using UnityEngine;

public class HeroSelectionManager : MonoBehaviour
{
    public Hero CurrentHero { get; private set; }
    public Hero LastSelectedHero { get; private set; }
    
    public event Action<Hero> HeroSwitched;
    public event Action<Hero> HeroSelected;
    public event Action HeroPurchased;
    public event Action SelectButtonPushed;
    public event Action ShowSelectButton;
    public event Action ShowBuyButton;
    
    [SerializeField] private Transform _heroPosition;
    
    private int _currentHeroIndex;
    private int _heroesQuantity;
    private Hero[] _heroesPull;
    private int _lastSelectedHeroIndex;
    private MoneyManager _moneyManager;
    private HeroesConfigurator _heroesConfigurator;
    
    public void Initialize(HeroesConfigurator heroesConfigurator, MoneyManager moneyManager)
    {
        _heroesConfigurator = heroesConfigurator;
        _moneyManager = moneyManager;
        _heroesPull = new Hero[heroesConfigurator.Heroes.Count];
        _heroesQuantity = heroesConfigurator.Heroes.Count;
    }

    private void SwitchHero(int index)
    {
        if (CurrentHero != null)
        {
            CurrentHero.gameObject.SetActive(false);
        }

        TryActivateHero(index);
    }
    
    private void TryActivateHero(int index)
    {
        if (_heroesPull[index] != null && _heroesPull[index].IsHeroOnScene)
        {
            CurrentHero = _heroesPull[index];
        }
        else
        {
            InstantiateHero(index);
        }
        
        CurrentHero.gameObject.SetActive(true);
        HeroSwitched?.Invoke(CurrentHero);
    }

    private void InstantiateHero(int index)
    {
        CurrentHero = Instantiate(_heroesConfigurator.Heroes[index], _heroPosition);
        _heroesPull[index] = CurrentHero;
        _heroesPull[index].MarkHeroOnScene();
    }
    
    public void FillHeroSelectionScreen()
    {
        if (CurrentHero == null)
        {
            FillScreenForFirstTime();
            return;
        }
        
        CurrentHero.gameObject.SetActive(true);
        HeroSwitched?.Invoke(CurrentHero);

        if (CurrentHero.IsPurchased)
        {
            ShowSelectButton?.Invoke();
        }
    }

    private void FillScreenForFirstTime()
    {
        CurrentHero = Instantiate(_heroesConfigurator.Heroes[0], _heroPosition);
        _heroesPull[0] = CurrentHero;
        _heroesPull[0].MarkHeroOnScene(); 
            
        CurrentHero.gameObject.SetActive(true);
        HeroSwitched?.Invoke(CurrentHero); 
        ShowBuyButton?.Invoke();
    }
    
    public void TryBuyHero()
    {
        var price = CurrentHero.HeroSettings.Price;

        if (!_moneyManager.TryPurchase(price)) return;
        
        _heroesPull[_currentHeroIndex].MarkHeroPurchased();
        HeroPurchased?.Invoke();
    }
    
    public bool IsHeroAlreadyPurchased()
    {
        var isBought = _heroesPull[_currentHeroIndex].IsPurchased;
        return isBought;
    }
    
    public void ChooseNextHero()
    {
        _currentHeroIndex++;

        if (_currentHeroIndex == _heroesQuantity)
        {
            _currentHeroIndex = 0;
        }
        
        SwitchHero(_currentHeroIndex);
    }

    public void ChoosePreviousHero()
    {
        _currentHeroIndex--;
        
        if (_currentHeroIndex < 0)
        {
            _currentHeroIndex = _heroesQuantity - 1;
        }
        
        SwitchHero(_currentHeroIndex);
    }
    
    public void SelectHero()
    { 
        LastSelectedHero = CurrentHero;
        _lastSelectedHeroIndex = _currentHeroIndex;
        
        HeroSelected?.Invoke(LastSelectedHero);
        SelectButtonPushed?.Invoke();
    }

    public void HandOverSelectedHero()
    {
        CurrentHero.gameObject.SetActive(false);
        CurrentHero = LastSelectedHero;
        _currentHeroIndex = _lastSelectedHeroIndex;
        CurrentHero.gameObject.SetActive(true);
        
        HeroSelected?.Invoke(CurrentHero);
    }
}
