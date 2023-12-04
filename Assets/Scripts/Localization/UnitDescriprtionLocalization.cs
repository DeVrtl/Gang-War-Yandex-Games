using Lean.Localization;
using UnityEngine;

[RequireComponent(typeof(UnitSelectionButton))]
public class UnitDescriprtionLocalization : MonoBehaviour
{
    private const string SmgName = "Unit class smg";
    private const string ShotgunName = "Unit class";
    private const string GranadeLauncherName = "Unit class gl";

    [SerializeField] private LeanLocalizedTextMeshProUGUI _leanLocalizedText;

    private UnitSelectionButton _unitSelectionButton;

    private void Awake()
    {
        _unitSelectionButton = GetComponent<UnitSelectionButton>();
    }

    private void Start()
    {
        switch (_unitSelectionButton.Unit.Class)
        {
            case UnitClass.SMG:

                _leanLocalizedText.TranslationName = SmgName;

                break;

            case UnitClass.Shotgun:

                _leanLocalizedText.TranslationName = ShotgunName;

                break;

            case UnitClass.GranadeLauncher:

                _leanLocalizedText.TranslationName = GranadeLauncherName;

                break;
        }
    }
}
