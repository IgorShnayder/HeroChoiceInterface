using System;
using UnityEngine;

public class UIScreenChanger : MonoBehaviour
{
    public event Action SwitchToLobbyScreen;
    public event Action SwitchToHeroSelectionScreen;
    
    [SerializeField] private CanvasGroup _lobbyInterface;
    [SerializeField] private CanvasGroup _heroSelectionInterface;

    private void Awake()
    {
        SwitchToLobbyScreen += SwitchToLobbyScreenInterface;
        SwitchToHeroSelectionScreen += SwitchToHeroSelectionScreenInterface;
    }

    private void OnDestroy()
    {
        SwitchToLobbyScreen -= SwitchToLobbyScreenInterface;
        SwitchToHeroSelectionScreen -= SwitchToHeroSelectionScreenInterface;
    }

    public void ChangeToLobbyScreen()
    {
        SwitchToLobbyScreen?.Invoke();
    }

    public void ChangeToHeroSelectionScreen()
    {
        SwitchToHeroSelectionScreen?.Invoke();
    }
    
    private void SwitchToLobbyScreenInterface()
    {
        EnableInterface(_lobbyInterface);
        DisableInterface(_heroSelectionInterface);
    }

    private void SwitchToHeroSelectionScreenInterface()
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
