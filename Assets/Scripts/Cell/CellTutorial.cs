using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Cell))]
public class CellTutorial : MonoBehaviour
{
    private const int FirstLevel = 1;

    [SerializeField] private LevelComplitionCounter _levelComplitionCounter;
    [SerializeField] private List<Image> _tutorialHands = new List<Image>();

    private Cell _cell;

    private void OnEnable()
    {
        _cell.CellOccupied += OnCellOccupied;
    }

    private void OnDisable()
    {
        _cell.CellOccupied -= OnCellOccupied;
    }

    private void Awake()
    {
        _cell = GetComponent<Cell>();
    }

    private void OnCellOccupied()
    {
        foreach (var hand in _tutorialHands)
        {
            hand.gameObject.SetActive(false);
        }
    }
}
