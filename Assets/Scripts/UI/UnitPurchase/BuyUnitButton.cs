using UnityEngine;
using UnityEngine.UI;

public class BuyUnitButton : MonoBehaviour
{
    [SerializeField] private GameObject _notEnoguhMoneyCard;
    [SerializeField] private GameObject _miscCard;
    [SerializeField] private PlayerWallet _wallet; 
    [SerializeField] private LevelComplitionCounter _counter;
    [SerializeField] private UnitUIConfigurator _config;
    [SerializeField] private FreeUnitButton _freeUnit;
    [SerializeField] private PlayButton _playButton;
    [SerializeField] private int _cost;

    private Button _button;

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
    }

    private void OnButtonClick()
    {
        if (_wallet.Amount < _cost)
        {
            _notEnoguhMoneyCard.SetActive(true);
            return;
        }

        _wallet.TakeMoney(_cost);

        _playButton.gameObject.SetActive(false);
        _freeUnit.gameObject.SetActive(false);
        _miscCard.SetActive(false);

        switch (_counter.CurrentLevel)
        {
            case 1:

                Instantiate(_config.SmgUnit);

                break;

            case 2:

                Instantiate(_config.ShotgunUnit);

                break;

            case >=3:

                Instantiate(_config.GranadeLauncherUnit);

                break;

            default:

                Instantiate(_config.SmgUnit);

                break;
        }

        _button.gameObject.SetActive(false);
    }
}
