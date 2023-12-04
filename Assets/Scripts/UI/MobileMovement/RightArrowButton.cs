using UnityEngine;
using UnityEngine.EventSystems;

public class RightArrowButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private LeftArrowButton _leftButton;

    public bool IsPressed { get; private set; }

    public void OnPointerUp(PointerEventData eventData)
    {
        _leftButton.gameObject.SetActive(true);
        IsPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsPressed = true;
        _leftButton.gameObject.SetActive(false);
    }
}
