using GangWar.UI.UnitSelection;
using GangWar.Unit;
using Lean.Localization;
using UnityEngine;

namespace GangWar.Localization
{
    [RequireComponent(typeof(UnitSelectionCard))]
    public class UnitDescriprtionLocalization : MonoBehaviour
    {
        private const string SmgName = "Unit class smg";
        private const string ShotgunName = "Unit class";
        private const string GranadeLauncherName = "Unit class gl";

        [SerializeField] private LeanLocalizedTextMeshProUGUI _leanLocalizedText;

        private UnitSelectionCard _unitSelectionButton;

        private void Awake()
        {
            GetComponent();
        }

        private void Start()
        {
            LocalizeDescriprtion();
        }

        private void GetComponent()
        {
            _unitSelectionButton = GetComponent<UnitSelectionCard>();
        }

        private void LocalizeDescriprtion()
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
}