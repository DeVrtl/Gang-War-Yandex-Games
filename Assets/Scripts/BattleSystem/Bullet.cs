namespace GangWar.BattleSystem
{
    using UnityEngine;

    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;

        [field: SerializeField] public int Damage;
        [field: SerializeField] public ParticleSystem HitEffect;

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