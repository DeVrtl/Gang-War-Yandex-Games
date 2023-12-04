using Agava.WebUtility;
using UnityEngine;
using static Agava.YandexGames.YandexGamesEnvironment;

public class GameFocus : MonoBehaviour
{
    [SerializeField] private GameRunner _gameRunner;
    [SerializeField] private AudioSource _music;
    [SerializeField] private InterAd _interAd;
    [SerializeField] private RewardAd _rewardAdMoney;
    [SerializeField] private RewardAd _rewardAdUnit;

    private void OnEnable()
    {
        Application.focusChanged += OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
    }

    private void OnDisable()
    {
        Application.focusChanged -= OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
    }

    private void OnInBackgroundChangeApp(bool inApp)
    {
        if (_interAd.IsAdPlaying == false && _rewardAdMoney.IsAdPlaying == false && _rewardAdUnit.IsAdPlaying == false)
        {
            MuteAudio(!inApp);
        }

        if (_gameRunner.IsGameRunning == true)
        {
            PauseGame(!inApp);
        }
    }

    private void OnInBackgroundChangeWeb(bool isBackground)
    {
        if (_interAd.IsAdPlaying == false && _rewardAdMoney.IsAdPlaying == false && _rewardAdUnit.IsAdPlaying == false)
        {
            MuteAudio(isBackground);
        }

        if (_gameRunner.IsGameRunning == true)
        {
            PauseGame(isBackground);
        }
    }

    private void MuteAudio(bool value)
    {
        _music.volume = value ? 0 : 1;
    }

    private void PauseGame(bool value)
    {
        Time.timeScale = value ? 0 : 1;
    }
}
