using UnityEngine;

public class ParticleSystemFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private Unit _target;

    public void SetTarget(Unit target)
    {
        _target = target;
    }

    private void Update()
    {
        transform.position = _target.transform.position + _offset;
    }
}
