using UnityEngine;

namespace GangWar.Unit
{
    [RequireComponent(typeof(UnitAnimator))]
    public class UnitMove : MonoBehaviour
    {
        [SerializeField] private float _strafeSpeed;

        private UnitAnimator _animator;
        private Transform _target;

        private void OnEnable()
        {
            _animator.Play(UnitAnimations.RunWithGun);
        }

        private void Awake()
        {
            _animator = GetComponent<UnitAnimator>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(_target.position.x, 0f, _target.position.z), _strafeSpeed * Time.deltaTime);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
    }
}