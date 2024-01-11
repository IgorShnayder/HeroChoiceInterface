using System;
using UnityEngine;

[Serializable]
public class HeroSettings
{
   [field: SerializeField] public string Name { get; private set; }
   [field: SerializeField] public string Description { get; private set; }
   [field: SerializeField] public Sprite HeroClassIcon { get; private set; }
   [field: SerializeField] public int Level { get; private set; }
   [field: SerializeField] public int Experience { get; private set; }
   [field: SerializeField] public int Price { get; private set; }
   [field: SerializeField] public int Health { get; private set; }
   [field: SerializeField] public int Attack { get; private set; }
   [field: SerializeField] public int Defence { get; private set; }
   [field: SerializeField] public int Speed { get; private set; }
}
