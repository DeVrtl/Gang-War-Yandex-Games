using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GangWar.UI.Settings.SFX
{
    public abstract class ToggleSFX : MonoBehaviour
    {
        [SerializeField] private Image _imageToChange;
        [SerializeField] private Sprite _original;
        [SerializeField] private Sprite _muteIcon;

        public bool IsPressed { get; private set; } = false;

        public Sprite Original => _original;

        public Sprite MuteIcon => _muteIcon;

        protected void ToggleOneAudioSource(bool isPressed, Sprite sprite, bool resualt, AudioSource source)
        {
            ChangeToggleState(isPressed, sprite);

            source.mute = resualt;
        }

        protected void ToggleMultipleAudioSources(bool isPressed, Sprite sprite, bool state, List<AudioSource> audioSources)
        {
            ChangeToggleState(isPressed, sprite);

            Mute(state, audioSources);
        }

        protected void Save(int sFXCondition, int resualt, string saveKey)
        {
            sFXCondition = resualt;
            PlayerPrefs.SetInt(saveKey, sFXCondition);
            PlayerPrefs.Save();
        }

        protected void Mute(bool state, List<AudioSource> audioSources)
        {
            foreach (var source in audioSources)
            {
                if (source == null)
                {
                    return;
                }

                source.mute = state;
            }
        }

        private void ChangeToggleState(bool isPressed, Sprite sprite)
        {
            IsPressed = isPressed;

            _imageToChange.sprite = sprite;
        }
    }
}