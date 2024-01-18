using System;
using UnityEngine;
using UnityEngine.UI;
using GangWar.Cinemachine;
using GangWar.UI.UnitPurchase;

namespace GangWar.UI
{
    [RequireComponent(typeof(Button))]
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private CinemachineSwitcher _switcher;
        [SerializeField] private FreeUnitButton _freeUnit;
        [SerializeField] private BuyUnitButton _buyUnit;

        private Button _button;

        public event Action GameStarted;

        public bool IsGameStarted { get; private set; } = false;

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

        private void OnButtonClick()
        {
            _button.gameObject.SetActive(false);
            _freeUnit.gameObject.SetActive(false);
            _buyUnit.gameObject.SetActive(false);
            _switcher.SwitchPriority();

            IsGameStarted = true;

            GameStarted?.Invoke();
        }
    }
}