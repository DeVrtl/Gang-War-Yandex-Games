using UnityEngine;
using UnityEngine.EventSystems;

namespace GangWar.UI.Tutorial
{
    public class TutorialHider : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            gameObject.SetActive(false);
        }
    }
}