using Lean.Localization;
using UnityEngine;
using UnityEngine.UI;

namespace GangWar.Localization
{
    public class LanguageSwitch : MonoBehaviour
    {
        private const string Language = "Language";
        private const string EnglishLanguage = "English";
        private const string RussianLanguage = "Russian";
        private const string TurkishLanguage = "Turkish";
        private const int RussianLanguageIndex = 0;
        private const int EnglishLanguageIndex = 1;
        private const int TurkishLanguageIndex = 2;

        [SerializeField] private Button _english;
        [SerializeField] private Button _russian;
        [SerializeField] private Button _turkish;

        private int _languageIndex;

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void Start()
        {
            TryToGetCurrentLanguage();
        }

        private void AddListeners()
        {
            _english.onClick.AddListener(OnEnglishButtonClick);
            _russian.onClick.AddListener(OnRussianButtonClick);
            _turkish.onClick.AddListener(OnTurkishButtonClick);
        }

        private void RemoveListeners()
        {
            _english.onClick.RemoveListener(OnEnglishButtonClick);
            _russian.onClick.RemoveListener(OnRussianButtonClick);
            _turkish.onClick.RemoveListener(OnTurkishButtonClick);
        }

        private void TryToGetCurrentLanguage()
        {
            if (PlayerPrefs.HasKey(Language))
            {
                _languageIndex = PlayerPrefs.GetInt(Language);

                switch (_languageIndex)
                {
                    case RussianLanguageIndex:

                        LeanLocalization.SetCurrentLanguageAll(RussianLanguage);

                        break;

                    case EnglishLanguageIndex:

                        LeanLocalization.SetCurrentLanguageAll(EnglishLanguage);

                        break;

                    case TurkishLanguageIndex:

                        LeanLocalization.SetCurrentLanguageAll(TurkishLanguage);

                        break;

                    default:

                        LeanLocalization.SetCurrentLanguageAll(RussianLanguage);

                        break;
                }
            }
        }

        private void SetAndSaveCurrentLanguage(int languageIndex, string languageName, string saveKey)
        {
            LeanLocalization.SetCurrentLanguageAll(languageName);

            _languageIndex = languageIndex;
            PlayerPrefs.SetInt(saveKey, _languageIndex);
            PlayerPrefs.Save();
        }

        private void OnEnglishButtonClick()
        {
            SetAndSaveCurrentLanguage(EnglishLanguageIndex, EnglishLanguage, Language);
        }

        private void OnRussianButtonClick()
        {
            SetAndSaveCurrentLanguage(RussianLanguageIndex, RussianLanguage, Language);
        }

        private void OnTurkishButtonClick()
        {
            SetAndSaveCurrentLanguage(TurkishLanguageIndex, TurkishLanguage, Language);
        }
    }
}