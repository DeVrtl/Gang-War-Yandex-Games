using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GangLeaderSideMoves : MonoBehaviour
{
    [SerializeField] private float _offsetSpeed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveLeft()
    {
        _rigidbody.MovePosition(_rigidbody.position - transform.right * _offsetSpeed * Time.fixedDeltaTime);
    }

    public void MoveRight()
    {
        _rigidbody.MovePosition(_rigidbody.position + transform.right * _offsetSpeed * Time.fixedDeltaTime);
    }
}
