using GangWar.Ad;
using GangWar.Player;
using UnityEngine;
using UnityEngine.UI;

namespace GangWar.UI.Money
{
    public class MoneyAdReward : MonoBehaviour
    {
        private const int MoneyForRewardAd = 100;

        [SerializeField] private PlayerWallet _playerWallet;
        [SerializeField] private RewardAd _rewardAd;
        [SerializeField] private Button _rewardButton;

        private void OnEnable()
        {
            AddListener();
        }

        private void OnDisable()
        {
            RemoveListener();
        }

        private void AddListener()
        {
            _rewardButton.onClick.AddListener(OnRewarButtonClick);
        }

        private void RemoveListener()
        {
            _rewardButton.onClick.RemoveListener(OnRewarButtonClick);
        }

        private void OnRewarButtonClick()
        {
            _rewardAd.ShowVideoAd();

            _playerWallet.AddMoney(MoneyForRewardAd);
            _playerWallet.SaveMoney();

            gameObject.SetActive(false);
        }
    }
}