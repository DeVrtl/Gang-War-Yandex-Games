using GangWar.BattleSystem;
using GangWar.Enemy;
using UnityEngine;

namespace GangWar.Unit
{
    public class UnitBullet : Bullet
    {
        private void OnCollisionEnter(Collision collision)
        {
            CollisionHandle(collision);
        }

        private void CollisionHandle(Collision collision)
        {
            if (collision.transform.TryGetComponent(out EnemyHealth health))
            {
                health.TakeDamage(Damage);
                gameObject.SetActive(false);
                SpawnHitEffect();
            }

            if (collision.transform.TryGetComponent(out Border border))
            {
                gameObject.SetActive(false);
                SpawnHitEffect();
            }
        }
    }
}