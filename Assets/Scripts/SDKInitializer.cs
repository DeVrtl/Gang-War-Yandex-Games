using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GangWar
{
    public class SDKInitializer : MonoBehaviour
    {
        private const string Game = "Game";

        private void Awake()
        {
            SetCallbackLogging();
        }

        private IEnumerator Start()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            yield break;
#endif
            yield return YandexGamesSdk.Initialize(OnInitialized);
        }

        private void OnInitialized()
        {
            SceneManager.LoadScene(Game);
        }

        private void SetCallbackLogging()
        {
            YandexGamesSdk.CallbackLogging = true;
        }
    }
}