using System;
using System.Collections.Generic;
using GangWar.Level;
using GangWar.Unit;
using UnityEngine;

namespace GangWar.UI.UnitSelection
{
    public class UnitSelector : MonoBehaviour
    {
        [SerializeField] private LevelComplitionCounter _levelComplitionCounter;
        [SerializeField] private UnitCardConfigurator _configurator;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private GameObject _background;
        [SerializeField] private UnitSpawner _spawner;

        private List<UnitSelectionCard> _selectionButtons = new List<UnitSelectionCard>();

        public event Action SelectorDisabled;

        private void OnDisable()
        {
            RaiseEvent();
        }

        private void Awake()
        {
            SpawnUnitsCard();
        }

        private void Start()
        {
            ConfigurateCards();
        }

        private void RaiseEvent()
        {
            SelectorDisabled?.Invoke();
        }

        private void SpawnUnitsCard()
        {
            foreach (var point in _spawnPoints)
            {
                UnitSelectionCard unitSelectionCard = Instantiate(_configurator.UitSelectionButton, point);
                unitSelectionCard.SetBackground(_background);
                unitSelectionCard.SetSpawner(_spawner);
                _selectionButtons.Add(unitSelectionCard);
            }
        }

        private void ConfigurateCards()
        {
            switch (_levelComplitionCounter.CurrentLevel)
            {
                case 1:

                    _configurator.ConfigurateCardsForFirstLevelOrDefualt(_selectionButtons);

                    break;

                case 2:

                    _configurator.ConfigurateCardsForSecondLevel(_selectionButtons);

                    break;

                case 3:

                    _configurator.ConfigurateCardsForThirdLevel(_selectionButtons);

                    break;

                case >= 4:

                    _configurator.ConfigurateCardsForMoreThenThirdLevel(_selectionButtons);

                    break;

                default:

                    _configurator.ConfigurateCardsForFirstLevelOrDefualt(_selectionButtons);

                    break;
            }
        }
    }
}