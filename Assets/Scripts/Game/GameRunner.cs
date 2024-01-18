using Agava.WebUtility;
using GangWar.Level;
using GangWar.UI.Pause;
using GangWar.UI.Settings;
using GangWar.UI;
using UnityEngine;

namespace GangWar.Game
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private PlayButton _playButton;
        [SerializeField] private Pause _pause;
        [SerializeField] private GameLoser _gameLoser;
        [SerializeField] private SettingsCard _settingsCard;
        [SerializeField] private GameObject _mobileInputCard;
        [SerializeField] private Finish _finish;

        public bool IsGameRunning { get; private set; } = true;

        private void OnEnable()
        {
            _pause.GamePaused += OnGamePaused;
            _pause.GameUnPaused += OnGameUnPaused;
            _settingsCard.SettingsCardOpened += OnSettingsCardOpened;
            _settingsCard.SettingsCardClosed += OnSettingsCardClosed;
            _gameLoser.GameLost += OnGameLost;
            _finish.LevelCompleted += OnLevelCompleted;
        }

        private void OnDisable()
        {
            _pause.GamePaused -= OnGamePaused;
            _pause.GameUnPaused -= OnGameUnPaused;
            _settingsCard.SettingsCardOpened -= OnSettingsCardOpened;
            _settingsCard.SettingsCardClosed -= OnSettingsCardClosed;
            _gameLoser.GameLost -= OnGameLost;
            _finish.LevelCompleted -= OnLevelCompleted;
        }

        private void SetGameRunningState(bool resualt)
        {
            IsGameRunning = resualt;

            if (Device.IsMobile == true)
            {
                _mobileInputCard.SetActive(resualt);
            }
        }

        private void ToggleGameRunningStateWhenSettingsCard(bool isSettingsOpen)
        {
            IsGameRunning = isSettingsOpen;

            if (Device.IsMobile == true && _playButton.IsGameStarted == true)
            {
                _mobileInputCard.SetActive(isSettingsOpen);
            }
        }

        private void OnGamePaused()
        {
            SetGameRunningState(false);
        }

        private void OnGameUnPaused()
        {
            SetGameRunningState(true);
        }

        private void OnSettingsCardOpened()
        {
            ToggleGameRunningStateWhenSettingsCard(false);
        }

        private void OnSettingsCardClosed()
        {
            ToggleGameRunningStateWhenSettingsCard(true);
        }

        private void OnGameLost()
        {
            SetGameRunningState(false);
        }

        private void OnLevelCompleted()
        {
            SetGameRunningState(false);
        }
    }
}