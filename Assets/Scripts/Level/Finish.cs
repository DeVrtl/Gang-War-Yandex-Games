using System;

namespace GangWar.Level
{
    using GangWar.Player;
    using GangWar.GangLeader;
    using UnityEngine;

    public class Finish : MonoBehaviour
    {
        private const float MinTime = 0f;
        private const int RewardForComplete = 150;

        [SerializeField] private AudioSource _source;
        [SerializeField] private GameObject _winCard;
        [SerializeField] private GameObject _settingsButton;
        [SerializeField] private GameObject _pauseButton;
        [SerializeField] private PlayerWallet _wallet;

        public event Action LevelCompleted;

        public AudioSource Source => _source;

        private void OnTriggerEnter(Collider other)
        {
            CrossFinish(other);
        }

        private void CrossFinish(Collider other)
        {
            if (other.TryGetComponent(out GangLeader leader))
            {
                _wallet.AddMoney(RewardForComplete);

                LevelCompleted?.Invoke();

                _winCard.SetActive(true);

                _settingsButton.SetActive(false);
                _pauseButton.SetActive(false);

                _source.Play();

                Time.timeScale = MinTime;
            }
        }
    }
}