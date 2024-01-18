using UnityEngine.EventSystems;

namespace GangWar.UI.MobileMovement
{
    public class RightArrowButton : ArrowButton, IPointerUpHandler, IPointerDownHandler
    {
        public void OnPointerUp(PointerEventData eventData)
        {
            Stop();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Move();
        }
    }
}