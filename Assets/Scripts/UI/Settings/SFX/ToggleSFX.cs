using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GangWar.UI.Settings.SFX
{
    public abstract class ToggleSFX : MonoBehaviour
    {
        [field: SerializeField] public Image ImageToChange;
        [field: SerializeField] public Sprite Original;
        [field: SerializeField] public Sprite MuteIcon;

        public bool IsPressed { get; private set; } = false;

        private void ChangeToggleState(bool isPressed, Sprite sprite)
        {
            IsPressed = isPressed;

            ImageToChange.sprite = sprite;
        }

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

        protected void Save(int SFXCondition, int resualt, string saveKey)
        {
            SFXCondition = resualt;
            PlayerPrefs.SetInt(saveKey, SFXCondition);
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
    }
}