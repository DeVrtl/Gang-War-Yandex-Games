using System;
using UnityEngine;

namespace GangWar.BattleSystem
{
    public abstract class Health : MonoBehaviour
    {
        [SerializeField] private int _healthAmount;

        public event Action<int> HealthChanged;

        public int HealthAmount => _healthAmount;

        public virtual void TakeDamage(int amount)
        {
            _healthAmount -= amount;

            HealthChanged?.Invoke(_healthAmount);

            CheackStatus();
        }

        protected virtual void CheackStatus()
        {
            if (_healthAmount <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}