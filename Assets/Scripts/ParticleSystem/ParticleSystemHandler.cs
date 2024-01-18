namespace GangWar.ParticleSystem
{
    using GangWar.Unit;
    using UnityEngine;

    [RequireComponent(typeof(ParticleSystemFollow))]
    public class ParticleSystemHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private ParticleSystem _effect;

        private UnitHealth _health;
        private ParticleSystemFollow _follow;

        public AudioSource Source => _source;

        private void OnDisable()
        {
            UnSubcribe();
        }

        private void Awake()
        {
            GetComponent();
        }

        private void Start()
        {
            Subcribe();
        }

        public void Initialize(UnitHealth health, Unit unit)
        {
            _health = health;
            _follow.SetTarget(unit);
        }

        private void Subcribe()
        {
            _health.Died += OnDied;
        }

        private void UnSubcribe()
        {
            _health.Died -= OnDied;
        }

        private void GetComponent()
        {
            _follow = GetComponent<ParticleSystemFollow>();
        }

        private void OnDied()
        {
            _follow.enabled = false;

            _effect.Play();
            _source.Play();
        }
    }
}