using UnityEngine;

namespace GangWar.Cell
{
    using GangWar.BattleSystem.Shooters;
    using GangWar.Unit;

    public class CellObjectPoolAssigner : MonoBehaviour
    {
        [SerializeField] private ObjectPool _bulletPool;
        [SerializeField] private ObjectPool _granadePool;
        [SerializeField] private ObjectPool _shotgunBullet;

        private Shooter _shooter;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Shooter shooter))
            {
                _shooter = shooter;
            }

            if (other.TryGetComponent(out Unit unit))
            {
                switch (unit.Class)
                {
                    case UnitClass.SMG:
                        _shooter.SetPool(_bulletPool);
                        break;

                    case UnitClass.Shotgun:
                        _shooter.SetPool(_shotgunBullet);
                        break;

                    case UnitClass.GranadeLauncher:
                        _shooter.SetPool(_granadePool);
                        break;
                }
            }
        }
    }
}