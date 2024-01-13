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
    private Hero[] _heroesPool;
    private int _lastSelectedHeroIndex;
    private MoneyManager _moneyManager;
    private HeroesPrefabManager _heroesPrefabManager;
    
    public void Initialize(HeroesPrefabManager heroesPrefabManager, MoneyManager moneyManager)
    {
        _heroesPrefabManager = heroesPrefabManager;
        _moneyManager = moneyManager;
        var massiveLength = heroesPrefabManager.Heroes.Count;
        _heroesPool = new Hero[massiveLength];
        _heroesQuantity = massiveLength;
    }

    public void ShowHero()
    {
        if (CurrentHero == null)
        {
            ShowHeroForFirstTime();
            return;
        }
        
        CurrentHero.gameObject.SetActive(true);
        HeroSwitched?.Invoke(CurrentHero);

        if (CurrentHero.IsPurchased)
        {
            ShowSelectButton?.Invoke();
        }
    }
    
    private void ShowHeroForFirstTime()
    {
        InstantiateHero(0);
            
        CurrentHero.gameObject.SetActive(true);
        HeroSwitched?.Invoke(CurrentHero); 
        ShowBuyButton?.Invoke();
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
        if (_heroesPool[index] != null && _heroesPool[index].IsHeroOnScene)
        {
            CurrentHero = _heroesPool[index];
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
        CurrentHero = Instantiate(_heroesPrefabManager.Heroes[index], _heroPosition);
        _heroesPool[index] = CurrentHero;
        _heroesPool[index].MarkHeroOnScene();
    }
    
    public void TryBuyHero()
    {
        var price = CurrentHero.HeroSettings.Price;

        if (!_moneyManager.TryPurchase(price)) return;
        
        _heroesPool[_currentHeroIndex].MarkHeroPurchased();
        HeroPurchased?.Invoke();
    }
    
    public bool IsHeroAlreadyPurchased()
    {
        var isBought = _heroesPool[_currentHeroIndex].IsPurchased;
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
