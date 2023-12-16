using System;
using UnityEngine;

public class HeroSwitcher : MonoBehaviour
{
    public event Action<int> SwitchButtonPushed;
    
    private int _index;
    private int _heroesQuantity;
    
    public void Initialize(int heroesQuantity)
    {
        _heroesQuantity = heroesQuantity;
    }
    
    public void IncreaseHeroIndex()
    {
        _index++;

        if (_index == _heroesQuantity)
        {
            _index = 0;
        }
        
        SwitchButtonPushed?.Invoke(_index);
    }

    public void DecreaseHeroIndex()
    {
        _index--;
        
        if (_index < 0)
        {
            _index = _heroesQuantity - 1;
        }
        
        SwitchButtonPushed?.Invoke(_index);
    }
}
