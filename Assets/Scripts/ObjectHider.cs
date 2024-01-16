using GangWar.Ad;
using GangWar.Game;
using GangWar.LeaderBoard;
using GangWar.UI;
using GangWar.UI.UnitPurchase;
using UnityEngine;

namespace GangWar
{
    public class ObjectHider : MonoBehaviour
    {
        [SerializeField] private GameInitiator _gameInitiator;
        [SerializeField] private RewardAd _moneyRewardAd;
        [SerializeField] private LeaderboardButton _leaderboard;
        [SerializeField] private BuyUnitButton _buyUnitButton;
        [SerializeField] private GameObject _miscCard;
        [SerializeField] private FreeUnitButton _freeUnit;
        [SerializeField] private PlayButton _playButton;

        private void OnEnable()
        {
            _buyUnitButton.UnitBought += OnUnitBought;
            _gameInitiator.GameInitiated += OnGameInitiated;
        }

        private void OnDisable()
        {
            _buyUnitButton.UnitBought -= OnUnitBought;
            _gameInitiator.GameInitiated -= OnGameInitiated;
        }

        private void OnUnitBought()
        {
            _playButton.gameObject.SetActive(false);
            _freeUnit.gameObject.SetActive(false);
            _miscCard.SetActive(false);
        }

        private void OnGameInitiated()
        {
            _leaderboard.gameObject.SetActive(false);
            _moneyRewardAd.gameObject.SetActive(false);
        }
    }
}