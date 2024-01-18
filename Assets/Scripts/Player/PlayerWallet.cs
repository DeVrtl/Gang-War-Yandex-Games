using System;
using UnityEngine;
using GangWar.Level;

namespace GangWar.Player
{
    public class PlayerWallet : MonoBehaviour
    {
        private const string MoneyAmount = "MoneyAmount";

        [SerializeField] private Finish _finish;

        public event Action<int> MoneyChanged;

        public int Amount { get; private set; } = 0;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Money money))
            {
                money.AddTo(this);
            }
        }

        private void OnEnable()
        {
            Subcribe();
        }

        private void OnDisable()
        {
            UnSubcribe();
        }

        private void Awake()
        {
            TryGetMoneyAmount();
        }

        private void Start()
        {
            RaiseEvent();
        }

        public void SaveMoney()
        {
            PlayerPrefs.SetInt(MoneyAmount, Amount);
            PlayerPrefs.Save();
        }

        public void AddMoney(int money)
        {
            Amount += money;
            MoneyChanged?.Invoke(Amount);
        }

        public void TakeMoney(int cost)
        {
            Amount -= cost;
            MoneyChanged?.Invoke(Amount);
        }

        private void Subcribe()
        {
            _finish.LevelCompleted += OnLevelCompleted;
        }

        private void UnSubcribe()
        {
            _finish.LevelCompleted -= OnLevelCompleted;
        }

        private void TryGetMoneyAmount()
        {
            if (PlayerPrefs.HasKey(MoneyAmount))
            {
                Amount = PlayerPrefs.GetInt(MoneyAmount);
            }
        }

        private void RaiseEvent()
        {
            MoneyChanged?.Invoke(Amount);
        }

        private void OnLevelCompleted()
        {
            SaveMoney();
        }
    }
}