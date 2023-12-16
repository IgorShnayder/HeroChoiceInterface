using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private HeroesManager _heroesManager;
    [SerializeField] private HeroSelectionManager _heroSelectionManager;
    [SerializeField] private LobbyScreen _lobbyScreen;
    [SerializeField] private MoneyManager _moneyManager;
    [SerializeField] private MoneyView _moneyViewLobby;
    [SerializeField] private MoneyView _moneyViewHeroSelectionScreen;

    private void Awake()
    {
        _heroSelectionManager.Initialize(_heroesManager, _moneyManager);
        _moneyViewLobby.Initialize(_moneyManager);
        _moneyViewHeroSelectionScreen.Initialize(_moneyManager);
    }
}
