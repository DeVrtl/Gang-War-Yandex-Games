using Agava.YandexGames;
using System;
using UnityEngine;

namespace GangWar.Ad
{
    public class RewardAd : MonoBehaviour
    {
        [SerializeField] private AudioSource _music;

        public event Action VideoAdPlayed;

        public bool IsAdPlaying { get; private set; } = false;

        public void ShowVideoAd()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
        VideoAd.Show(OnPlayed, OnRewarded, OnClosed);
#endif
        }

        private void OnPlayed()
        {
            IsAdPlaying = true;
            _music.mute = true;
        }

        private void OnClosed()
        {
            IsAdPlaying = false;
            _music.mute = false;
        }

        private void OnRewarded()
        {
            VideoAdPlayed?.Invoke();
        }
    }
}