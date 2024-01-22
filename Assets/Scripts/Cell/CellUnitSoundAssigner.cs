namespace GangWar.Cell
{
    using GangWar.BattleSystem.Shooters;
    using GangWar.UI.Settings.SFX;
    using GangWar.Unit;
    using UnityEngine;

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