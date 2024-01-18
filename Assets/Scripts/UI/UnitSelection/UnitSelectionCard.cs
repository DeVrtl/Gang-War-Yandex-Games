using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace GangWar.UI.UnitSelection
{
    using GangWar.Unit;

    public class UnitSelectionCard : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private Button _unitButton;

        private UnitSpawner _spawner;
        private GameObject _background;

        public Unit Unit { get; private set; }

        private void OnEnable()
        {
            Subcribe();
        }

        private void OnDisable()
        {
            UnSubcribe();
        }

        public void SetBackground(GameObject background)
        {
            _background = background;
        }

        public void GenerateUnit(string description, Sprite unitIcon, Unit unit)
        {
            _description.text = description;
            _icon.sprite = unitIcon;
            Unit = unit;
        }

        public void SetSpawner(UnitSpawner unitSpawner)
        {
            _spawner = unitSpawner;
        }

        private void Subcribe()
        {
            _unitButton.onClick.AddListener(OnUnitButtonClick);
        }

        private void UnSubcribe()
        {
            _unitButton.onClick.RemoveListener(OnUnitButtonClick);
        }

        private void OnUnitButtonClick()
        {
            _spawner.Spawn(Unit);

            _background.SetActive(false);
        }
    }
}