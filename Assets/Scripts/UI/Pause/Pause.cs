using UnityEngine.Events;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private const float MinTime = 0f;
    private const float MaxTime = 1f;

    public event UnityAction GamePaused;
    public event UnityAction GameUnPaused;

    public void Enable()
    {
        Time.timeScale = MinTime;
        GamePaused?.Invoke();
    }

    public void Disable()
    {
        Time.timeScale = MaxTime;
        GameUnPaused?.Invoke();
    }
}
