using GangWar.Level;
using TMPro;
using UnityEngine;

namespace GangWar.UI
{
    public class LevelCounterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelNumber;
        [SerializeField] private LevelComplitionCounter _levelComplitionCounter;

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
            _levelComplitionCounter.LevelChanged += OnLevelChanged;
        }

        private void UnSubcribe()
        {
            _levelComplitionCounter.LevelChanged -= OnLevelChanged;
        }

        private void OnLevelChanged(int levelNumber)
        {
            _levelNumber.text = levelNumber.ToString();
        }
    }
}