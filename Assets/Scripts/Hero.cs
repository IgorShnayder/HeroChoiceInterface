using UnityEngine;

public class Hero : MonoBehaviour
{
    public HeroSettings HeroSettings => _heroSettings;
    public bool IsPurchased { get; private set; }
     
    [SerializeField] private HeroSettings _heroSettings;

    public void MarkHero()
    {
        IsPurchased = true;
    }
}
