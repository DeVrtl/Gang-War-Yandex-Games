using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour
{
    private const string SoundMute = "SoundMute";
    private const int SoundIsMute = 1;
    private const int SoundIsUnMute = 0;

    [SerializeField] private PlayButton _play;
    [SerializeField] private Finish _finish;
    [SerializeField] private Image _imageToChange;
    [SerializeField] private Sprite _original;
    [SerializeField] private Sprite _mute;

    public List<AudioSource> AudioSources { get; private set; } = new List<AudioSource>();

    private bool _isPressed = false;
    private int _isSoundMute = 0;

    private void OnEnable()
    {
        _play.GameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        _play.GameStarted -= OnGameStarted;
    }

    private void Awake()
    {
        AudioSources.Add(_finish.Source);

        if (PlayerPrefs.HasKey(SoundMute))
        {
            _isSoundMute = PlayerPrefs.GetInt(SoundMute);

            if (_isSoundMute == SoundIsMute)
            {
                Toggle(true, _mute, true);
            }
            else if (_isSoundMute == SoundIsUnMute)
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

            _isSoundMute = SoundIsMute;
            PlayerPrefs.SetInt(SoundMute, _isSoundMute);
            PlayerPrefs.Save();
        }
        else if (_isPressed == true)
        {
            Toggle(false, _original, false);

            _isSoundMute = SoundIsUnMute;
            PlayerPrefs.SetInt(SoundMute, _isSoundMute);
            PlayerPrefs.Save();
        }
    }

    private void Toggle(bool isPressed, Sprite sprite, bool state)
    {
        _isPressed = isPressed;

        _imageToChange.sprite = sprite;

        Mute(state);
    }

    private void OnGameStarted()
    {
        if (_isPressed == true)
        {
            Mute(true);
        }
    }

    private void Mute(bool state)
    {
        foreach (var source in AudioSources)
        {
            if (source == null)
            {
                return;
            }

            source.mute = state;
        }
    }
}
