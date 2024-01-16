using System;
using GangWar.Player;
using UnityEngine;
using UnityEngine.UI;

namespace GangWar.UI.UnitPurchase
{
    public class BuyUnitButton : MonoBehaviour
    {
        [SerializeField] private GameObject _notEnoguhMoneyCard;
        [SerializeField] private PlayerWallet _wallet;
        [SerializeField] private int _cost;

        private Button _button;

        public event Action UnitBought;

        private void OnEnable()
        {
            AddListener();
        }

        private void OnDisable()
        {
            RemoveListener();
        }

        private void Awake()
        {
            GetComponent();
        }

        private void AddListener()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void RemoveListener()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void GetComponent()
        {
            _button = GetComponent<Button>();
        }

        private void OnButtonClick()
        {
            if (_wallet.Amount < _cost)
            {
                _notEnoguhMoneyCard.SetActive(true);
                return;
            }

            _wallet.TakeMoney(_cost);

            UnitBought?.Invoke();

            _button.gameObject.SetActive(false);
        }
    }
}