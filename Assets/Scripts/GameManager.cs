using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HeroesConfigurator heroesConfigurator;
    [SerializeField] private HeroSelectionManager _heroSelectionManager;
    [SerializeField] private MoneyManager _moneyManager;
    [SerializeField] private LobbyScreen _lobbyScreen;
    [SerializeField] private HeroSelectionScreen _heroSelectionScreen;
    [SerializeField] private UIScreenChanger _uiScreenChanger;
    
    private void Awake()
    { 
        _heroSelectionManager.Initialize(heroesConfigurator, _moneyManager);
        _lobbyScreen.Initialize(_moneyManager, _heroSelectionManager, _uiScreenChanger);
        _heroSelectionScreen.Initialize(heroesConfigurator, _moneyManager, _heroSelectionManager, _uiScreenChanger);
    }
}
