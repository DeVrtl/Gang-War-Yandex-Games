using UnityEngine;

namespace GangWar.UI.MobileMovement
{
    public abstract class ArrowButton : MonoBehaviour
    {
        [SerializeField] private ArrowButton _arrow;

        public bool IsPressed { get; private set; }

        public void Move()
        {
            IsPressed = true;
            _arrow.gameObject.SetActive(false);
        }

        public void Stop()
        {
            _arrow.gameObject.SetActive(true);
            IsPressed = false;
        }
    }
}