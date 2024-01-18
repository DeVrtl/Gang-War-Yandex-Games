using System;
using UnityEngine;
using GangWar.UI;

namespace GangWar.Cell
{
    [RequireComponent(typeof(CellHover))]
    public class Cell : MonoBehaviour
    {
        [SerializeField] private PlayButton _playButton;
        [SerializeField] private GameObject _playCard;
        [SerializeField] private GameObject _miscCard;

        private bool _isCellOccupied = false;
        private CellHover _hover;

        public event Action UnitPlaced;

        private void Awake()
        {
            _hover = GetComponent<CellHover>();
        }

        private void OnMouseDown()
        {
            if (_hover.UnitInCell == null || _isCellOccupied == true)
                return;

            _hover.SwitchToStandartMaterial();

            _playButton.gameObject.SetActive(true);

            _hover.UnitInCell.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            _hover.UnitInCell.StopFollow();

            UnitPlaced?.Invoke();

            _hover.DisableCollider();

            _isCellOccupied = true;

            _playCard.SetActive(true);
            _miscCard.SetActive(true);
        }
    }
}