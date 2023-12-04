using UnityEngine;

public class GangLeaderBullet : Bullet
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out EnemyHealth health))
        {
            health.TakeDamage(Damage);
        }
    }
}
