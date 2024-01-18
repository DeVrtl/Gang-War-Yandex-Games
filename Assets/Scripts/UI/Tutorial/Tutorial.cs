using UnityEngine;
using GangWar.Level;
using UnityEngine.UI;
using GangWar.UI.UnitPurchase;
using GangWar.UI.UnitSelection;
using Agava.WebUtility;

namespace GangWar.UI.Tutorial
{
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
            Subcribe();
        }

        private void OnDisable()
        {
            UnSubcribe();
        }

        private void Awake()
        {
            ShowTutorial();
        }

        private void Subcribe()
        {
            _freeUnitButton.FreeButtonClicked += OnFreeButtonClicked;
            _selector.SelectorDisabled += OnSelectorDisabled;
            _playButton.GameStarted += OnGameStarted;
        }

        private void UnSubcribe()
        {
            _freeUnitButton.FreeButtonClicked -= OnFreeButtonClicked;
            _selector.SelectorDisabled -= OnSelectorDisabled;
            _playButton.GameStarted -= OnGameStarted;
        }

        private void ShowTutorial()
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
}