using GangWar.BattleSystem;

namespace GangWar.Enemy
{
    using UnityEngine;

    public class EnemyHealth : Health
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private ParticleSystem _deathEffect;
        [SerializeField] private Money _money;

        private void OnDisable()
        {
            _deathEffect.Play();
            _source.Play();
        }

        protected override void CheackStatus()
        {
            if (HealthAmount <= 0)
            {
                gameObject.SetActive(false);
                _money.gameObject.SetActive(true);
            }
        }
    }
}