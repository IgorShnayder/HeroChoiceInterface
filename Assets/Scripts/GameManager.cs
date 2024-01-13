using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HeroesPrefabManager _heroesPrefabManager;
    [SerializeField] private HeroSelectionManager _heroSelectionManager;
    [SerializeField] private MoneyView _moneyView;
    [SerializeField] private MoneyManager _moneyManager;
    [SerializeField] private LobbyScreen _lobbyScreen;
    [SerializeField] private HeroSelectionScreen _heroSelectionScreen;
    [SerializeField] private UIScreenChanger _uiScreenChanger;
    
    private void Awake()
    { 
        _heroSelectionManager.Initialize(_heroesPrefabManager, _moneyManager);
        _moneyView.Initialize(_moneyManager);
        _lobbyScreen.Initialize(_heroSelectionManager, _uiScreenChanger);
        _heroSelectionScreen.Initialize(_heroSelectionManager, _uiScreenChanger);
    }
}
