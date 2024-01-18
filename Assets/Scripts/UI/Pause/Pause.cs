using System;
using UnityEngine;

namespace GangWar.UI.Pause
{
    public class Pause : MonoBehaviour
    {
        private const float MinTime = 0f;
        private const float MaxTime = 1f;

        public event Action GamePaused;

        public event Action GameUnPaused;

        public void Enable()
        {
            Time.timeScale = MinTime;
            GamePaused?.Invoke();
        }

        public void Disable()
        {
            Time.timeScale = MaxTime;
            GameUnPaused?.Invoke();
        }
    }
}