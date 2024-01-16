using UnityEngine;

namespace GangWar.UI
{
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
            Assign();
        }

        private void Assign()
        {
            _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, _yPosition);
        }
    }
}