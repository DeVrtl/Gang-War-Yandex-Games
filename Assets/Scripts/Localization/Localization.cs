using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

namespace GangWar.Localization
{
    public class Localization : MonoBehaviour
    {
        private const string EnglishCode = "en";
        private const string RussianCode = "ru";
        private const string TurkishCode = "tr";
        private const string EnglishNameLocalization = "English";
        private const string RussianNameLocalization = "Russian";
        private const string TurkishNameLocalization = "Turkish";

        private string _currentLanguage;

        private void Awake()
        {
            IdentifyLanguage();
        }

        private void IdentifyLanguage()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
        SwitchLanguageTo(YandexGamesSdk.Environment.i18n.lang);
#endif
        }

        private void SwitchLanguageTo(string code)
        {
            switch (code)
            {
                case EnglishCode:
                    ChangeLanguage(EnglishNameLocalization);
                    break;

                case RussianCode:
                    ChangeLanguage(RussianNameLocalization);
                    break;

                case TurkishCode:
                    ChangeLanguage(TurkishNameLocalization);
                    break;
            }
        }

        private void ChangeLanguage(string localizationName)
        {
            LeanLocalization.SetCurrentLanguageAll(localizationName);
            _currentLanguage = localizationName;
        }
    }
}