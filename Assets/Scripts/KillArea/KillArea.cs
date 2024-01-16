using GangWar.BattleSystem;
using GangWar.Enemy;
using UnityEngine;

namespace GangWar.KillArea
{
    public class KillArea : Bullet
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out EnemyHealth health))
            {
                health.TakeDamage(Damage);
            }
        }
    }
}