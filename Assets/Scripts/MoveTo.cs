using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        transform.position = _target.position;
    }
}
