using UnityEngine;
using System;

namespace GangWar.Level
{
    public class LevelComplitionCounter : MonoBehaviour
    {
        private const int ViewRedundantValue = 1;
        private const string CurrentLevelNumber = "CurrentLevelNumber";

        [SerializeField] private Finish _finish;

        private int _currentLevelView;

        public int CurrentLevel { get; private set; } = 1;

        public event Action<int> LevelChanged;

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
            TryGetCurrentLevel();
        }

        private void Start()
        {
            RaiseEvent();
        }

        private void Subcribe()
        {
            _finish.LevelCompleted += OnLevelCompleted;
        }

        private void UnSubcribe()
        {
            _finish.LevelCompleted -= OnLevelCompleted;
        }

        private void TryGetCurrentLevel()
        {
            if (PlayerPrefs.HasKey(CurrentLevelNumber))
            {
                CurrentLevel = PlayerPrefs.GetInt(CurrentLevelNumber);
                _currentLevelView = CurrentLevel - ViewRedundantValue;
            }
        }

        private void RaiseEvent()
        {
            LevelChanged?.Invoke(_currentLevelView);
        }

        private void OnLevelCompleted()
        {
            CurrentLevel++;

            PlayerPrefs.SetInt(CurrentLevelNumber, CurrentLevel);
            PlayerPrefs.Save();
        }
    }
}