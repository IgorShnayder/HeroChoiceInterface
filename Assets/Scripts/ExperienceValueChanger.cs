using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceValueChanger : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _experienceValue;
    
    public void UpdateText()
    {
        _experienceValue.text =  $"{_slider.value +"/"+ _slider.maxValue}";
    }
}
