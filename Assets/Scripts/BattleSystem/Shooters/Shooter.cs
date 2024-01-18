namespace GangWar.BattleSystem.Shooters
{
    using UnityEngine;

    public abstract class Shooter : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _shootEffect;
        [SerializeField] private AudioSource _source;
        [SerializeField] private ObjectPool _bulletPool;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _fireRate;

        public ParticleSystem ShootEffect => _shootEffect;

        public AudioSource Source => _source;

        public ObjectPool BulletPool => _bulletPool;

        public Transform Barrel => _barrel; 

        public float FireRate => _fireRate;

        public void SetPool(ObjectPool pool)
        {
            _bulletPool = pool;
        }
    }
}