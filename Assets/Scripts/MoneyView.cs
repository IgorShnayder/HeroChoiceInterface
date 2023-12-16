using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyView;

    private MoneyManager _moneyManager;
    
    public void Initialize(MoneyManager moneyManager)
    {
        _moneyManager = moneyManager;
        _moneyView.text = _moneyManager.PlayerMoney.ToString();
        _moneyManager.PlayerMoneyChanged += UpdateMoneyView;
    }

    private void UpdateMoneyView(int money)
    {
        _moneyView.text = money.ToString();
    }
}
