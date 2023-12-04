using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    private const string MusicMute = "MusicMute";
    private const int MusicIsMute = 1;
    private const int MusicIsUnMute = 0;

    [SerializeField] private AudioSource _musicSources;
    [SerializeField] private Image _imageToChange;
    [SerializeField] private Sprite _original;
    [SerializeField] private Sprite _mute;

    private bool _isPressed = false;
    public int IsMusicMute { get; private set; } = 0;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(MusicMute))
        {
            IsMusicMute = PlayerPrefs.GetInt(MusicMute);

            if (IsMusicMute == MusicIsMute)
            {
                Toggle(true, _mute, true);
            }
            else if (IsMusicMute == MusicIsUnMute)
            {
                Toggle(false, _original, false);
            }
        }
    }

    public void Toggle()
    {
        if (_isPressed == false)
        {
            Toggle(true, _mute, true);

            IsMusicMute = MusicIsMute;
            PlayerPrefs.SetInt(MusicMute, IsMusicMute);
            PlayerPrefs.Save();
        }
        else if (_isPressed == true)
        {
            Toggle(false, _original, false);

            IsMusicMute = MusicIsUnMute;
            PlayerPrefs.SetInt(MusicMute, IsMusicMute);
            PlayerPrefs.Save();
        }
    }

    private void Toggle(bool isPressed, Sprite sprite, bool resualt)
    {
        _isPressed = isPressed;

        _imageToChange.sprite = sprite;

        _musicSources.mute = resualt;
    }
}
