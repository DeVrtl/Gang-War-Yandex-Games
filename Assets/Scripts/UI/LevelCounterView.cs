using TMPro;
using UnityEngine;

public class LevelCounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelNumber;
    [SerializeField] private LevelComplitionCounter _levelComplitionCounter;

    private void OnEnable()
    {
        _levelComplitionCounter.LevelChanged += OnLevelChanged;
    }

    private void OnDisable()
    {
        _levelComplitionCounter.LevelChanged -= OnLevelChanged;
    }

    private void OnLevelChanged(int levelNumber)
    {
        _levelNumber.text = levelNumber.ToString();
    }
}
