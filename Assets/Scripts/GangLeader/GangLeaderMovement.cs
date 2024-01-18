using UnityEngine;

namespace GangWar.GangLeader
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class GangLeaderMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void FreezeRotation()
        {
            _rigidbody.freezeRotation = true;
        }

        protected void Move(Vector3 direction)
        {
            _rigidbody.MovePosition(_rigidbody.position + direction * (_speed * Time.fixedDeltaTime));
        }
    }
}