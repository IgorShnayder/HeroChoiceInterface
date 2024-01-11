using System;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelectionScreen : MonoBehaviour
{
    public event Action ReturnButtonPushed;
    
    [SerializeField] private HeroParametersView _heroParametersView;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _selectButton;
    [SerializeField] private Button _returnButton;
    
    private HeroSelectionManager _heroSelectionManager;
    private UIScreenChanger _uiScreenChanger;
    
    public void Initialize(HeroSelectionManager heroSelectionManager, UIScreenChanger uiScreenChanger)
    {
        _heroSelectionManager = heroSelectionManager;
        _uiScreenChanger = uiScreenChanger;

        _heroSelectionManager.HeroSwitched += ShowHero;
        _heroSelectionManager.ShowBuyButton += UpdateButtonsForByu;
        _heroSelectionManager.ShowSelectButton += UpdateButtonsForSelect;
        _heroSelectionManager.HeroPurchased += UpdateButtonsForSelect;
        _heroSelectionManager.SelectButtonPushed += _uiScreenChanger.ChangeToLobbyScreen;
        ReturnButtonPushed += _uiScreenChanger.ChangeToLobbyScreen;
        
        _buyButton.onClick.AddListener(_heroSelectionManager.TryBuyHero);
        _selectButton.onClick.AddListener(_heroSelectionManager.SelectHero);
        _returnButton.onClick.AddListener(PushReturnButton);
    }

    private void ShowHero(Hero hero)
    {
        UpdateHeroCharacteristics(hero);
        
        if (_heroSelectionManager.IsHeroAlreadyPurchased())
        {
            UpdateButtonsForSelect();
            return;
        }
        
        UpdateButtonsForByu();
    }

    private void PushReturnButton()
    {
        ReturnButtonPushed?.Invoke();

        if (_heroSelectionManager.LastSelectedHero != null)
        {
            _heroSelectionManager.HandOverSelectedHero();
            return;
        }
        
        _heroSelectionManager.CurrentHero.gameObject.SetActive(false);
    }
    
    private void UpdateButtonsForSelect()
    {
        _buyButton.interactable = false;
        _buyButton.gameObject.SetActive(false);
        _selectButton.interactable = true;
    }

    private void UpdateButtonsForByu()
    {
        _buyButton.gameObject.SetActive(true);
        _buyButton.interactable = true;
        _selectButton.interactable = false;
    }
    
    private void UpdateHeroCharacteristics(Hero hero)
    {
        _heroParametersView.Name.text = hero.HeroSettings.Name;
        _heroParametersView.Description.text = hero.HeroSettings.Description;
        _heroParametersView.ClassIcon.sprite = hero.HeroSettings.HeroClassIcon;
        _heroParametersView.LevelCounter.text = hero.HeroSettings.Level.ToString();
        _heroParametersView.ExperienceCounter.value = hero.HeroSettings.Experience;
        _heroParametersView.Price.text = hero.HeroSettings.Price.ToString();
        _heroParametersView.Health.value = hero.HeroSettings.Health;
        _heroParametersView.Attack.value = hero.HeroSettings.Attack;
        _heroParametersView.Defence.value = hero.HeroSettings.Defence;
        _heroParametersView.Speed.value = hero.HeroSettings.Speed;
    }
    
    private void OnDestroy()
    {
        _heroSelectionManager.HeroSwitched -= ShowHero;
        _heroSelectionManager.ShowBuyButton -= UpdateButtonsForByu;
        _heroSelectionManager.ShowSelectButton -= UpdateButtonsForSelect;
        _heroSelectionManager.HeroPurchased -= UpdateButtonsForSelect;
        _heroSelectionManager.SelectButtonPushed -= _uiScreenChanger.ChangeToLobbyScreen;
        ReturnButtonPushed -= _uiScreenChanger.ChangeToLobbyScreen;
        
        _buyButton.onClick.RemoveAllListeners();
        _selectButton.onClick.RemoveAllListeners();
        _returnButton.onClick.RemoveAllListeners();
    }
}
