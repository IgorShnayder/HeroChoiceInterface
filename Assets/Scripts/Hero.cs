using UnityEngine;

public class Hero : MonoBehaviour
{
    public HeroSettings HeroSettings => _heroSettings;
    public bool IsPurchased { get; private set; }
    public bool IsHeroOnScene { get; private set; }
    
    [SerializeField] private HeroSettings _heroSettings;
    
    public void MarkHeroPurchased()
    {
        IsPurchased = true;
    }

    public void MarkHeroOnScene()
    {
        IsHeroOnScene = true;
    }
}
