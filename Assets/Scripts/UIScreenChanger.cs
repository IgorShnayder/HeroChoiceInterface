using System;
using UnityEngine;

public class UIScreenChanger : MonoBehaviour
{
    public event Action GoToLobby;
    public event Action GoToHeroSelection;
    
    [SerializeField] private CanvasGroup _lobbyInterface;
    [SerializeField] private CanvasGroup _heroSelectionInterface;

    private void Awake()
    {
        GoToLobby += SwitchToLobbyInterface;
        GoToHeroSelection += SwitchToHeroSelectionInterface;
    }

    private void OnDestroy()
    {
        GoToLobby -= SwitchToLobbyInterface;
        GoToHeroSelection -= SwitchToHeroSelectionInterface;
    }

    public void ChangeToLobbyScreen()
    {
        GoToLobby?.Invoke();
    }

    public void ChangeToHeroSelectionScreen()
    {
        GoToHeroSelection?.Invoke();
    }
    
    private void SwitchToLobbyInterface()
    {
        EnableInterface(_lobbyInterface);
        DisableInterface(_heroSelectionInterface);
    }

    private void SwitchToHeroSelectionInterface()
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
