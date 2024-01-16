using UnityEngine;
using UnityEngine.UI;

namespace GangWar.UI.Settings.SFX
{
    public class ToggleMusic : ToggleSFX
    {
        private const string MusicMute = "MusicMute";
        private const int MusicIsMute = 1;
        private const int MusicIsUnMute = 0;

        [SerializeField] private AudioSource _musicSource;

        public int IsMusicMute { get; private set; } = 0;

        private void Awake()
        {
            if (PlayerPrefs.HasKey(MusicMute))
            {
                IsMusicMute = PlayerPrefs.GetInt(MusicMute);

                if (IsMusicMute == MusicIsMute)
                {
                    ToggleOneAudioSource(true, MuteIcon, true, _musicSource);
                }
                else if (IsMusicMute == MusicIsUnMute)
                {
                    ToggleOneAudioSource(false, Original, false, _musicSource);
                }
            }
        }

        public void Toggle()
        {
            if (IsPressed == false)
            {
                ToggleOneAudioSource(true, MuteIcon, true, _musicSource);

                Save(IsMusicMute, MusicIsMute, MusicMute);
            }
            else if (IsPressed == true)
            {
                ToggleOneAudioSource(false, Original, false, _musicSource);

                Save(IsMusicMute, MusicIsUnMute, MusicMute);
            }
        }
    }
}