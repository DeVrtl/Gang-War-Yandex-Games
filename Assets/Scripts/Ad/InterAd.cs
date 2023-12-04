using Agava.YandexGames;
using UnityEngine;

public class InterAd : MonoBehaviour
{
    private const int MusicIsMute = 1;

    [SerializeField] private AudioSource _music;
    [SerializeField] private ToggleMusic _toggleMusic;

    public bool IsAdPlaying { get; private set; } = false;

    public void ShowInterstitialAd()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        InterstitialAd.Show(OnPlayed, OnClosedInterstitialAd);
#endif
    }

    private void OnPlayed()
    {
        IsAdPlaying = true;
        _music.mute = true;
    }

    private void OnClosedInterstitialAd(bool value)
    {
        IsAdPlaying = false;

        if (_toggleMusic.IsMusicMute == MusicIsMute)
        {
            return;
        }

        _music.mute = false;
    }
}
