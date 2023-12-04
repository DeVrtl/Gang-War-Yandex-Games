using UnityEngine;

public class ShotgunShooter : Shooter
{
    [SerializeField] private Transform[] _barrels;

    private float _lastFireTime;

    private void Update()
    {
        if (Time.time > (1 / FireRate) + _lastFireTime)
        {
            foreach (var barrel in _barrels)
            {
                if (BulletPool.TryGetObject(out GameObject bullet))
                {
                    bullet.transform.rotation = Quaternion.identity;
                    BulletPool.SetObject(bullet, barrel.position);
                    bullet.transform.rotation = barrel.rotation;
                }
            }

            ShootEffect.Play();
            Source.Play();

            _lastFireTime = Time.time;
        }
    }
}