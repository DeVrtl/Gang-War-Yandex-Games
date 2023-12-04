using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CellOccupiedChecker : MonoBehaviour
{
    [SerializeField] private List<Cell> _cells = new List<Cell>();
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private GameObject _loseCard;

    private const float MinTime = 0f;

    public event UnityAction GameLost;

    private void OnEnable()
    {
        foreach (var cell in _cells)
        {
            cell.CellReleased += OnCellReleased;
        }
    }

    private void OnDisable()
    {
        foreach (var cell in _cells)
        {
            cell.CellReleased -= OnCellReleased;
        }
    }

    private void OnCellReleased()
    {
        bool allCellsOccupied = false;

        foreach (var cell in _cells)
        {
            if (cell.IsCellOccupied == true)
            {
                allCellsOccupied = true;
                break;
            }
        }

        if (allCellsOccupied == false)
        {
            _loseCard.SetActive(true);

            _settingsButton.SetActive(false);
            _pauseButton.SetActive(false);

            GameLost?.Invoke();

            Time.timeScale = MinTime;
        }
    }
}
