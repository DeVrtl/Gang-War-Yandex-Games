using GangWar.BattleSystem;
using GangWar.Unit;
using UnityEngine;

namespace GangWar.Enemy
{
    public class EnemyBullet : Bullet
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out UnitHealth health))
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