using UnityEngine;

public class UnitBullet : Bullet
{
    private void OnCollisionEnter(Collision collision)
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
