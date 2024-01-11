using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyView;
    
    public void Initialize(int playerMoney)
    {
        _moneyView.text = playerMoney.ToString();
    }
    
    public void UpdateMoneyView(int money)
    {
        _moneyView.text = money.ToString();
    }
}
