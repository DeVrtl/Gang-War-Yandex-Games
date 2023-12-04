using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;

public class RewardAd : MonoBehaviour
{
    [SerializeField] private AudioSource _music;

    public bool IsAdPlaying { get; private set; } = false;

    public event UnityAction VideoAdPlayed;

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
