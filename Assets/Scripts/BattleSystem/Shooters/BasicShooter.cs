using UnityEngine;

namespace GangWar.BattleSystem.Shooters
{
    public class BasicShooter : Shooter
    {
        private const int Divident = 1;

        private float _lastFireTime;

        private void Update()
        {
            if (Time.time > (Divident / FireRate) + _lastFireTime)
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
}