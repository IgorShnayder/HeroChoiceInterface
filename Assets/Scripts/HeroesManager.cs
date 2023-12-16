using System.Collections.Generic;
using UnityEngine;

public class HeroesManager : MonoBehaviour
{
    public List<Hero> Heroes => _heroesList;
    
    [SerializeField] private List<Hero> _heroesList;
}
