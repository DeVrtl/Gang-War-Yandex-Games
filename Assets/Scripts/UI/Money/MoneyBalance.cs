using UnityEngine;
using TMPro;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private PlayerWallet _playerWallet;

    private void OnEnable()
    {
        _playerWallet.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _playerWallet.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _money.text = money.ToString();
    }
}
