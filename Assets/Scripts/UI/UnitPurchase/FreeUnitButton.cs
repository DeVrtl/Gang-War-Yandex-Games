using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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

    private Button _button;

    public event UnityAction FreeButtonClicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void Awake()
    {
        _button = GetComponent<Button>();

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
        Instantiate(_smgUnit);
    }
}
