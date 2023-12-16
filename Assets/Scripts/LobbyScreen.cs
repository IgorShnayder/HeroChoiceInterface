using UnityEngine;
using Slider = UnityEngine.UI.Slider;
using TMPro;

public class LobbyScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _heroName;
    [SerializeField] private TextMeshProUGUI _heroLevel;
    [SerializeField] private Slider _heroExperience;
    
    public void UpdateLobbyScreen(Hero hero)
    {
        if (hero == null) return;
        _heroName.text = hero.HeroSettings.Name;
        _heroLevel.text = hero.HeroSettings.Level.ToString();
        _heroExperience.value = hero.HeroSettings.Experience;
    }
}
