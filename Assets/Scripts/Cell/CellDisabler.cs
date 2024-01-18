using System.Collections.Generic;
using UnityEngine;
using GangWar.Game;

namespace GangWar.Cell
{
    public class CellDisabler : MonoBehaviour
    {
        [SerializeField] private GameInitiator _initiator;
        [SerializeField] private List<CellHover> _cellHovers = new List<CellHover>();

        private void OnEnable()
        {
            _initiator.GameInitiated += OnGameInitiated;
        }

        private void OnDisable()
        {
            _initiator.GameInitiated -= OnGameInitiated;
        }

        private void OnGameInitiated()
        {
            foreach (var cell in _cellHovers)
            {
                cell.DisableCollider();
                cell.Renderer.enabled = false;
            }
        }
    }
}