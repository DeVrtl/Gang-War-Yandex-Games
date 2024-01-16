using UnityEngine;
using System;

namespace GangWar.UI.Settings
{
    [RequireComponent(typeof(CanvasGroup))]
    public class SettingsCard : MonoBehaviour
    {
        private const float MaxTime = 1.0f;
        private const float MinTime = 0f;
        private const float MaxAlpha = 1.0f;
        private const float MinAlpha = 0f;

        private CanvasGroup _group;

        public event Action SettingsCardOpened;
        public event Action SettingsCardClosed;

        private void Awake()
        {
            _group = GetComponent<CanvasGroup>();
        }

        public void Enable()
        {
            _group.alpha = MaxAlpha;
            _group.blocksRaycasts = true;
            Time.timeScale = MinTime;
            SettingsCardOpened?.Invoke();
        }

        public void Disable()
        {
            _group.alpha = MinAlpha;
            _group.blocksRaycasts = false;
            Time.timeScale = MaxTime;

            SettingsCardClosed?.Invoke();
        }
    }
}