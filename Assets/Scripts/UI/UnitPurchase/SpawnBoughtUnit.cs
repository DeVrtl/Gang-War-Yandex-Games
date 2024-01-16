using GangWar.Level;
using GangWar.UI.UnitSelection;
using GangWar.Unit;
using UnityEngine;

namespace GangWar.UI.UnitPurchase
{
    public class SpawnBoughtUnit : MonoBehaviour
    {
        [SerializeField] private LevelComplitionCounter _counter;
        [SerializeField] private UnitCardConfigurator _config;
        [SerializeField] private BuyUnitButton _buyUnitButton;
        [SerializeField] private UnitSpawner _spawner;

        private void OnEnable()
        {
            _buyUnitButton.UnitBought += OnUnitBought;
        }

        private void OnDisable()
        {
            _buyUnitButton.UnitBought -= OnUnitBought;
        }

        private void OnUnitBought()
        {
            switch (_counter.CurrentLevel)
            {
                case 1:

                    _spawner.Spawn(_config.SmgUnit);

                    break;
                case 2:

                    _spawner.Spawn(_config.ShotgunUnit);

                    break;

                case >= 3:

                    _spawner.Spawn(_config.GranadeLauncherUnit);

                    break;

                default:

                    _spawner.Spawn(_config.SmgUnit);

                    break;
            }
        }
    }
}