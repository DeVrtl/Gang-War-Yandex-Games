using Agava.WebUtility;
using GangWar.Ad;
using UnityEngine;
using static Agava.YandexGames.YandexGamesEnvironment;

namespace GangWar.Game
{
    public class GameFocus : MonoBehaviour
    {
        [SerializeField] private GameRunner _gameRunner;
        [SerializeField] private AudioSource _music;
        [SerializeField] private InterAd _interAd;
        [SerializeField] private RewardAd _rewardAdMoney;
        [SerializeField] private RewardAd _rewardAdUnit;

        private void OnEnable()
        {
            Subcribe();
        }

        private void OnDisable()
        {
            UnSubcribe();
        }

        private void Subcribe()
        {
            Application.focusChanged += OnInBackgroundChangeApp;
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
        }

        private void UnSubcribe()
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
}