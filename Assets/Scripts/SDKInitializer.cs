using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.YandexGames;
using System.Collections;

public class SDKInitializer : MonoBehaviour
{
    private const string Game = "Game";

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
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
}
