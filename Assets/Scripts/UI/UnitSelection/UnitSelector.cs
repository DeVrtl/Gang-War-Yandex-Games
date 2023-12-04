using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitSelector : MonoBehaviour
{
    [SerializeField] private LevelComplitionCounter _levelComplitionCounter;
    [SerializeField] private UnitUIConfigurator _configurator;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private GameObject _background;

    private List<UnitSelectionButton> _selectionButtons = new List<UnitSelectionButton>();

    public event UnityAction SelectorDisabled;

    private void OnDisable()
    {
        SelectorDisabled?.Invoke();
    }

    private void Awake()
    {
        foreach (var point in _spawnPoints)
        {
            UnitSelectionButton unitSelectionButton = Instantiate(_configurator.UitSelectionButton, point);
            unitSelectionButton.SetBackground(_background);
            _selectionButtons.Add(unitSelectionButton);
        }
    }

    private void Start()
    {

        switch (_levelComplitionCounter.CurrentLevel)
        {
            case 1:

                _configurator.ConfigurateButtonsForFirstLevelOrDefualt(_selectionButtons);

                break;

            case 2:

                _configurator.ConfigurateButtonsForSecondLevel(_selectionButtons);

                break;

            case 3:

                _configurator.ConfigurateButtonsForThirdLevel(_selectionButtons);

                break;

            case >= 4:

                _configurator.ConfigurateButtonsForMoreThenThirdLevel(_selectionButtons);

                break;

            default:

                _configurator.ConfigurateButtonsForFirstLevelOrDefualt(_selectionButtons);

                break;
        }
    }
}
//for (int unitButton = 0; unitButton < _unitSelectionButtons.Length; unitButton++)
//{
//    for (int icon = 0; icon < _icons.Count; icon++)
//    {
//        for (int description = 0; description < _descriptions.Count; description++)
//        {
//            _unitSelectionButtons[unitButton].GenerateUnit(_descriptions[0], _icons[0], UnitName.SMGUNIT);
//        }
//    }
//}
//2
//for (int unitButton = 0; unitButton < _unitSelectionButtons.Length; unitButton++)
//{
//    for (int icon = 0; icon < _icons.Count; icon++)
//    {
//        for (int description = 0; description < _descriptions.Count; description++)
//        {
//            _unitSelectionButtons[0].GenerateUnit(_descriptions[0], _icons[0], UnitName.SMGUNIT);
//            _unitSelectionButtons[1].GenerateUnit(_descriptions[1], _iconsNew[0], UnitName.SHOTGUNUNIT);
//            _unitSelectionButtons[2].GenerateUnit(_descriptions[1], _iconsNew[0], UnitName.SHOTGUNUNIT);
//        }
//    }
//}
//3
//for (int unitButton = 0; unitButton < _unitSelectionButtons.Length; unitButton++)
//{
//    for (int icon = 0; icon < _icons.Count; icon++)
//    {
//        for (int newIcon = 0; newIcon < _iconsNew.Count; newIcon++)
//        {
//            for (int description = 0; description < _descriptions.Count; description++)
//            {
//                _unitSelectionButtons[0].GenerateUnit(_descriptions[0], _icons[0], UnitName.SMGUNIT);
//                _unitSelectionButtons[1].GenerateUnit(_descriptions[1], _icons[1], UnitName.SHOTGUNUNIT);
//                _unitSelectionButtons[2].GenerateUnit(_descriptions[2], _iconsNew[1], UnitName.GRANADELAUNCHERUNIT);
//            }
//        }
//    }
//}
//4>
//for (int unitButton = 0; unitButton < _unitSelectionButtons.Length; unitButton++)
//{
//    for (int icon = 0; icon < _icons.Count; icon++)
//    {
//        for (int newIcon = 0; newIcon < _iconsNew.Count; newIcon++)
//        {
//            for (int description = 0; description < _descriptions.Count; description++)
//            {
//                _unitSelectionButtons[0].GenerateUnit(_descriptions[0], _icons[0], UnitName.SMGUNIT);
//                _unitSelectionButtons[1].GenerateUnit(_descriptions[1], _icons[1], UnitName.SHOTGUNUNIT);
//                _unitSelectionButtons[2].GenerateUnit(_descriptions[2], _icons[2], UnitName.GRANADELAUNCHERUNIT);
//            }
//        }
//    }
//}
//defualt
//for (int unitButton = 0; unitButton < _unitSelectionButtons.Length; unitButton++)
//{
//    for (int icon = 0; icon < _icons.Count; icon++)
//    {
//        for (int description = 0; description < _descriptions.Count; description++)
//        {
//            _unitSelectionButtons[unitButton].GenerateUnit(_descriptions[0], _icons[0], UnitName.SMGUNIT);
//        }
//    }
//}