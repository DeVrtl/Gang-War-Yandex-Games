using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    [field: SerializeField] public AudioSource Source;

    [SerializeField] private GameObject _winCard;
    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private PlayerWallet _wallet;

    private const float _minTime = 0f;
    private const int _rewardForComplete = 150;

    public event UnityAction LevelCompleted;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out GangLeader leader))
        {
            _wallet.AddMoney(_rewardForComplete);

            LevelCompleted?.Invoke();

            _winCard.SetActive(true);

            _settingsButton.SetActive(false);
            _pauseButton.SetActive(false);

            Source.Play();

            Time.timeScale = _minTime;
        }
    }
}
