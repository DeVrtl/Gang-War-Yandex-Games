using UnityEngine;
using GangWar.UI.Settings.SFX;
using GangWar.BattleSystem.Shooters;

namespace GangWar.Cell
{
    using GangWar.Unit;

    public class CellUnitSoundAssigner : MonoBehaviour
    {
        [SerializeField] private ToggleSound _toggleSound;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Unit unit))
            {
                _toggleSound.AudioSources.Add(unit.SpawnedHandler.Source);
            }

            if (other.TryGetComponent(out Shooter shooter))
            {
                _toggleSound.AudioSources.Add(shooter.Source);
            }
        }
    }
}