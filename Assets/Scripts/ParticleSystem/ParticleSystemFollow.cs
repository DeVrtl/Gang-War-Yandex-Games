using UnityEngine;

namespace GangWar.ParticleSystem
{
    using GangWar.Unit;

    public class ParticleSystemFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;

        private Unit _target;

        private void Update()
        {
            Follow();
        }

        private void Follow()
        {
            transform.position = _target.transform.position + _offset;
        }

        public void SetTarget(Unit target)
        {
            _target = target;
        }
    }
}