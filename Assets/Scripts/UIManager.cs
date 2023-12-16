using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _lobbyInterface;
    [SerializeField] private CanvasGroup _heroSelectionInterface;
    
    public void SwitchToLobbyInterface()
    {
        EnableInterface(_lobbyInterface);
        DisableInterface(_heroSelectionInterface);
    }

    public void SwitchToHeroSelectionInterface()
    {
        EnableInterface(_heroSelectionInterface);
        DisableInterface(_lobbyInterface);
    }

    private void EnableInterface(CanvasGroup gameInterface)
    {
        gameInterface.alpha = 1.0f;
        gameInterface.interactable = true;
        gameInterface.blocksRaycasts = true;
    }

    private void DisableInterface(CanvasGroup gameInterface)
    {
        gameInterface.alpha = 0.0f;
        gameInterface.interactable = false;
        gameInterface.blocksRaycasts = false;
    }
}
