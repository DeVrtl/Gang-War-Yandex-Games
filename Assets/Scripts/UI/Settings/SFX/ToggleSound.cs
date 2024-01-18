using System.Collections.Generic;
using GangWar.Level;
using UnityEngine;

namespace GangWar.UI.Settings.SFX
{
    public class ToggleSound : ToggleSFX
    {
        private const string SoundMute = "SoundMute";
        private const int SoundIsMute = 1;
        private const int SoundIsUnMute = 0;

        [SerializeField] private PlayButton _play;
        [SerializeField] private Finish _finish;

        private int _isSoundMute = 0;

        public List<AudioSource> AudioSources { get; private set; } = new List<AudioSource>();

        private void OnEnable()
        {
            _play.GameStarted += OnGameStarted;
        }

        private void OnDisable()
        {
            _play.GameStarted -= OnGameStarted;
        }

        private void Awake()
        {
            AudioSources.Add(_finish.Source);

            if (PlayerPrefs.HasKey(SoundMute))
            {
                _isSoundMute = PlayerPrefs.GetInt(SoundMute);

                if (_isSoundMute == SoundIsMute)
                {
                    ToggleMultipleAudioSources(true, MuteIcon, true, AudioSources);
                }
                else if (_isSoundMute == SoundIsUnMute)
                {
                    ToggleMultipleAudioSources(false, Original, false, AudioSources);
                }
            }
        }

        public void Toggle()
        {
            if (IsPressed == false)
            {
                ToggleMultipleAudioSources(true, MuteIcon, true, AudioSources);

                Save(_isSoundMute, SoundIsMute, SoundMute);
            }
            else if (IsPressed == true)
            {
                ToggleMultipleAudioSources(false, Original, false, AudioSources);

                Save(_isSoundMute, SoundIsUnMute, SoundMute);
            }
        }

        private void OnGameStarted()
        {
            if (IsPressed == true)
            {
                Mute(true, AudioSources);
            }
        }
    }
}