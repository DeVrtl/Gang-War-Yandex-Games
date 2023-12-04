using UnityEngine;
using UnityEngine.UI;

public class MoneyAdReward : MonoBehaviour
{
    private const int MoneyForRewardAd = 100;

    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private RewardAd _rewardAd;
    [SerializeField] private Button _rewardButton;

    private void OnEnable()
    {
        _rewardButton.onClick.AddListener(OnRewarButtonClick);
    }

    private void OnDisable()
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
