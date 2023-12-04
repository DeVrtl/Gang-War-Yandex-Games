using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class RectTransformAssigner : MonoBehaviour
{
    [SerializeField] private float _yPosition;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, _yPosition);
    }
}
