using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelectionManager : MonoBehaviour
{
    public event Action<Hero> HeroSwitched;
    public event Action<Hero> HeroSelected;
    public event Action<Hero> BuyButtonPushed;
    public event Action SelectButtonPushed;
    public event Action ReturnButtonPushed;
    public event Action<int> IndexChanged;
    
    [SerializeField] private Transform _heroPosition;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _selectButton;
    [SerializeField] private Button _returnButton;
    
    private List<Hero> _heroesOnScene;
    private Hero _hero;
    private Hero _lastPurchasedHero;
    private int _heroIndex;
    private MoneyManager _moneyManager;
    private bool _isHeroOnScene;
    private HeroesConfigurator _heroesConfigurator;
    
    public void Initialize(HeroesConfigurator heroesConfigurator, MoneyManager moneyManager)
    {
        _heroesConfigurator = heroesConfigurator;
        _moneyManager = moneyManager;
        _heroesOnScene = new List<Hero>();
        
        BuyButtonPushed += _moneyManager.IsMoneyEnough;
        _moneyManager.HeroBought += UpdateButtons;
        _buyButton.onClick.AddListener(BuyHero);
        _selectButton.onClick.AddListener(SelectHero);
        _returnButton.onClick.AddListener(PushReturnButton);
    }
    
    private void OnDestroy()
    {
        BuyButtonPushed -= _moneyManager.IsMoneyEnough;
        _moneyManager.HeroBought -= UpdateButtons;
        _buyButton.onClick.RemoveAllListeners();
        _selectButton.onClick.RemoveAllListeners();
        _returnButton.onClick.RemoveAllListeners();
    }
    
    public void FillHeroSelectionScreen()
    {
        if (_hero != null && !_hero.IsPurchased)
        {
            _hero.gameObject.SetActive(true);
            return;
        }

        if (_hero != null && _hero.IsPurchased || _heroesConfigurator.Heroes.Count == 0)
        {
            _heroIndex = _heroesOnScene.IndexOf(_hero);
            HeroSwitched?.Invoke(_heroesOnScene[_heroIndex]); 
            UpdateButtons();
            IndexChanged?.Invoke(_heroIndex);
            return;
        }
        
        _hero = Instantiate(_heroesConfigurator.Heroes[0], _heroPosition);
        _heroesOnScene.Add(_hero);
        HeroSwitched?.Invoke(_heroesOnScene[0]); 
        _selectButton.interactable = false;
    }
    
    public void SwitchHero(int index)
    {
        if (_hero != null)
        {
            _hero.gameObject.SetActive(false);
        }
        
        if (_heroesOnScene.Count > 1)
        {
            var any = false;
            
            foreach (var hero in _heroesOnScene)
            {
                if (hero.HeroSettings.Name == _heroesConfigurator.Heroes[index].HeroSettings.Name)
                {
                    any = true;
                    break;
                }
            }

            _isHeroOnScene = any;
        }
        
        if (_isHeroOnScene)
        {
            foreach (var hero in _heroesOnScene)
            {
                if (hero.HeroSettings.Name != _heroesConfigurator.Heroes[index].HeroSettings.Name) continue;
                
                hero.gameObject.SetActive(true);
                _heroIndex = _heroesOnScene.IndexOf(hero);
                _hero = hero;
                break;
            }
        }
        
        else
        {
            _hero = Instantiate(_heroesConfigurator.Heroes[index], _heroPosition);
            _heroesOnScene.Add(_hero);
            _heroIndex = _heroesOnScene.IndexOf(_hero);
        }
        
        HeroSwitched?.Invoke(_heroesOnScene[_heroIndex]);

        if (IsHeroAlreadyPurchased()) return;
        
        _buyButton.gameObject.SetActive(true);
        _buyButton.interactable = true;
        _selectButton.interactable = false;
    }
    
    private void BuyHero()
    {
        BuyButtonPushed?.Invoke(_hero);

        if (_hero.IsPurchased)
        {
            _lastPurchasedHero = _hero;
        }

        IsHeroAlreadyPurchased();
    }
    
    private bool IsHeroAlreadyPurchased()
    {
        var isBought = _heroesOnScene[_heroIndex].IsPurchased;

        if (!isBought) return false;
        
        UpdateButtons();
        return true;
    }
    
    private void UpdateButtons()
    {
        _buyButton.interactable = false;
        _buyButton.gameObject.SetActive(false);
        _selectButton.interactable = true;
    }
    
    private void SelectHero()
    { 
        HeroSelected?.Invoke(_hero);
        SelectButtonPushed?.Invoke();
    }

    private void PushReturnButton()
    {
        ReturnButtonPushed?.Invoke();
        
        if (_hero.IsPurchased)
        {
            HeroSelected?.Invoke(_hero);
            return;
        }
        
        _hero.gameObject.SetActive(false);

        if (_lastPurchasedHero == null) return;
        
        _hero = _lastPurchasedHero;
        _hero.gameObject.SetActive(true);
        HeroSelected?.Invoke(_hero);
    }
}
