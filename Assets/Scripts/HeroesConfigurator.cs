using System.Collections.Generic;
using UnityEngine;

public class HeroesConfigurator : MonoBehaviour
{ 
    [field: SerializeField]public List<Hero> Heroes { get; private set; }
}
 