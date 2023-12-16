using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelectionScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Image _classIcon;
    [SerializeField] private TextMeshProUGUI _levelCounter;
    [SerializeField] private Slider _experienceCounter;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private Slider _health;
    [SerializeField] private Slider _attack;
    [SerializeField] private Slider _defence;
    [SerializeField] private Slider _speed;
    
    public void UpdateHeroSelectionScreen(Hero hero)
    {
        _name.text = hero.HeroSettings.Name;
        _description.text = hero.HeroSettings.Description;
        _classIcon.sprite = hero.HeroSettings.HeroClassIcon;
        _levelCounter.text = hero.HeroSettings.Level.ToString();
        _experienceCounter.value = hero.HeroSettings.Experience;
        _price.text = hero.HeroSettings.Price.ToString();
        _health.value = hero.HeroSettings.Health;
        _attack.value = hero.HeroSettings.Attack;
        _defence.value = hero.HeroSettings.Defence;
        _speed.value = hero.HeroSettings.Speed;
    }
}
