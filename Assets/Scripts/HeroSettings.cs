using System;
using UnityEngine;

[Serializable]
public class HeroSettings
{
   public string Name => _name;
   public string Description => _description;
   public Sprite HeroClassIcon => _heroClassIcon;
   public int Level => _level;
   public int Experience => _experience;
   public int Price => _price;
   public int Health => _health;
   public int Attack => _attack;
   public int Defence => _defence;
   public int Speed => _speed;
   
   [SerializeField] private string _name;
   [SerializeField] private string _description;
   [SerializeField] private Sprite _heroClassIcon;
   [SerializeField] private int _level;
   [SerializeField] private int _experience;
   [SerializeField] private int _price;
   [SerializeField] private int _health;
   [SerializeField] private int _attack;
   [SerializeField] private int _defence;
   [SerializeField] private int _speed;
}
