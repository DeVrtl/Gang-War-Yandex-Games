using UnityEngine;
using UnityEngine.EventSystems;

public class LeftArrowButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RightArrowButton _rightButton;

    public bool IsPressed { get; private set; }

    public void OnPointerUp(PointerEventData eventData)
    {
        _rightButton.gameObject.SetActive(true);
        IsPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsPressed = true;
        _rightButton.gameObject.SetActive(false);
    }
}
