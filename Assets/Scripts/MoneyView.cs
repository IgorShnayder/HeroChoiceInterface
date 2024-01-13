using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _moneyViews;
    private MoneyManager _moneyManager;
    
    public void Initialize(MoneyManager moneyManager)
    {
        _moneyManager = moneyManager;
        _moneyManager.PlayerMoneyChanged += UpdateMoneyViews;
        UpdateMoneyViews();
    }
    
    private void UpdateMoneyViews()
    {
        foreach (var moneyView in _moneyViews)
        {
            moneyView.text = _moneyManager.PlayerMoney.ToString();
        }
    }

    private void OnDestroy()
    {
        if (_moneyManager != null)
        {
            _moneyManager.PlayerMoneyChanged -= UpdateMoneyViews;
        }
    }
}
