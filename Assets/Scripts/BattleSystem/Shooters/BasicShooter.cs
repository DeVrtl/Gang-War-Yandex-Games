using UnityEngine;

public class BasicShooter : Shooter
{
    private float _lastFireTime;

    private void Update()
    {
        if (Time.time > (1 / FireRate) + _lastFireTime)
        {
            if (BulletPool.TryGetObject(out GameObject bullet))
            {
                BulletPool.SetObject(bullet, Barrel.position);

                ShootEffect.Play();
                Source.Play();

                _lastFireTime = Time.time;
            }
        }
    }
}