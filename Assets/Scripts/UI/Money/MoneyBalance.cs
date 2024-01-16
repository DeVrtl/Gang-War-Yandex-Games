using UnityEngine;
using TMPro;
using GangWar.Player;

namespace GangWar.UI.Money
{
    public class MoneyBalance : MonoBehaviour
    {
        [SerializeField] private TMP_Text _money;
        [SerializeField] private PlayerWallet _playerWallet;

        private void OnEnable()
        {
            Subcribe();
        }

        private void OnDisable()
        {
            UnSubcribe();
        }

        private void Subcribe()
        {
            _playerWallet.MoneyChanged += OnMoneyChanged;
        }

        private void UnSubcribe()
        {
            _playerWallet.MoneyChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged(int money)
        {
            _money.text = money.ToString();
        }
    }
}