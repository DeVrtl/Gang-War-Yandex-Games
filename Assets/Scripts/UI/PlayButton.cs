using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayButton : MonoBehaviour
{
    [SerializeField] private CinemachineSwitcher _switcher;
    [SerializeField] private FreeUnitButton _freeUnit;
    [SerializeField] private BuyUnitButton _buyUnit;

    private Button _button;

    public bool IsGameStarted { get; private set; } = false;

    public event UnityAction GameStarted;

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
        _button.gameObject.SetActive(false);
        _freeUnit.gameObject.SetActive(false);
        _buyUnit.gameObject.SetActive(false);
        _switcher.SwitchPriority();

        IsGameStarted = true;

        GameStarted?.Invoke();
    }
}