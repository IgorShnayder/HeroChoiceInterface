using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[Serializable]
public class HeroParametersView 
{
    [SerializeField] public TextMeshProUGUI Name;
    [SerializeField] public TextMeshProUGUI Description;
    [SerializeField] public Image ClassIcon;
    [SerializeField] public TextMeshProUGUI LevelCounter;
    [SerializeField] public Slider ExperienceCounter;
    [SerializeField] public TextMeshProUGUI Price;
    [SerializeField] public Slider Health;
    [SerializeField] public Slider Attack;
    [SerializeField] public Slider Defence;
    [SerializeField] public Slider Speed;
}
