using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialHider : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
}
