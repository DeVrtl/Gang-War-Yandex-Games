namespace GangWar.BattleSystem
{
    using UnityEngine;

    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private ParticleSystem _hitEffect;

        public int Damage => _damage;

        public ParticleSystem HitEffect => _hitEffect;

        private void Update()
        {
            transform.position += transform.forward * Time.deltaTime * _speed;
        }

        protected void SpawnHitEffect()
        {
            Instantiate(HitEffect, transform.position, Quaternion.identity);
        }
    }
}