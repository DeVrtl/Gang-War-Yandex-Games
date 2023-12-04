using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private const string MoneyAmount = "MoneyAmount";

    [SerializeField] private Finish _finish;

    public int Amount { get; private set; } = 0;

    public event UnityAction<int> MoneyChanged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Money money))
        {
            money.AddTo(this);
        }
    }

    private void OnEnable()
    {
        _finish.LevelCompleted += OnLevelCompleted;
    }

    private void OnDisable()
    {
        _finish.LevelCompleted -= OnLevelCompleted;
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey(MoneyAmount))
        {
            Amount = PlayerPrefs.GetInt(MoneyAmount);
        }
    }

    private void Start()
    {
        MoneyChanged?.Invoke(Amount);
    }

    private void OnLevelCompleted()
    {
        SaveMoney();
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt(MoneyAmount, Amount);
        PlayerPrefs.Save();
    }

    public void AddMoney(int money)
    {
        Amount += money;
        MoneyChanged?.Invoke(Amount);
    }

    public void TakeMoney(int cost)
    {
        Amount -= cost;
        MoneyChanged?.Invoke(Amount);
    }
}
