using Agava.WebUtility;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class SettingsCard : MonoBehaviour
{
    private const float MaxTime = 1.0f;
    private const float MinTime = 0f;
    private const float MaxAlpha = 1.0f;
    private const float MinAlpha = 0f;
 
    private CanvasGroup _group;

    public event UnityAction SettingsCardOpened;
    public event UnityAction SettingsCardClosed;

    private void Awake()
    {
        _group = GetComponent<CanvasGroup>();
    }

    public void Enable()
    {
        _group.alpha = MaxAlpha;
        _group.blocksRaycasts = true;
        Time.timeScale = MinTime;
        SettingsCardOpened?.Invoke();
    }

    public void Disable()
    {
        _group.alpha = MinAlpha;
        _group.blocksRaycasts = false;
        Time.timeScale = MaxTime;

        SettingsCardClosed?.Invoke();
    }
}
