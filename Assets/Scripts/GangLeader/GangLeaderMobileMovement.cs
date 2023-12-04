using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GangLeaderMobileMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GangLeaderSideMoves _sideMoves;
    [SerializeField] private LeftArrowButton _leftArrow;
    [SerializeField] private RightArrowButton _rightArrow;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + transform.forward * _speed * Time.fixedDeltaTime);

        if (_leftArrow.IsPressed == true)
        {
            _sideMoves.MoveLeft();
        }
        if (_rightArrow.IsPressed == true)
        {
            _sideMoves.MoveRight();
        }
    }
}
