using Agava.WebUtility;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
    [SerializeField] private PlayButton _playButton;
    [SerializeField] private Pause _pause;
    [SerializeField] private SettingsCard _settingsCard;
    [SerializeField] private CellOccupiedChecker _cellOccupiedChecker;
    [SerializeField] private GameObject _mobileInputCard;
    [SerializeField] private Finish _finish;

    public bool IsGameRunning { get; private set; } = true;

    private void OnEnable()
    {
        _pause.GamePaused += OnGamePaused;
        _pause.GameUnPaused += OnGameUnPaused;
        _settingsCard.SettingsCardOpened += OnSettingsCardOpened;
        _settingsCard.SettingsCardClosed += OnSettingsCardClosed;
        _cellOccupiedChecker.GameLost += OnGameLost;
        _finish.LevelCompleted += OnLevelCompleted;
    }

    private void OnDisable()
    {
        _pause.GamePaused -= OnGamePaused;
        _pause.GameUnPaused -= OnGameUnPaused;
        _settingsCard.SettingsCardOpened -= OnSettingsCardOpened;
        _settingsCard.SettingsCardClosed -= OnSettingsCardClosed;
        _cellOccupiedChecker.GameLost -= OnGameLost;
        _finish.LevelCompleted -= OnLevelCompleted;
    }

    private void OnGamePaused()
    {
        IsGameRunning = false;

        if (Device.IsMobile == true)
        {
            _mobileInputCard.SetActive(false);
        }
    }

    private void OnGameUnPaused()
    {
        IsGameRunning = true;

        if (Device.IsMobile == true)
        {
            _mobileInputCard.SetActive(true);
        }
    }

    private void OnSettingsCardOpened()
    {
        IsGameRunning = false;

        if (Device.IsMobile == true && _playButton.IsGameStarted == true)
        {
            _mobileInputCard.SetActive(false);
        }
    }

    private void OnSettingsCardClosed()
    {
        IsGameRunning = true;

        if (Device.IsMobile == true && _playButton.IsGameStarted == true)
        {
            _mobileInputCard.SetActive(true);
        }
    }

    private void OnGameLost()
    {
        IsGameRunning = false;

        if (Device.IsMobile == true)
        {
            _mobileInputCard.SetActive(false);
        }
    }

    private void OnLevelCompleted()
    {
        IsGameRunning = false;

        if (Device.IsMobile == true)
        {
            _mobileInputCard.SetActive(false);
        }
    }
}
