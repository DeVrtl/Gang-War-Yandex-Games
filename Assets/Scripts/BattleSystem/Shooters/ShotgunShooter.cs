using UnityEngine;

namespace GangWar.BattleSystem.Shooters
{
    public class ShotgunShooter : Shooter
    {
        private const int Divident = 1;

        [SerializeField] private Transform[] _barrels;

        private float _lastFireTime;

        private void Update()
        {
            if (Time.time > (Divident / FireRate) + _lastFireTime)
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
}