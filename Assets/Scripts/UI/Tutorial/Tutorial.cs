using UnityEngine;
using Agava.WebUtility;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    private const int FirstLevel = 1;

    [SerializeField] private PlayButton _playButton;
    [SerializeField] private UnitSelector _selector;
    [SerializeField] private FreeUnitButton _freeUnitButton;
    [SerializeField] private LevelComplitionCounter _levelComplitionCounter;
    [SerializeField] private Image _unitSelectorScreenHand;
    [SerializeField] private Image _placeUnitPCHand;
    [SerializeField] private Image _placeUnitMobileHand;
    [SerializeField] private Image _buyUnitScreenHand;
    [SerializeField] private Image _playHand;
    [SerializeField] private Image _leftMobileHand;
    [SerializeField] private Image _rightMobileHand;
    [SerializeField] private GameObject _pcMovementCard;

    private void OnEnable()
    {
        _freeUnitButton.FreeButtonClicked += OnFreeButtonClicked;
        _selector.SelectorDisabled += OnSelectorDisabled;
        _playButton.GameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        _freeUnitButton.FreeButtonClicked -= OnFreeButtonClicked;
        _selector.SelectorDisabled -= OnSelectorDisabled;
        _playButton.GameStarted -= OnGameStarted;
    }

    private void Awake()
    {
        if (_levelComplitionCounter.CurrentLevel == FirstLevel)
        {
            _unitSelectorScreenHand.gameObject.SetActive(true);
            _buyUnitScreenHand.gameObject.SetActive(true);
            _leftMobileHand.gameObject.SetActive(true);
            _rightMobileHand.gameObject.SetActive(true);
        }
    }

    private void OnGameStarted()
    {
        if (Device.IsMobile == false && _levelComplitionCounter.CurrentLevel == FirstLevel)
        {
            _pcMovementCard.gameObject.SetActive(true);
        }
    }

    private void OnFreeButtonClicked()
    {
        if (_levelComplitionCounter.CurrentLevel == FirstLevel)
        {
            _buyUnitScreenHand.gameObject.SetActive(false);
            _playHand.gameObject.SetActive(true);
        }
    }

    private void OnSelectorDisabled()
    {
        if (Device.IsMobile == true && _levelComplitionCounter.CurrentLevel == FirstLevel)
        {
            _placeUnitMobileHand.gameObject.SetActive(true);
        }
        else if (_levelComplitionCounter.CurrentLevel == FirstLevel)
        {
            _placeUnitPCHand.gameObject.SetActive(true);
        }
    }
}
