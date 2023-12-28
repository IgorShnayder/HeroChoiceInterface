using System;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public HeroSettings HeroSettings => _heroSettings;
    public bool IsPurchased { get; private set; }

    [SerializeField] private bool _isPurchasedChek;
     
    [SerializeField] private HeroSettings _heroSettings;
    
    private void Update()
    {
        _isPurchasedChek = IsPurchased;
    }
    
    public void MarkHero()
    {
        IsPurchased = true;
    }
}
