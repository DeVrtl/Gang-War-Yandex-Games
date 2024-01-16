using UnityEngine;

namespace GangWar
{
    public class TimeSwitcher : MonoBehaviour
    {
        private const float MaxTime = 1.0f;
        private const float MinTime = 0f;

        public void SetMinTime()
        {
            Time.timeScale = MinTime;
        }

        public void SetMaxTime()
        {
            Time.timeScale = MaxTime;
        }
    }
}