using System;
using GangWar.Ad;
using GangWar.Level;
using UnityEngine.UI;
using UnityEngine;

namespace GangWar.UI.UnitPurchase
{
    using GangWar.Unit;

    [RequireComponent(typeof(Button))]
    public class FreeUnitButton : MonoBehaviour
    {
        private const int FirstLevel = 1;

        [SerializeField] private Unit _smgUnit;
        [SerializeField] private Image _adIcon;
        [SerializeField] private RewardAd _rewardAd;
        [SerializeField] private GameObject _miscCard;
        [SerializeField] private BuyUnitButton _buyUnit;
        [SerializeField] private PlayButton _playButton;
        [SerializeField] private LevelComplitionCounter _levelComplitionCounter;
        [SerializeField] private UnitSpawner _spawner;

        private Button _button;

        public event Action FreeButtonClicked;

        private void OnEnable()
        {
            AddListener();
        }

        private void OnDisable()
        {
            RemoveListener();
        }

        private void Awake()
        {
            GetComponent();

            ShowAd();
        }

        private void AddListener()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void RemoveListener()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void GetComponent()
        {
            _button = GetComponent<Button>();
        }

        private void ShowAd()
        {
            if (_levelComplitionCounter.CurrentLevel > FirstLevel)
            {
                _adIcon.gameObject.SetActive(true);
            }
        }

        private void OnButtonClick()
        {
            if (_levelComplitionCounter.CurrentLevel > FirstLevel)
            {
                _rewardAd.ShowVideoAd();
                OnVideoAdPlayed();
            }
            else
            {
                SpawnUnit();
            }

            _miscCard.SetActive(false);
            _button.gameObject.SetActive(false);
            _buyUnit.gameObject.SetActive(false);
            _playButton.gameObject.SetActive(false);

            FreeButtonClicked?.Invoke();
        }

        private void OnVideoAdPlayed()
        {
            SpawnUnit();
        }

        private void SpawnUnit()
        {
            _spawner.Spawn(_smgUnit);
        }
    }
}