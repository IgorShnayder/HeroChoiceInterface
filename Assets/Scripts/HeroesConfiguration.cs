using System.Collections.Generic;
using UnityEngine;

public class HeroesConfiguration : MonoBehaviour
{ 
    [field: SerializeField]public List<Hero> Heroes { get; private set; }
}
 