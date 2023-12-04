using UnityEngine;

public class UnitMove : MonoBehaviour
{
    [SerializeField] private float _strafeSpeed;

    private Transform _target;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_target.position.x, 0f, _target.position.z), _strafeSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
