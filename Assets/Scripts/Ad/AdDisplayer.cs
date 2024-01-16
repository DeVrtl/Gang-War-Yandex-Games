using GangWar.Level;
using GangWar.UI.Money;
using UnityEngine;

namespace GangWar.Ad
{
    public class AdDisplayer : MonoBehaviour
    {
        private const int FirstLevel = 1;

        [SerializeField] private InterAd _interAd;
        [SerializeField] private LevelComplitionCounter _levelComplitionCounter;
        [SerializeField] private MoneyAdReward _moneyAdReward;

        private void Start()
        {
            if (_levelComplitionCounter.CurrentLevel > FirstLevel)
            {
                _interAd.ShowInterstitialAd();
                _moneyAdReward.gameObject.SetActive(true);
            }
        }
    }
}