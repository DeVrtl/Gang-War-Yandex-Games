using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GangLeaderMoveForward : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + transform.forward * _speed * Time.fixedDeltaTime);
    }
}