using System.Collections.Generic;
using UnityEngine;

public class HeroesPrefabManager : MonoBehaviour
{ 
    [field: SerializeField]public List<Hero> Heroes { get; private set; }
}
 