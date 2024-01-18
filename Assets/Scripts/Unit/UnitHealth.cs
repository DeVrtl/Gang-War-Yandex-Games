using System;
using UnityEngine;
using GangWar.BattleSystem;
using GangWar.UI.HealthBar;

namespace GangWar.Unit
{
    [RequireComponent(typeof(Unit))]
    public class UnitHealth : Health
    {
        [SerializeField] private HealthBarFader _fader;
        
        public event Action Died;

        public bool IsDead { get; private set; } = false;

        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
            _fader.FadeIn();
        }

        protected override void CheackStatus()
        {
            if (HealthAmount <= 0)
            {
                IsDead = true;
                Died?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}
