using GangWar.Cell;
using GangWar.UI;
using GangWar.Unit;
using System;
using System.Linq;
using UnityEngine;

namespace GangWar.Game
{
    public class GameLoser : MonoBehaviour
    {
        [SerializeField] private PlayButton _playButton;
        [SerializeField] private GameObject _pauseButton;
        [SerializeField] private GameObject _settingsButton;
        [SerializeField] private GameObject _loseCard;
        [SerializeField] private UnitSpawner _spawner;

        public event Action GameLost;

        private const float MinTime = 0f;

        private void OnEnable()
        {
            _playButton.GameStarted += OnGameStarted;
        }

        private void OnDisable()
        {
            _playButton.GameStarted -= OnGameStarted;

            foreach (var unit in _spawner.Units)
            {
                unit.Health.Died -= OnDied;
            }
        }

        private void OnGameStarted()
        {
            foreach (var unit in _spawner.Units)
            {
                unit.Health.Died += OnDied;
                Debug.Log(unit);
            }
        }

        private void OnDied()
        {
            bool isAllUnitsDead = true;

            foreach (var unit in _spawner.Units)
            {
                if (unit.Health.IsDead == false)
                {
                    isAllUnitsDead = false;
                    break;
                }
            }

            if (isAllUnitsDead == true)
            {
                _loseCard.SetActive(true);

                _settingsButton.SetActive(false);
                _pauseButton.SetActive(false);

                GameLost?.Invoke();

                Time.timeScale = MinTime;
            }
        }
    }
}