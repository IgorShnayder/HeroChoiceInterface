using UnityEngine;

public class HeroSelectionScreen : MonoBehaviour
{
    [SerializeField] private MoneyView _moneyView;
    [SerializeField] private HeroParametersView _heroParametersView;
    [SerializeField] private HeroSwitcher _heroSwitcher;
    
    private HeroSelectionManager _heroSelectionManager;
    private UIScreenChanger _uiScreenChanger;
    private Hero _hero;
    
    public void Initialize(HeroesConfigurator heroesConfigurator, MoneyManager moneyManager, HeroSelectionManager heroSelectionManager, UIScreenChanger uiScreenChanger)
    {
        _moneyView.Initialize(moneyManager);
        _heroSelectionManager = heroSelectionManager;
        _uiScreenChanger = uiScreenChanger;
        
        var heroesQuantity = heroesConfigurator.Heroes.Count;
        _heroSwitcher.Initialize(heroesQuantity);
        
        _heroSwitcher.SwitchButtonPushed += _heroSelectionManager.SwitchHero;
        _heroSelectionManager.IndexChanged += _heroSwitcher.ChangeIndex;
        _heroSelectionManager.HeroSwitched += UpdateHeroSelectionScreen;
        _heroSelectionManager.SelectButtonPushed += _uiScreenChanger.ChangeToLobbyScreen;
        _heroSelectionManager.ReturnButtonPushed += _uiScreenChanger.ChangeToLobbyScreen;
    }
    
    private void OnDestroy()
    {
        _heroSwitcher.SwitchButtonPushed -= _heroSelectionManager.SwitchHero;
        _heroSelectionManager.IndexChanged -= _heroSwitcher.ChangeIndex;
        _heroSelectionManager.HeroSwitched -= UpdateHeroSelectionScreen;
        _heroSelectionManager.SelectButtonPushed -= _uiScreenChanger.ChangeToLobbyScreen;
        _heroSelectionManager.ReturnButtonPushed -= _uiScreenChanger.ChangeToLobbyScreen;
    }

    private void UpdateHeroSelectionScreen(Hero hero)
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
}
