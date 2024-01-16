using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Agava.WebUtility;
using GangWar.GangLeader;
using GangWar.UI.Settings.SFX;
using GangWar.UI;
using GangWar.Unit;
using GangWar.BattleSystem.Shooters;
using System;

namespace GangWar.Game
{
    public class GameInitiator : MonoBehaviour
    {
        private const float MaxTime = 1f;

        [field: SerializeField] public ToggleSound SoundButton;

        [SerializeField] private GameObject _pauseButton;
        [SerializeField] private PlayButton _playButton;
        [SerializeField] private GameObject _mobileInputCard;
        [SerializeField] private GangLeaderMoveForward _bossMouseMover;
        [SerializeField] private GangLeaderKeyboardStrafe _keyboardStrafe;
        [SerializeField] private GangLeaderMobileMovement _bossMobileMovement;

        public List<Shooter> EnemyShoters { get; private set; } = new List<Shooter>();
        public List<UnitMove> UnitMoveForwards { get; private set; } = new List<UnitMove>();
        public List<Shooter> UnitShooters { get; private set; } = new List<Shooter>();

        public event Action GameInitiated;

        private void OnEnable()
        {
            Subcribe();
        }

        private void OnDisable()
        {
            UnSubcribe();
        }

        private void Awake()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
        YandexGamesSdk.GameReady();
#endif
        }

        private void Start()
        {
            Time.timeScale = MaxTime;
        }

        private void Subcribe()
        {
            _playButton.GameStarted += OnGameStarted;
        }

        private void UnSubcribe()
        {
            _playButton.GameStarted -= OnGameStarted;
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

            GameInitiated?.Invoke();
        }
    }
}