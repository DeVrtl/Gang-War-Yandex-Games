using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Agava.WebUtility;

public class GameInitiator : MonoBehaviour
{
    private const float MaxTime = 1f;
    private const int FirstLevel = 1;

    [field: SerializeField] public ToggleSound SoundButton;

    [SerializeField] private InterAd _interAd;
    [SerializeField] private RewardAd _moneyRewardAd;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private LevelComplitionCounter _levelComplitionCounter;
    [SerializeField] private MoneyAdReward _moneyAdReward;
    [SerializeField] private PlayButton _playButton;
    [SerializeField] private LeaderboardButton _leaderboard;
    [SerializeField] private GameObject _mobileInputCard;
    [SerializeField] private GangLeaderMoveForward _bossMouseMover;
    [SerializeField] private GangLeaderKeyboardStrafe _keyboardStrafe;
    [SerializeField] private GangLeaderMobileMovement _bossMobileMovement;
    [SerializeField] private List<CellHover> _cellHovers = new List<CellHover>();

    public List<Shooter> EnemyShoters { get; private set; } = new List<Shooter>();
    public List<UnitAnimator> UnitAnimators { get; private set; } = new List<UnitAnimator>();
    public List<UnitMove> UnitMoveForwards { get; private set; } = new List<UnitMove>();
    public List<Shooter> UnitShooters { get; private set; } = new List<Shooter>();

    private void OnEnable()
    {
        _playButton.GameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        _playButton.GameStarted -= OnGameStarted;
    }

    private void Awake()
    {
        if (_levelComplitionCounter.CurrentLevel > FirstLevel)
        {
            _interAd.ShowInterstitialAd();
            _moneyAdReward.gameObject.SetActive(true);
        }

#if UNITY_WEBGL && !UNITY_EDITOR
        YandexGamesSdk.GameReady();
#endif
    }

    private void Start()
    {
        Time.timeScale = MaxTime;
    }

    private void OnGameStarted()
    {
        if (Device.IsMobile == true)
        {
            _mobileInputCard.SetActive(true);
            _bossMobileMovement.enabled = true;
        }
        else
        {
            _bossMouseMover.enabled = true;
            _keyboardStrafe.enabled = true;
        }

        foreach (var cell in _cellHovers)
        {
            cell.DisableCollider();
            cell.Renderer.enabled = false;
        }

        foreach (var animator in UnitAnimators)
        {
            animator.Play(UnitAnimations.RunWithGun);
        }

        foreach (var unitMove in UnitMoveForwards)
        {
            unitMove.enabled = true;
        }

        foreach (var shooter in UnitShooters)
        {
            shooter.enabled = true;
        }

        foreach (var enemyShooter in EnemyShoters)
        {
            enemyShooter.enabled = true;
        }

        _pauseButton.SetActive(true);

        _leaderboard.gameObject.SetActive(false);
        _moneyRewardAd.gameObject.SetActive(false);
    }
}