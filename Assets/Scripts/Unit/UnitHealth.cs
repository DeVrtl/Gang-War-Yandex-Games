using GangWar.BattleSystem;
using GangWar.UI.HealthBar;
using System;
using UnityEngine;

namespace GangWar.Unit
{
    [RequireComponent(typeof(Unit))]
    public class UnitHealth : Health
    {
        [SerializeField] private HealthBarFader _fader;
        
        public bool IsDead { get; private set; } = false;

        public event Action Died;

        protected override void CheackStatus()
        {
            if (HealthAmount <= 0)
            {
                IsDead = true;
                Died?.Invoke();
                gameObject.SetActive(false);
            }
        }

        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
            _fader.FadeIn();
        }
    }
}
