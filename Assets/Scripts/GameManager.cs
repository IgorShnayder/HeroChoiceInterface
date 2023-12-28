using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HeroesConfiguration _heroesConfiguration;
    [SerializeField] private HeroSelectionManager _heroSelectionManager;
    [SerializeField] private MoneyManager _moneyManager;
    [SerializeField] private LobbyScreen _lobbyScreen;
    [SerializeField] private HeroSelectionScreen _heroSelectionScreen;
    [SerializeField] private UIScreenChanger _uiScreenChanger;
    
    private void Awake()
    { 
        _heroSelectionManager.Initialize(_heroesConfiguration, _moneyManager);
        _lobbyScreen.Initialize(_moneyManager, _heroSelectionManager, _uiScreenChanger);
        _heroSelectionScreen.Initialize(_heroesConfiguration, _moneyManager, _heroSelectionManager, _uiScreenChanger);
    }
}
