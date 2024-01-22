namespace GangWar.Cell
{
    using GangWar.BattleSystem.Shooters;
    using GangWar.Game;
    using GangWar.Unit;
    using UnityEngine;

    public class CellUnitPropertiesAssigner : MonoBehaviour
    {
        [SerializeField] private GameInitiator _game;
        [SerializeField] private Transform _target;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out UnitMove move))
            {
                move.SetTarget(_target);
                _game.UnitMoveForwards.Add(move);
            }

            if (other.TryGetComponent(out Shooter shooter))
            {
                _game.UnitShooters.Add(shooter);
            }
        }
    }
}