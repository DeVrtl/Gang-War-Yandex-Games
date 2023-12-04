using Lean.Localization;
using UnityEngine;
using UnityEngine.UI;

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
        _english.onClick.AddListener(OnEnglishButtonClick);
        _russian.onClick.AddListener(OnRussianButtonClick);
        _turkish.onClick.AddListener(OnTurkishButtonClick);
    }

    private void OnDisable()
    {
        _english.onClick.RemoveListener(OnEnglishButtonClick);
        _russian.onClick.RemoveListener(OnRussianButtonClick);
        _turkish.onClick.RemoveListener(OnTurkishButtonClick);
    }

    private void Start()
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

    private void OnEnglishButtonClick()
    {
        LeanLocalization.SetCurrentLanguageAll(EnglishLanguage);

        _languageIndex = EnglishLanguageIndex;
        PlayerPrefs.SetInt(Language, _languageIndex);
        PlayerPrefs.Save();
    }

    private void OnRussianButtonClick()
    {
        LeanLocalization.SetCurrentLanguageAll(RussianLanguage);

        _languageIndex = RussianLanguageIndex;
        PlayerPrefs.SetInt(Language, _languageIndex);
        PlayerPrefs.Save();
    }

    private void OnTurkishButtonClick()
    {
        LeanLocalization.SetCurrentLanguageAll(TurkishLanguage);

        _languageIndex = TurkishLanguageIndex;
        PlayerPrefs.SetInt(Language, _languageIndex);
        PlayerPrefs.Save();
    }
}
