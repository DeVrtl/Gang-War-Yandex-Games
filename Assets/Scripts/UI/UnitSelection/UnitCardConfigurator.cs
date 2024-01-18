using System.Collections.Generic;
using UnityEngine;

namespace GangWar.UI.UnitSelection
{
    using GangWar.Unit;

    [CreateAssetMenu(fileName = "UnitCardConfig", menuName = "Game/UnitCardConfig")]
    public class UnitCardConfigurator : ScriptableObject
    {
        [SerializeField] private Sprite _smgIcon;
        [SerializeField] private Sprite _shotgunIcnon;
        [SerializeField] private Sprite _newShotGunIcon;
        [SerializeField] private Sprite _granadeLauncherIcon;
        [SerializeField] private Sprite _newGranadeLauncherIcon;
        [SerializeField] private string _smgDecription;
        [SerializeField] private string _shotgunDecription;
        [SerializeField] private string _granadeLauncherDecription;

        [field: SerializeField] public UnitSelectionCard UitSelectionButton { get; private set; }

        [field: SerializeField] public Unit SmgUnit { get; private set; }

        [field: SerializeField] public Unit ShotgunUnit { get; private set; }

        [field: SerializeField] public Unit GranadeLauncherUnit { get; private set; }

        public void ConfigurateCardsForFirstLevelOrDefualt(List<UnitSelectionCard> selectionButtons)
        {
            foreach (var button in selectionButtons)
            {
                button.GenerateUnit(_smgDecription, _smgIcon, SmgUnit);
            }
        }

        public void ConfigurateCardsForSecondLevel(List<UnitSelectionCard> selectionButtons)
        {
            for (int button = 0; button < selectionButtons.Count; button++)
            {
                selectionButtons[0].GenerateUnit(_smgDecription, _smgIcon, SmgUnit);
                selectionButtons[1].GenerateUnit(_shotgunDecription, _newShotGunIcon, ShotgunUnit);
                selectionButtons[2].GenerateUnit(_shotgunDecription, _newShotGunIcon, ShotgunUnit);
            }
        }

        public void ConfigurateCardsForThirdLevel(List<UnitSelectionCard> selectionButtons)
        {
            for (int button = 0; button < selectionButtons.Count; button++)
            {
                selectionButtons[0].GenerateUnit(_smgDecription, _smgIcon, SmgUnit);
                selectionButtons[1].GenerateUnit(_shotgunDecription, _shotgunIcnon, ShotgunUnit);
                selectionButtons[2].GenerateUnit(_granadeLauncherDecription, _newGranadeLauncherIcon, GranadeLauncherUnit);
            }
        }

        public void ConfigurateCardsForMoreThenThirdLevel(List<UnitSelectionCard> selectionButtons)
        {
            for (int button = 0; button < selectionButtons.Count; button++)
            {
                selectionButtons[0].GenerateUnit(_smgDecription, _smgIcon, SmgUnit);
                selectionButtons[1].GenerateUnit(_shotgunDecription, _shotgunIcnon, ShotgunUnit);
                selectionButtons[2].GenerateUnit(_granadeLauncherDecription, _granadeLauncherIcon, GranadeLauncherUnit);
            }
        }
    }
}