using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GangWar.Cell
{
    [RequireComponent(typeof(Cell))]
    public class CellTutorial : MonoBehaviour
    {
        [SerializeField] private List<Image> _tutorialHands = new List<Image>();

        private Cell _cell;

        private void OnEnable()
        {
            _cell.UnitPlaced += OnUnitPlaced;
        }

        private void OnDisable()
        {
            _cell.UnitPlaced -= OnUnitPlaced;
        }

        private void Awake()
        {
            _cell = GetComponent<Cell>();
        }

        private void OnUnitPlaced()
        {
            foreach (var hand in _tutorialHands)
            {
                hand.gameObject.SetActive(false);
            }
        }
    }
}