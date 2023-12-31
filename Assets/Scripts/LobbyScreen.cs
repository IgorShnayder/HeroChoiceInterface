using UnityEngine;
using Slider = UnityEngine.UI.Slider;
using TMPro;
using UnityEngine.UI;

public class LobbyScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _heroName;
    [SerializeField] private TextMeshProUGUI _heroLevel;
    [SerializeField] private Slider _heroExperience;
    [SerializeField] private Button _heroSelectionButton;
    [SerializeField] private MoneyView _moneyView;

    private HeroSelectionManager _heroSelectionManager;
    private UIScreenChanger _uiScreenChanger;
    
    public void Initialize(MoneyManager moneyManager, HeroSelectionManager heroSelectionManager, UIScreenChanger uiScreenChanger)
    {
        _moneyView.Initialize(moneyManager);
        _heroSelectionManager = heroSelectionManager;
        _uiScreenChanger = uiScreenChanger;
        _uiScreenChanger.GoToHeroSelection += _heroSelectionManager.FillHeroSelectionScreen;
        _heroSelectionManager.HeroSelected += UpdateHeroInformation;
    }
    
    private void Start()
    {
        _heroSelectionButton.onClick.AddListener(ChangeScreenToHeroSelection);
    }

    private void OnDestroy()
    {
        _uiScreenChanger.GoToHeroSelection -= _heroSelectionManager.FillHeroSelectionScreen;
        _heroSelectionManager.HeroSelected -= UpdateHeroInformation;
        _heroSelectionButton.onClick.RemoveAllListeners();
    }

    private void UpdateHeroInformation(Hero hero)
    {
        if (hero == null || !hero.IsPurchased)
        {
            _heroName.text = "";
            _heroLevel.text = "";
            _heroExperience.value = 0;
            return;
        }
        
        _heroName.text = hero.HeroSettings.Name;
        _heroLevel.text = hero.HeroSettings.Level.ToString();
        _heroExperience.value = hero.HeroSettings.Experience;
    }

    private void ChangeScreenToHeroSelection()
    {
        _uiScreenChanger.ChangeToHeroSelectionScreen();
    }
}
