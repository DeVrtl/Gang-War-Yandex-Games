using UnityEngine;
using UnityEngine.Events;

public class LevelComplitionCounter : MonoBehaviour
{
    private const int ViewRedundantValue = 1;
    private const string CurrentLevelNumber = "CurrentLevelNumber";
    
    [SerializeField] private Finish _finish;

    private int _currentLevelView;

    public int CurrentLevel { get; private set; } = 1;

    public event UnityAction<int> LevelChanged;

    private void OnEnable()
    {
        _finish.LevelCompleted += OnLevelCompleted;
    }

    private void OnDisable()
    {
        _finish.LevelCompleted -= OnLevelCompleted;
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey(CurrentLevelNumber))
        {
            CurrentLevel = PlayerPrefs.GetInt(CurrentLevelNumber);
            _currentLevelView = CurrentLevel - ViewRedundantValue;
        }
    }

    private void Start()
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
