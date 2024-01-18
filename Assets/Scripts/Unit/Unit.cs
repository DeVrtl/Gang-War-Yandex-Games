using GangWar.BattleSystem.Shooters;
using GangWar.ParticleSystem;
using UnityEngine;

namespace GangWar.Unit
{
    [RequireComponent(typeof(Shooter), typeof(UnitHealth))]
    public class Unit : MonoBehaviour
    {
        [SerializeField] private ParticleSystemHandler _particleSystemHandler;

        [field: SerializeField] public UnitClass Class { get; private set; }

        public ParticleSystemHandler SpawnedHandler { get; private set; }

        public UnitHealth Health { get; private set; }

        private void Awake()
        {
            Health = GetComponent<UnitHealth>();

            ParticleSystemHandlerInitialize();
        }

        private void ParticleSystemHandlerInitialize()
        {
            ParticleSystemHandler instance = Instantiate(_particleSystemHandler);
            instance.Initialize(Health, this);
            SpawnedHandler = instance;
        }
    }
}