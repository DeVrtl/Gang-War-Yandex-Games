using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitButtonConfig", menuName = "Game/UnitButtonConfig")]
public class UnitUIConfigurator : ScriptableObject
{
    [field: SerializeField] public UnitSelectionButton UitSelectionButton { get; private set; }
    [field: SerializeField] public Unit SmgUnit { get; private set; }
    [field: SerializeField] public Unit ShotgunUnit { get; private set; }
    [field: SerializeField] public Unit GranadeLauncherUnit { get; private set; }

    [SerializeField] private Sprite _smgIcon;
    [SerializeField] private Sprite _shotgunIcnon;
    [SerializeField] private Sprite _newShotGunIcon;
    [SerializeField] private Sprite _granadeLauncherIcon;
    [SerializeField] private Sprite _newGranadeLauncherIcon;
    [SerializeField] private string _smgDecription;
    [SerializeField] private string _shotgunDecription;
    [SerializeField] private string _granadeLauncherDecription;

    public void ConfigurateButtonsForFirstLevelOrDefualt(List<UnitSelectionButton> selectionButtons)
    {
        foreach (var button in selectionButtons) 
        {
            button.GenerateUnit(_smgDecription, _smgIcon, SmgUnit);
        }
    }

    public void ConfigurateButtonsForSecondLevel(List<UnitSelectionButton> selectionButtons)
    {
        for (int button = 0; button < selectionButtons.Count; button++)
        {
            selectionButtons[0].GenerateUnit(_smgDecription, _smgIcon, SmgUnit);
            selectionButtons[1].GenerateUnit(_shotgunDecription, _newShotGunIcon, ShotgunUnit);
            selectionButtons[2].GenerateUnit(_shotgunDecription, _newShotGunIcon, ShotgunUnit);
        }
    }

    public void ConfigurateButtonsForThirdLevel(List<UnitSelectionButton> selectionButtons)
    {
        for (int button = 0; button < selectionButtons.Count; button++)
        {
            selectionButtons[0].GenerateUnit(_smgDecription, _smgIcon, SmgUnit);
            selectionButtons[1].GenerateUnit(_shotgunDecription, _shotgunIcnon, ShotgunUnit);
            selectionButtons[2].GenerateUnit(_granadeLauncherDecription, _newGranadeLauncherIcon, GranadeLauncherUnit);
        }
    }

    public void ConfigurateButtonsForMoreThenThirdLevel(List<UnitSelectionButton> selectionButtons)
    {
        for (int button = 0; button < selectionButtons.Count; button++)
        {
            selectionButtons[0].GenerateUnit(_smgDecription, _smgIcon, SmgUnit);
            selectionButtons[1].GenerateUnit(_shotgunDecription, _shotgunIcnon, ShotgunUnit);
            selectionButtons[2].GenerateUnit(_granadeLauncherDecription, _granadeLauncherIcon, GranadeLauncherUnit);
        }
    }
}