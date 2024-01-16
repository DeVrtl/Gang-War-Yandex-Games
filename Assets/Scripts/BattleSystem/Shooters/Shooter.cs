namespace GangWar.BattleSystem.Shooters
{
    using UnityEngine;

    public abstract class Shooter : MonoBehaviour
    {
        [field: SerializeField] public ParticleSystem ShootEffect;
        [field: SerializeField] public AudioSource Source;
        [field: SerializeField] public ObjectPool BulletPool;
        [field: SerializeField] public Transform Barrel;
        [field: SerializeField] public float FireRate;

        public void SetPool(ObjectPool pool)
        {
            BulletPool = pool;
        }
    }
}